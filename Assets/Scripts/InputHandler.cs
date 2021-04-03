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
        public bool interact_Input;
        public bool roll_Input;
        public bool twoHand_Input;
        public bool rhLightAttack_Input;
        public bool rhStrongAttack_Input;
        public bool d_Pad_Up;
        public bool d_Pad_Down;
        public bool switchLeftWeapon_Input;
        public bool switchRightWeapon_Input;
        public bool jump_Input;
        public bool inventory_Input;
        public bool lockOn_Input;
        public bool walk_Input;
        public bool useItem_Input;

        // Menu navigation inputs
        public bool confirm_Input;
        public bool back_Input;
        public bool menuOption1_Input;
        public bool navigateLeft_Input;
        public bool navigateRight_Input;
        public bool navigateUp_Input;
        public bool navigateDown_Input;
        public bool tabLeft_Input;
        public bool tabRight_Input;

        public bool rollFlag;
        public bool sprintFlag;
        public bool walkFlag;
        public bool lockOnFlag;
        public bool twoHandFlag;

        public float rollInputTimer;

        PlayerControls inputActions;
        PlayerAttacker playerAttacker;
        PlayerInventory playerInventory;
        PlayerManager playerManager;
        PlayerWeaponSlotManager weaponSlotManager;
        ConsumableSlotManager consumableSlotManager;
        UIManager uiManager;
        CameraHandler cameraHandler;
        AnimatorHandler animatorHandler;

        Vector2 movementInput;
        Vector2 cameraInput;

        private bool switchingLockOnTarget = false;
        private Coroutine enableLockOnSwitchingCoroutine;

        private void Awake()
        {
            playerAttacker = GetComponent<PlayerAttacker>();
            playerInventory = GetComponent<PlayerInventory>();
            playerManager = GetComponent<PlayerManager>();
            weaponSlotManager = GetComponentInChildren<PlayerWeaponSlotManager>();
            consumableSlotManager = GetComponentInChildren<ConsumableSlotManager>();
            uiManager = FindObjectOfType<UIManager>();
            cameraHandler = FindObjectOfType<CameraHandler>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();

                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();

                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

                inputActions.PlayerActions.RB.performed += i => rhLightAttack_Input = true;
                inputActions.PlayerActions.RT.performed += i => rhStrongAttack_Input = true;
                inputActions.PlayerActions.Interact.performed += i => interact_Input = true;
                inputActions.PlayerActions.Jump.performed += inputActions => jump_Input = true;
                inputActions.PlayerActions.Inventory.performed += inputActions => inventory_Input = true;
                inputActions.PlayerActions.LockOn.performed += inputActions => lockOn_Input = true;
                inputActions.PlayerActions.TwoHand.performed += i => twoHand_Input = true;
                inputActions.PlayerActions.UseItem.performed += i => useItem_Input = true;

                inputActions.InventoryManagement.DPadRight.performed += i => switchRightWeapon_Input = true;
                inputActions.InventoryManagement.DPadLeft.performed += i => switchLeftWeapon_Input = true;

                inputActions.MenuNavigation.Confirm.performed += i => confirm_Input = true;
                inputActions.MenuNavigation.Back.performed += i => back_Input = true;
                inputActions.MenuNavigation.MenuOption1.performed += i => menuOption1_Input = true;
                inputActions.MenuNavigation.NavigateLeft.performed += i => navigateLeft_Input = true;
                inputActions.MenuNavigation.NavigateRight.performed += i => navigateRight_Input = true;
                inputActions.MenuNavigation.NavigateUp.performed += i => navigateUp_Input = true;
                inputActions.MenuNavigation.NavigateDown.performed += i => navigateDown_Input = true;
                inputActions.MenuNavigation.TabLeft.performed += i => tabLeft_Input = true;
                inputActions.MenuNavigation.TabRight.performed += i => tabRight_Input = true;
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
            HandleLockOnInput();
            if (!uiManager.isPaused)
            {
                HandleWalkInput();
                HandleRollInput(delta);
                HandleAttackInput();
                HandleQuickSlotInput();
                HandleInteractionInput();
                HandleTwoHandInput();
                HandleUseItemInput();
            }
            else
            {
                HandleInventoryInputs();
            }
            HandleInventoryToggle();
        }

        public void ResetInputFlags()
        {
            // In Game Inputs
            rollFlag = false;
            rhLightAttack_Input = false;
            rhStrongAttack_Input = false;
            d_Pad_Up = false;
            d_Pad_Down = false;
            switchLeftWeapon_Input = false;
            switchRightWeapon_Input = false;
            interact_Input = false;
            jump_Input = false;
            inventory_Input = false;
            lockOn_Input = false;
            twoHand_Input = false;
            useItem_Input = false;

            // Menu Inputs
            confirm_Input = false;
            back_Input = false;
            menuOption1_Input = false;
            navigateLeft_Input = false;
            navigateRight_Input = false;
            navigateUp_Input = false;
            navigateDown_Input = false;
            tabLeft_Input = false;
            tabRight_Input = false;
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
            roll_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
            if (roll_Input)
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

        private void HandleAttackInput()
        {
            if (rhLightAttack_Input || rhStrongAttack_Input)
            {
                animatorHandler.anim.SetBool("isUsingRightHand", true);
                if (playerManager.canDoCombo)
                {
                    
                    playerAttacker.HandleWeaponCombo(playerInventory.rightWeapon);
                }
                else
                {
                    if (playerManager.isInteracting)
                        return;
                    if (rhStrongAttack_Input)
                        playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
                    else
                        playerAttacker.HandleLightAttack(playerInventory.rightWeapon);
                }
            }
        }

        private void HandleQuickSlotInput()
        {
            if (switchRightWeapon_Input)
            {
                playerInventory.ChangeRightWeapon();
            }
            if (switchLeftWeapon_Input)
            {
                playerInventory.ChangeLeftWeapon();
            }
        }

        private void HandleInteractionInput()
        {
            if (interact_Input)
                playerManager.TryInteract();
        }

        private void HandleInventoryInputs()
        {
            if (confirm_Input)
                uiManager.ConfirmSelectedMenuItem();
            else if (back_Input)
                uiManager.GoBack();
            else if (menuOption1_Input)
                uiManager.PerformOption1();
            else if (tabLeft_Input)
                uiManager.TabLeft();
            else if (tabRight_Input)
                uiManager.TabRight();
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

        private void HandleTwoHandInput()
        {
            if (twoHand_Input)
            {
                twoHandFlag = !twoHandFlag;

                    weaponSlotManager.LoadWeaponOnSlot(playerInventory.rightWeapon, WeaponSlotID.RightHandSlot);
                if (!twoHandFlag)
                {
                    weaponSlotManager.LoadWeaponOnSlot(playerInventory.leftWeapon, WeaponSlotID.LeftHandSlot);
                }
            }
        }

        private void HandleUseItemInput()
        {
            if (useItem_Input)
            {
                if (!playerManager.isInteracting)
                {
                    ConsumableItem equippedConsumable = playerInventory.consumable;
                    consumableSlotManager.UseConsumable(equippedConsumable);
                }
            }
        }

        private IEnumerator EnableTargetSwitching()
        {
            yield return new WaitForSeconds(0.5f);
            switchingLockOnTarget = false;
        }
    }
}
