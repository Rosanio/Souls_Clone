using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{ 
    public class PlayerManager : CharacterManager
    {
        InputHandler inputHandler;
        CameraHandler cameraHandler;
        PlayerLocomotion playerLocomotion;
        UIManager uiManager;

        InteractableUI interactableUI;
        public GameObject interactableUIGameObject;
        public GameObject itemInteractableGameObject;
        public GameObject confirmUIGameObject;

        [Header("Player Flags")]
        public bool isInAir;
        public bool isGrounded;
        public bool canDoCombo;
        public bool isUsingRightHand;
        public bool isUsingLeftHand;
        public bool isInvulnerable;

        private void Awake()
        {
            cameraHandler = FindObjectOfType<CameraHandler>();
        }

        protected override void Start()
        {
            base.Start();
            inputHandler = GetComponent<InputHandler>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
            interactableUI = FindObjectOfType<InteractableUI>();
            uiManager = FindObjectOfType<UIManager>();
        }

        protected override void Update()
        {
            base.Update();
            float delta = Time.deltaTime;
            canDoCombo = animatorHandler.anim.GetBool("canDoCombo");
            animatorHandler.anim.SetBool("isInAir", isInAir);
            isUsingRightHand = animatorHandler.anim.GetBool("isUsingRightHand");
            isUsingLeftHand = animatorHandler.anim.GetBool("isUsingLeftHand");
            isInvulnerable = animatorHandler.anim.GetBool("isInvulnerable");
            inputHandler.TickInput(delta);

            playerLocomotion.HandleRollingAndSprinting(delta);
            playerLocomotion.HandleJumping();

            stats.HandleStatRegeneration();

            CheckForInteractable();

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

        public void CheckForInteractable()
        {
            RaycastHit hit;
            Vector3 raycastStartPosition = transform.position - 0.5f*transform.forward;
            Debug.DrawRay(raycastStartPosition, transform.forward, Color.red, 0.6f);
            if (Physics.SphereCast(raycastStartPosition, 0.3f, transform.forward, out hit, 1.2f, cameraHandler.ignoreLayers))
            {
                if (hit.collider.tag == "Interactable")
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();

                    if (interactable != null)
                    {
                        interactableUI.interactableText.text = interactable.interactableText;
                        interactableUIGameObject.SetActive(true);
                        if (inputHandler.interactFlag)
                        {
                            hit.collider.GetComponent<Interactable>().Interact(this);
                        }
                    }
                }
            }
            else
            {
                if (interactableUIGameObject != null)
                {
                    interactableUIGameObject.SetActive(false);
                    if (inputHandler.interactFlag)
                    {
                        itemInteractableGameObject.SetActive(false);
                        confirmUIGameObject.SetActive(false);
                    }
                }
            }
        }
    }
}

