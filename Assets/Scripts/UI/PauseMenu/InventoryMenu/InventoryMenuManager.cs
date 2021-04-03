using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class InventoryMenuManager : MenuManager
    {
        private const float UNTABBED_PANEL_HEIGHT = 450;
        private const float TABBED_PANEL_HEIGHT = 380;
        private const float PANEL_WIDTH = 300;
        private const string SELECTED_TAB_COLOR = "#ffffff";
        private const string UNSELECTED_TAB_COLOR = "#5E5E5E";

        PlayerInventory playerInventory;

        public GameObject tabsPanel;
        public EquipmentSlotEnum selectedEquipmentSlotID;

        public WeaponsInventoryPanel weaponsPanel;
        public ConsumablesInventoryPanel consumablesPanel;

        private InventoryPanel currentInventoryPanel;
        private InventoryTabButton[] tabs;
        private InventoryTabButton activeTabButton;

        protected override void Awake()
        {
            base.Awake();
            playerInventory = FindObjectOfType<PlayerInventory>();
        }

        public override void Open()
        {
            SetCurrentInventoryPanel();
            ShowOrHideTabs();
            SetCurrentPanelSize();
            currentInventoryPanel.SetUpInventorySlots(GetMinimumInventorySlots());

            base.Open();
        }

        public override void Close()
        {
            ResetToDefault();
            if (currentInventoryPanel != null)
                currentInventoryPanel.Close();
            base.Close();
        }

        protected override Panel GetPanel()
        {
            return currentInventoryPanel;
        }

        private void ShowOrHideTabs()
        {
            if (selectedEquipmentSlotID == EquipmentSlotEnum.None)
            {
                tabsPanel.SetActive(true);
                tabs = tabsPanel.GetComponentsInChildren<InventoryTabButton>();
                SetActiveTab(tabs[0]);
            }
            else
            {
                tabsPanel.SetActive(false);
            }
        }

        private void SetCurrentPanelSize()
        {
            float height = selectedEquipmentSlotID == EquipmentSlotEnum.None ? TABBED_PANEL_HEIGHT : UNTABBED_PANEL_HEIGHT;
            currentInventoryPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(PANEL_WIDTH, height);
        }

        public override void OnConfirm()
        {
            OnConfirmInventorySlot(currentInventoryPanel.GetSelectedInventorySlot());
        }

        public override void OnBack()
        {
            if (selectedEquipmentSlotID == EquipmentSlotEnum.None)
                uiManager.OpenSelectWindow();
            else
                uiManager.OpenEquipmentWindow();
        }

        public override void OnOption1()
        {
            // Drop item
        }

        public override void OnTabLeft()
        {
            HandleTabChange(activeTabButton.leftTab);
        }

        public override void OnTabRight()
        {
            HandleTabChange(activeTabButton.rightTab);
        }

        public override void OnNavigateLeft()
        {
            currentInventoryPanel.OnNavigateLeft();
        }

        public override void OnNavigateRight()
        {
            currentInventoryPanel.OnNavigateRight();
        }

        public override void OnNavigateUp()
        {
            currentInventoryPanel.OnNavigateUp();
        }

        public override void OnNavigateDown()
        {
            currentInventoryPanel.OnNavigateDown();
        }

        public void OnConfirmInventorySlot(InventorySlot inventorySlot)
        {
            if (selectedEquipmentSlotID == EquipmentSlotEnum.None)
            {
                // TODO: Open submenu with option to use, leave, drop, etc.
            }
            else
            {
                EquipItemInSlot(inventorySlot);
            }
        }

        public void SetSelectedButton(InventorySlot slot)
        {
            currentInventoryPanel.SetSelectedButton(slot);
        }

        public override void ResetToDefault()
        {
            ResetSelectedEquipmentSlot();
            weaponsPanel.ResetToDefault();
            consumablesPanel.ResetToDefault();
            base.ResetToDefault();
        }

        private void ResetSelectedEquipmentSlot()
        {
            selectedEquipmentSlotID = EquipmentSlotEnum.None;
        }

        private void EquipItemInSlot(InventorySlot inventorySlot)
        {
            if (inventorySlot is WeaponInventorySlot weaponSlot)
                playerInventory.EquipWeapon(weaponSlot.weapon, selectedEquipmentSlotID);
            else if (inventorySlot is ConsumableInventorySlot consumableSlot)
                playerInventory.EquipConsumable(consumableSlot.consumable, selectedEquipmentSlotID);

            ResetSelectedEquipmentSlot();
            uiManager.OpenEquipmentWindow();
        }

        private void HandleTabChange(InventoryTabButton newTab)
        {
            if (selectedEquipmentSlotID != EquipmentSlotEnum.None) return;

            SetActiveTab(newTab);
            OpenActiveTabPanel();
        }

        private void SetActiveTab(InventoryTabButton newTab)
        {
            if (activeTabButton != null)
                activeTabButton.SetIconColor(UNSELECTED_TAB_COLOR);
            newTab.SetIconColor(SELECTED_TAB_COLOR);
            activeTabButton = newTab;
        }

        private void OpenActiveTabPanel()
        {
            currentInventoryPanel.Close();
            currentInventoryPanel = activeTabButton.panel;
            SetCurrentPanelSize();
            currentInventoryPanel.Open(GetMinimumInventorySlots());
        }

        private void SetCurrentInventoryPanel()
        {
            switch(selectedEquipmentSlotID)
            {
                case EquipmentSlotEnum.ConsumableSlot01:
                case EquipmentSlotEnum.ConsumableSlot02:
                case EquipmentSlotEnum.ConsumableSlot03:
                case EquipmentSlotEnum.ConsumableSlot04:
                case EquipmentSlotEnum.ConsumableSlot05:
                case EquipmentSlotEnum.ConsumableSlot06:
                case EquipmentSlotEnum.ConsumableSlot07:
                case EquipmentSlotEnum.ConsumableSlot08:
                case EquipmentSlotEnum.None:
                    currentInventoryPanel = consumablesPanel;
                    break;
                case EquipmentSlotEnum.RightHandSlot01:
                case EquipmentSlotEnum.RightHandSlot02:
                case EquipmentSlotEnum.RightHandSlot03:
                case EquipmentSlotEnum.LeftHandSlot01:
                case EquipmentSlotEnum.LeftHandSlot02:
                case EquipmentSlotEnum.LeftHandSlot03:
                    currentInventoryPanel = weaponsPanel;
                    break;
            }
        }

        private int GetMinimumInventorySlots()
        {
            return selectedEquipmentSlotID == EquipmentSlotEnum.None ? 20 : 24;
        }
    }
}
