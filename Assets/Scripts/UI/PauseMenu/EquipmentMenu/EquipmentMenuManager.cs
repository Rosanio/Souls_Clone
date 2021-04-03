using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class EquipmentMenuManager : MenuManager
    {
        PlayerInventory playerInventory;

        HandEquipmentSlot[] handEquipmentSlots;
        ConsumableEquipmentSlot[] consumableEquipmentSlots;

        private EquipmentMenuPanel equipmentMenuPanel;

        protected override void Awake()
        {
            base.Awake();
            playerInventory = FindObjectOfType<PlayerInventory>();
            equipmentMenuPanel = GetComponentInChildren<EquipmentMenuPanel>();

            handEquipmentSlots = GetComponentsInChildren<HandEquipmentSlot>();
            consumableEquipmentSlots = GetComponentsInChildren<ConsumableEquipmentSlot>();

            LoadItemsOnEquipmentScreen();
        }

        public override void Open()
        {
            base.Open();
            LoadItemsOnEquipmentScreen();
        }

        public override void OnConfirm()
        {
            EquipItemInSlot(equipmentMenuPanel.GetSelectedSlot());
        }

        public override void OnBack()
        {
            ResetToDefault();
            uiManager.OpenSelectWindow();
        }

        public override void OnOption1()
        {
            UnequipItemInSlot(equipmentMenuPanel.GetSelectedSlot());
        }

        public override void ResetToDefault()
        {
            if (equipmentMenuPanel != null)
                equipmentMenuPanel.ResetToDefault();
        }

        protected override Panel GetPanel()
        {
            return equipmentMenuPanel;
        }

        public void SetSelectedEquipmentSlot(EquipmentSlot equipmentSlot)
        {
            equipmentMenuPanel.SetSelectedButton(equipmentSlot);
        }

        public void EquipItemInSlot(EquipmentSlot equipmentSlot)
        {
            uiManager.OpenInventoryWindow(equipmentSlot.equipmentSlotID);
        }

        public void UnequipItemInSlot(EquipmentSlot equipmentSlot)
        {
            if (equipmentSlot is HandEquipmentSlot)
                playerInventory.UnequipWeapon(equipmentSlot.equipmentSlotID);
            else if (equipmentSlot is ConsumableEquipmentSlot)
                playerInventory.UnequipConsumable(equipmentSlot.equipmentSlotID);
            equipmentSlot.UnequipItem();
        }

        private void LoadItemsOnEquipmentScreen()
        {
            LoadWeapons();
            LoadConsumables();
        }

        private void LoadWeapons()
        {
            foreach (HandEquipmentSlot slot in handEquipmentSlots)
            {
                WeaponItem weapon = playerInventory.GetEquippedWeapon(slot.equipmentSlotID);
                if (weapon != playerInventory.unarmedWeapon)
                {
                    slot.AddItem(weapon);
                }
            }
        }

        private void LoadConsumables()
        {
            foreach(ConsumableEquipmentSlot slot in consumableEquipmentSlots)
            {
                ConsumableItem consumable = playerInventory.GetEquippedConsumable(slot.equipmentSlotID);
                if (consumable != null)
                    slot.AddItem(consumable);
            }
        }
    }
}