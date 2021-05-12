using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{ 
    public class PlayerManager : CharacterManager
    {
        public GameManager gameManager;

        InputHandler inputHandler;
        CameraHandler cameraHandler;
        PlayerLocomotion playerLocomotion;
        UIManager uiManager;
        PlayerInventory playerInventory;

        [Header("Player Flags")]
        public bool isInAir;
        public bool isGrounded;
        public bool canDoCombo;
        public bool isUsingRightHand;
        public bool isUsingLeftHand;
        public bool isInvulnerable;

        private List<Interactable> interactablesInRange = new List<Interactable>();
        private Interactable activeInteractable;

        private void Awake()
        {
            cameraHandler = FindObjectOfType<CameraHandler>();
        }

        protected override void Start()
        {
            base.Start();
            inputHandler = GetComponent<InputHandler>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
            uiManager = FindObjectOfType<UIManager>();
            playerInventory = GetComponent<PlayerInventory>();
        }

        protected override void Update()
        {
            base.Update();
            float delta = Time.deltaTime;

            canDoCombo = animatorHandler.anim.GetBool("canDoCombo");
            isUsingRightHand = animatorHandler.anim.GetBool("isUsingRightHand");
            isUsingLeftHand = animatorHandler.anim.GetBool("isUsingLeftHand");
            isInvulnerable = animatorHandler.anim.GetBool("isInvulnerable");
            playerLocomotion.canRotate = animatorHandler.anim.GetBool("canRotate");

            animatorHandler.anim.SetBool("isInAir", isInAir);
            animatorHandler.anim.SetBool("isBlocking", isBlocking);

            inputHandler.TickInput(delta);

            playerLocomotion.HandleRollingAndSprinting(delta);
            playerLocomotion.HandleJumping();

            stats.HandleStatRegeneration();

        }
        private void FixedUpdate()
        {
            float delta = Time.deltaTime;
            playerLocomotion.HandleMovement(delta);
            playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
        }

        private void LateUpdate()
        {
            float delta = Time.fixedDeltaTime;

            if (cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                if (!uiManager.isPaused)
                {
                    cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
                    cameraHandler.UpdateLockOnState();
                }
            }

            if (isInAir)
            {
                playerLocomotion.inAirTimer += Time.deltaTime;
            }

            inputHandler.ResetInputFlags();
        }

        public void AddInteractable(Interactable interactable)
        {
            interactablesInRange.Add(interactable);
            activeInteractable = interactable;
            uiManager.SetActiveInteractable(activeInteractable);
        }

        public void RemoveInteractable(Interactable interactable)
        {
            interactablesInRange.Remove(interactable);
            if (interactablesInRange.Count == 0)
            {
                activeInteractable = null;
                uiManager.DisableInteractableUI();
            }
            else
            {
                activeInteractable = interactablesInRange[0];
                uiManager.SetActiveInteractable(activeInteractable);
            }
        }

        public void TryInteract()
        {
            if (uiManager.AwaitingConfirmation())
            {
                uiManager.DisableItemPickUpUI();
                if (activeInteractable != null)
                {
                    uiManager.SetActiveInteractable(activeInteractable);
                }
            }
            else if (activeInteractable != null)
            {
                PickUpActiveItem();
            }
        }

        private void PickUpActiveItem()
        {
            Item item = ((ItemPickup)activeInteractable).item;
            if (item == null)
                throw new Exception("Item pickup does not have an item assigned to it");
            animatorHandler.PlayTargetAnimation("Pick Up", true);
            playerInventory.PickUpItem(item);
            Destroy(activeInteractable.gameObject);
            RemoveInteractable(activeInteractable);
            uiManager.OnItemPickUp(item);
        }

        public void RespawnPlayer()
        {
            animatorHandler.PlayTargetAnimation("Get Up", true);
            gameManager.ResetPlayerAndEnemies();
            cameraHandler.SnapToTarget();
        }
    }
}
