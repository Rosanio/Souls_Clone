using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class InventoryMenuManager : MenuManager
    {
        PlayerInventory playerInventory;

        public GameObject weaponInventorySlotPrefab;
        public Transform weaponInventorySlotParent;
        public EquipmentSlotEnum selectedEquipmentSlotID;

        WeaponInventorySlot[] weaponInventorySlots;

        private int minimumInventorySlots = 24;
        private int gridColumnCount = 4;
        private List<WeaponInventorySlot> enabledInventorySlots = new List<WeaponInventorySlot>();

        protected override void Awake()
        {
            base.Awake();
            playerInventory = FindObjectOfType<PlayerInventory>();
            weaponInventorySlots = weaponInventorySlotParent.GetComponentsInChildren<WeaponInventorySlot>();

            selectedButtonColor = "#191919";
            unselectedButtonColor = "#5A5A5A";
        }

        public override void Open()
        {
            InitializeInventoryUI();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            ResetToDefault();
            base.Close();
        }

        public void InitializeInventoryUI()
        {
            SetUpInventorySlots();
            menuButtons = GetComponentsInChildren<MenuButton>();
            SelectDefaultButton();
        }

        public override void OnConfirm()
        {
            OnConfirmInventorySlot((WeaponInventorySlot)currentlySelectedButton);
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

        public void OnConfirmInventorySlot(WeaponInventorySlot inventorySlot)
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

        public override void ResetToDefault()
        {
            ResetSelectedEquipmentSlot();
            base.ResetToDefault();
        }

        private void ResetSelectedEquipmentSlot()
        {
            selectedEquipmentSlotID = EquipmentSlotEnum.None;
        }

        private void EquipItemInSlot(WeaponInventorySlot inventorySlot)
        {
            playerInventory.EquipWeapon(inventorySlot.item, selectedEquipmentSlotID);
            ResetSelectedEquipmentSlot();
            uiManager.OpenEquipmentWindow();
        }

        private void SetUpInventorySlots()
        {
            InitializeInventorySlots();
            InitializeButtonNavigation();
            SetDefaultButton();
        }

        private void InitializeInventorySlots()
        {
            enabledInventorySlots.Clear();
            int inventorySlotsCount = Mathf.Max(minimumInventorySlots, playerInventory.weaponsInInventory.Count);
            for (int i = 0; i < inventorySlotsCount; i++)
            {
                if (i >= weaponInventorySlots.Length)
                {
                    Instantiate(weaponInventorySlotPrefab, weaponInventorySlotParent);
                    weaponInventorySlots = weaponInventorySlotParent.GetComponentsInChildren<WeaponInventorySlot>();
                }
                if (i < playerInventory.weaponsInInventory.Count)
                {
                    weaponInventorySlots[i].SetEnabled();
                    weaponInventorySlots[i].AddItem(playerInventory.weaponsInInventory[i]);
                    enabledInventorySlots.Add(weaponInventorySlots[i]);
                }
                else
                {
                    weaponInventorySlots[i].SetDisabled();
                    weaponInventorySlots[i].ClearInventorySlot();
                }
            }
        }

        private void InitializeButtonNavigation()
        {
            for (int i = 0; i < enabledInventorySlots.Count; i++)
            {
                SetUpButton(i);
                SetDownButton(i);
                SetLeftButton(i);
                SetRightButton(i);
            }
        }

        private void SetDefaultButton()
        {
            if (enabledInventorySlots.Count > 0)
                defaultMenuButton = enabledInventorySlots[0];
        }

        private void SetUpButton(int currentSlotIndex)
        {
            int columnIndex = currentSlotIndex % gridColumnCount;
            if (currentSlotIndex > columnIndex)
            {
                enabledInventorySlots[currentSlotIndex].upButton = enabledInventorySlots[currentSlotIndex - gridColumnCount];
            }
            else
            {
                int lastInColumnIndex = GetLastIndexInColumn(columnIndex);
                enabledInventorySlots[currentSlotIndex].upButton = enabledInventorySlots[lastInColumnIndex];
            }
        }

        private void SetDownButton(int currentSlotIndex)
        {
            int columnIndex = currentSlotIndex % gridColumnCount;
            int lastInColumnIndex = GetLastIndexInColumn(columnIndex);

            if (currentSlotIndex < lastInColumnIndex)
                enabledInventorySlots[currentSlotIndex].downButton = enabledInventorySlots[currentSlotIndex + gridColumnCount];
            else
                enabledInventorySlots[currentSlotIndex].downButton = enabledInventorySlots[columnIndex];
        }

        private void SetLeftButton(int currentSlotIndex)
        {
            if (currentSlotIndex == 0)
                enabledInventorySlots[currentSlotIndex].leftButton = enabledInventorySlots[enabledInventorySlots.Count - 1];
            else
                enabledInventorySlots[currentSlotIndex].leftButton = enabledInventorySlots[currentSlotIndex - 1];
        }

        private void SetRightButton(int currentSlotIndex)
        {
            if (currentSlotIndex == enabledInventorySlots.Count - 1)
                enabledInventorySlots[currentSlotIndex].rightButton = enabledInventorySlots[0];
            else
                enabledInventorySlots[currentSlotIndex].rightButton = enabledInventorySlots[currentSlotIndex + 1];
        }

        private int GetLastIndexInColumn(int columnIndex)
        {
            int lastIndexInColumn = enabledInventorySlots.Count - ((enabledInventorySlots.Count - columnIndex) % gridColumnCount);
            if (lastIndexInColumn == enabledInventorySlots.Count)
                lastIndexInColumn -= gridColumnCount;
            return lastIndexInColumn;
        }
    }
}
