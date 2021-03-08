using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class HandEquipmentSlot : MenuButton
    {
        EquipmentMenuManager equipmentMenuManager;

        public Image icon;
        WeaponItem weapon;

        public EquipmentSlotEnum equipmentSlotID;

        protected override void Awake()
        {
            equipmentMenuManager = FindObjectOfType<EquipmentMenuManager>();
            base.Awake();
        }
        public void AddItem(WeaponItem newWeapon)
        {
            if (newWeapon == null) return;
            weapon = newWeapon;
            icon.sprite = weapon.itemIcon;
            icon.enabled = true;
        }

        public void UnequipItem()
        {
            weapon = null;
            icon.sprite = null;
            icon.enabled = false;
        }

        public override void SelectThisMenuItem()
        {
            equipmentMenuManager.SetSelectedEquipmentSlot(this);
        }

        public void EquipItemInThisSlot()
        {
            equipmentMenuManager.EquipItemInSlot(this);
        }
    }
}