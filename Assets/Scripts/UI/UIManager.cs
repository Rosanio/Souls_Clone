using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class UIManager : MonoBehaviour
    {
        [Header("Menu Managers")]
        public SelectMenuManager selectMenuManager;
        public EquipmentMenuManager equipmentMenuManager;
        public InventoryMenuManager inventoryMenuManager;
        public CheckpointMenuManager checkpointMenuManager;

        InteractableUI interactableUI;

        public GameObject hudWindow;
        public GameObject lockOnTarget;
        public GameObject enemyHealthBar;
        public GameObject interactableUIGameObject;
        public GameObject itemInteractableGameObject;
        public GameObject confirmUIGameObject;

        [HideInInspector] public bool isPaused = false;
        [HideInInspector] public bool isResting = false;

        MenuManager currentMenuManager;

        PlayerAnimatorHandler animatorHandler;

        private void Awake()
        {
            interactableUI = FindObjectOfType<InteractableUI>();

            // Activate the inventory menu manager game object, so that updates can be applied to it before
            // it is visible to the player. This prevents icons popping in or colors changing on the first frame

            inventoryMenuManager.gameObject.SetActive(true);
            inventoryMenuManager.gameObject.SetActive(false);

            animatorHandler = FindObjectOfType<PlayerAnimatorHandler>();
        }

        #region Menu Toggling

        public void TogglePauseMenu()
        {
            if (isResting)
                ExitCheckpointMenu();
            else if (isPaused)
                ExitPauseMenu();
            else
                OpenPauseMenu();
        }

        public void OpenPauseMenu()
        {
            Pause();
            hudWindow.SetActive(false);
            OpenSelectWindow();
        }

        public void OpenSelectWindow()
        {
            OpenMenu(selectMenuManager);
        }

        public void OpenEquipmentWindow()
        {
            OpenMenu(equipmentMenuManager);
        }

        public void OpenInventoryWindow(EquipmentSlotEnum selectedEquipmentSlotID = EquipmentSlotEnum.None)
        {
            inventoryMenuManager.selectedEquipmentSlotID = selectedEquipmentSlotID;
            OpenMenu(inventoryMenuManager);
        }

        public void OpenCheckpointWindow()
        {
            Pause();
            isResting = true;
            OpenMenu(checkpointMenuManager);
        }

        public void ExitCheckpointMenu()
        {
            ExitPauseMenu();
            EnableInteractableUI();
            animatorHandler.PlayTargetAnimation("Kneeling Up", true);
            isResting = false;
        }

        public void ExitPauseMenu()
        {
            ResetMenusToDefaultState();
            CloseAllMenus();
            hudWindow.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            isPaused = false;
        }

        private void OpenMenu(MenuManager menu)
        {
            if (currentMenuManager != null)
                currentMenuManager.Close();
            currentMenuManager = menu;
            currentMenuManager.Open();
        }

        private void ResetMenusToDefaultState()
        {
            selectMenuManager.ResetToDefault();
            equipmentMenuManager.ResetToDefault();
            inventoryMenuManager.ResetToDefault();
            checkpointMenuManager.ResetToDefault();
        }

        private void CloseAllMenus()
        {
            selectMenuManager.Close();
            equipmentMenuManager.Close();
            inventoryMenuManager.Close();
            checkpointMenuManager.Close();
        }

        #endregion

        #region Input Handling

        public void ConfirmSelectedMenuItem()
        {
            currentMenuManager.OnConfirm();
        }

        public void GoBack()
        {
            currentMenuManager.OnBack();
        }

        public void PerformOption1()
        {
            currentMenuManager.OnOption1();
        }

        public void TabLeft()
        {
            currentMenuManager.OnTabLeft();
        }

        public void TabRight()
        {
            currentMenuManager.OnTabRight();
        }

        public void NavigateLeft()
        {
            currentMenuManager.OnNavigateLeft();
        }

        public void NavigateRight()
        {
            currentMenuManager.OnNavigateRight();
        }

        public void NavigateUp()
        {
            currentMenuManager.OnNavigateUp();
        }

        public void NavigateDown()
        {
            currentMenuManager.OnNavigateDown();
        }

        #endregion

        public void EnableLockOnUI()
        {
            lockOnTarget.SetActive(true);
            enemyHealthBar.SetActive(true);
        }

        public void PositionLockOnUI(Vector3 targetPosition, Vector3 healthBarPosition)
        {
            lockOnTarget.transform.position = targetPosition;
            enemyHealthBar.transform.position = healthBarPosition;
        }

        public void DisableLockOnUI()
        {
            lockOnTarget.SetActive(false);
            enemyHealthBar.SetActive(false);
        }

        public void OnItemPickUp(Item item)
        {
            DisableInteractableUI();
            itemInteractableGameObject.SetActive(true);
            itemInteractableGameObject.GetComponentInChildren<Text>().text = item.itemName;
            GameObject.Find("ItemIcon").GetComponent<Image>().sprite = item.icon;
            confirmUIGameObject.SetActive(true);
        }

        public void SetActiveInteractable(Interactable interactable)
        {
            if (!interactableUIGameObject.activeSelf)
                interactableUIGameObject.SetActive(true);

            interactableUI.interactableText.text = interactable.interactableText;
        }

        public void EnableInteractableUI()
        {
            interactableUIGameObject.SetActive(true);
        }

        public void DisableInteractableUI()
        {
            interactableUIGameObject.SetActive(false);
        }

        public void DisableItemPickUpUI()
        {
            itemInteractableGameObject.SetActive(false);
            confirmUIGameObject.SetActive(false);
        }

        public bool AwaitingConfirmation()
        {
            return confirmUIGameObject.activeSelf;
        }

        private void Pause()
        {
            isPaused = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

