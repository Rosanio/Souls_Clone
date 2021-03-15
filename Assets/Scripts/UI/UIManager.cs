using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class UIManager : MonoBehaviour
    {
        [Header("Menu Managers")]
        public SelectMenuManager selectMenuManager;
        public EquipmentMenuManager equipmentMenuManager;
        public InventoryMenuManager inventoryMenuManager;

        public GameObject hudWindow;
        public GameObject lockOnTarget;
        public GameObject enemyHealthBar;
        
        [HideInInspector] public bool isPaused = false;

        MenuManager currentMenuManager;

        private void Awake()
        {
            // Activate the inventory menu manager game object, so that updates can be applied to it before
            // it is visible to the player. This prevents icons popping in or colors changing on the first frame
            inventoryMenuManager.gameObject.SetActive(true);
            inventoryMenuManager.InitializeInventoryUI();
            inventoryMenuManager.gameObject.SetActive(false);
        }

        #region Menu Toggling

        public void TogglePauseMenu()
        {
            if (isPaused)
                ExitPauseMenu();
            else
                OpenPauseMenu();
        }

        public void OpenPauseMenu()
        {
            isPaused = true;
            Cursor.lockState = CursorLockMode.None;
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
        }

        private void CloseAllMenus()
        {
            selectMenuManager.Close();
            equipmentMenuManager.Close();
            inventoryMenuManager.Close();
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
    }
}

