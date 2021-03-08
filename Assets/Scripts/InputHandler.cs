using System.Collections;
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

        // In game inputs
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

        // Menu navigation inputs
        public bool confirm_Input;
        public bool back_Input;
        public bool menuOption1_Input;
        public bool navigateLeft_Input;
        public bool navigateRight_Input;
        public bool navigateUp_Input;
        public bool navigateDown_Input;

        public bool rollFlag;
        public bool sprintFlag;
        public bool walkFlag;
        public bool comboFlag;
        public bool lockOnFlag;
        public bool interactFlag;
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
                inputActions.MenuNavigation.Confirm.performed += i => confirm_Input = true;
                inputActions.MenuNavigation.Back.performed += i => back_Input = true;
                inputActions.MenuNavigation.MenuOption1.performed += i => menuOption1_Input = true;
                inputActions.MenuNavigation.NavigateLeft.performed += i => navigateLeft_Input = true;
                inputActions.MenuNavigation.NavigateRight.performed += i => navigateRight_Input = true;
                inputActions.MenuNavigation.NavigateUp.performed += i => navigateUp_Input = true;
                inputActions.MenuNavigation.NavigateDown.performed += i => navigateDown_Input = true;
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
            if (!uiManager.isPaused)
            {
                HandleWalkInput();
                HandleRollInput(delta);
                HandleAttackInput(delta);
                HandleQuickSlotInput();
                HandleInteractionInput();
            }
            else
            {
                HandleInventoryInputs();
            }
            HandleInventoryToggle();
            HandleLockOnInput();
        }

        public void ResetInputFlags()
        {
            // In Game Inputs
            rollFlag = false;
            rb_Input = false;
            rt_Input = false;
            d_Pad_Up = false;
            d_Pad_Down = false;
            d_Pad_Left = false;
            d_Pad_Right = false;
            a_Input = false;
            jump_Input = false;
            inventory_Input = false;
            lockOn_Input = false;
            interactFlag = false;

            // Menu Inputs
            confirm_Input = false;
            back_Input = false;
            menuOption1_Input = false;
            navigateLeft_Input = false;
            navigateRight_Input = false;
            navigateUp_Input = false;
            navigateDown_Input = false;
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

        private void HandleInteractionInput()
        {
            if (a_Input)
                interactFlag = true;
        }

        private void HandleInventoryInputs()
        {
            if (confirm_Input)
                uiManager.ConfirmSelectedMenuItem();
            else if (back_Input)
                uiManager.GoBack();
            else if (menuOption1_Input)
                uiManager.PerformOption1();
            else if (navigateLeft_Input)
                uiManager.NavigateLeft();
            else if (navigateRight_Input)
                uiManager.NavigateRight();
            else if (navigateUp_Input)
                uiManager.NavigateUp();
            else if (navigateDown_Input)
                uiManager.NavigateDown();
        }

        private void HandleInventoryToggle()
        {
            if (inventory_Input)
            {
                uiManager.TogglePauseMenu();
            }
        }

        private void HandleLockOnInput()
        {
            if (uiManager.isPaused)
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
            switchingLockOnTarget = false;
        }
    }
}
