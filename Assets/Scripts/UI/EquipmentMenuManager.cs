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

        protected override void Awake()
        {
            base.Awake();
            playerInventory = FindObjectOfType<PlayerInventory>();
            handEquipmentSlots = GetComponentsInChildren<HandEquipmentSlot>();

            selectedButtonColor = "#5E5E5E";
            unselectedButtonColor = "#ffffff";

            LoadWeaponsOnEquipmentScreen();
        }

        public override void Open()
        {
            base.Open();
            LoadWeaponsOnEquipmentScreen();
        }

        public override void OnConfirm()
        {
            EquipItemInSlot((HandEquipmentSlot)currentlySelectedButton);
        }

        public override void OnBack()
        {
            ResetToDefault();
            uiManager.OpenSelectWindow();
        }

        public override void OnOption1()
        {
            UnequipItemInSlot((HandEquipmentSlot)currentlySelectedButton);
        }

        public void SetSelectedEquipmentSlot(HandEquipmentSlot equipmentSlot)
        {
            SetSelectedButton(equipmentSlot);
        }

        public void LoadWeaponsOnEquipmentScreen()
        {
            foreach(HandEquipmentSlot slot in handEquipmentSlots)
            {
                WeaponItem weapon = playerInventory.GetEquippedWeapon(slot.equipmentSlotID);
                if (weapon != playerInventory.unarmedWeapon)
                {
                    slot.AddItem(weapon);
                }
            }
        }

        public void EquipItemInSlot(HandEquipmentSlot equipmentSlot)
        {
            uiManager.OpenInventoryWindow(equipmentSlot.equipmentSlotID);
        }

        public void UnequipItemInSlot(HandEquipmentSlot equipmentSlot)
        {
            playerInventory.UnequipWeapon(equipmentSlot.equipmentSlotID);
            equipmentSlot.UnequipItem();
        }
    }
}