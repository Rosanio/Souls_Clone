using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        public bool b_Input;
        public bool rb_Input;
        public bool rt_Input;
        public bool d_Pad_Up;
        public bool d_Pad_Down;
        public bool d_Pad_Left;
        public bool d_Pad_Right;
        public bool a_Input;
        public bool jump_Input;
        public bool inventory_Input;
        public bool lockOn_Input;
        public bool walk_Input;

        public bool rollFlag;
        public bool sprintFlag;
        public bool walkFlag;
        public bool comboFlag;
        public bool lockOnFlag;
        public bool inventoryFlag;
        public float rollInputTimer;

        PlayerControls inputActions;
        PlayerAttacker playerAttacker;
        PlayerInventory playerInventory;
        PlayerManager playerManager;
        UIManager uiManager;
        CameraHandler cameraHandler;

        Vector2 movementInput;
        Vector2 cameraInput;

        private bool switchingLockOnTarget = false;
        private Coroutine enableLockOnSwitchingCoroutine;

        private void Awake()
        {
            playerAttacker = GetComponent<PlayerAttacker>();
            playerInventory = GetComponent<PlayerInventory>();
            playerManager = GetComponent<PlayerManager>();
            uiManager = FindObjectOfType<UIManager>();
            cameraHandler = FindObjectOfType<CameraHandler>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
                inputActions.PlayerActions.RB.performed += i => rb_Input = true;
                inputActions.PlayerActions.RT.performed += i => rt_Input = true;
                inputActions.InventoryManagement.DPadRight.performed += i => d_Pad_Right = true;
                inputActions.InventoryManagement.DPadLeft.performed += i => d_Pad_Left = true;
                inputActions.PlayerActions.Interact.performed += i => a_Input = true;
                inputActions.PlayerActions.Jump.performed += inputActions => jump_Input = true;
                inputActions.PlayerActions.Inventory.performed += inputActions => inventory_Input = true;
                inputActions.PlayerActions.LockOn.performed += inputActions => lockOn_Input = true;
            }

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput(float delta)
        {
            MoveInput(delta);
            HandleWalkInput();
            HandleRollInput(delta);
            HandleAttackInput(delta);
            HandleQuickSlotInput();
            HandleInventoryInput();
            HandleLockOnInput();
        }

        private void MoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleWalkInput()
        {
            walk_Input = inputActions.PlayerActions.Walk.phase == UnityEngine.InputSystem.InputActionPhase.Started;
            walkFlag = walk_Input && moveAmount > 0;
        }

        private void HandleRollInput(float delta)
        {
            b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
            if (b_Input)
            {
                rollInputTimer += delta;
                if (moveAmount > 0)
                {
                    sprintFlag = true;
                }
            }
            else
            {
                sprintFlag = false;
                if (rollInputTimer > 0 && rollInputTimer < 0.5f)
                {
                    rollFlag = true;
                }

                rollInputTimer = 0;
            }
        }

        private void HandleAttackInput(float delta)
        {
            if (rb_Input || rt_Input)
            {
                if (inventoryFlag) return; //Don't attack when inventory is open, in case player is clicking a menu option
                if (playerManager.canDoCombo)
                {
                    comboFlag = true;
                    playerAttacker.HandleWeaponCombo(playerInventory.rightWeapon);
                    comboFlag = false;
                }
                else
                {
                    if (playerManager.isInteracting || playerManager.canDoCombo)
                        return;
                    if (rt_Input)
                        playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
                    else
                        playerAttacker.HandleLightAttack(playerInventory.rightWeapon);
                }
            }
        }

        private void HandleQuickSlotInput()
        {
            if (d_Pad_Right)
            {
                playerInventory.ChangeRightWeapon();
            }
            if (d_Pad_Left)
            {
                playerInventory.ChangeLeftWeapon();
            }
        }

        private void HandleInventoryInput()
        {
            if (inventory_Input)
            {
                inventoryFlag = !inventoryFlag;

                if (inventoryFlag)
                {
                    Cursor.lockState = CursorLockMode.None;
                    uiManager.OpenSelectWindow();
                    uiManager.UpdateUI();
                    uiManager.hudWindow.SetActive(false);
                }
                else
                {
                    uiManager.CloseAllInventoryWindows();
                    uiManager.hudWindow.SetActive(true);
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }

        private void HandleLockOnInput()
        {
            if (inventoryFlag)
            {
                lockOn_Input = false;
                cameraHandler.ClearLockOnTargets();
                lockOnFlag = false;
                return;
            }

            if (lockOn_Input && !lockOnFlag)
            {
                lockOn_Input = false;
                lockOnFlag = cameraHandler.LockOnToNearestTarget();
            }
            else if (lockOn_Input && lockOnFlag)
            {
                lockOn_Input = false;
                lockOnFlag = false;
                cameraHandler.ClearLockOnTargets();
            }

            if (lockOnFlag && cameraInput.x > 12 && !switchingLockOnTarget)
            {
                switchingLockOnTarget = true;
                enableLockOnSwitchingCoroutine = StartCoroutine(EnableTargetSwitching());
                cameraHandler.SwitchLockOnTarget(false);
            }
            else if (lockOnFlag && cameraInput.x < -12 && !switchingLockOnTarget)
            {
                switchingLockOnTarget = true;
                enableLockOnSwitchingCoroutine = StartCoroutine(EnableTargetSwitching());
                cameraHandler.SwitchLockOnTarget(true);
            }
            else if (cameraInput.x > -0.5 && cameraInput.x < 0.5 && switchingLockOnTarget)
            {
                switchingLockOnTarget = false;
                if (enableLockOnSwitchingCoroutine != null)
                    StopCoroutine(enableLockOnSwitchingCoroutine);
            }

            cameraHandler.SetCameraHeight();
        }

        private IEnumerator EnableTargetSwitching()
        {
            yield return new WaitForSeconds(0.5f);
            print("Enabling lock on from coroutine");
            switchingLockOnTarget = false;
        }
    }
}
