using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class PlayerInventory : MonoBehaviour
    {
        PlayerWeaponSlotManager weaponSlotManager;

        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;

        public WeaponItem unarmedWeapon;

        public WeaponItem[] weaponsInRightHandSlots = new WeaponItem[2];
        public WeaponItem[] weaponsInLeftHandSlots = new WeaponItem[2];

        public int currentRightWeaponIndex = 0;
        public int currentLeftWeaponIndex = 0;

        public List<WeaponItem> weaponsInInventory;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<PlayerWeaponSlotManager>();
        }

        private void Start()
        {
            rightWeapon = weaponsInRightHandSlots[0] == null ? unarmedWeapon : weaponsInRightHandSlots[0];
            leftWeapon = weaponsInLeftHandSlots[0] ==  null ? unarmedWeapon : weaponsInLeftHandSlots[0];

            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        }

        public void ChangeRightWeapon()
        {
            SelectNextRightWeapon();
            if (rightWeapon == unarmedWeapon)
            {
                SelectNextRightWeapon();
            }
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
        }

        private void SelectNextRightWeapon()
        {
            currentRightWeaponIndex++;
            if (currentRightWeaponIndex > weaponsInRightHandSlots.Length - 1)
            {
                currentRightWeaponIndex = 0;
            }
            rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex] != null ?
                              weaponsInRightHandSlots[currentRightWeaponIndex] : unarmedWeapon;
        }

        public void ChangeLeftWeapon()
        {
            SelectNextLeftWeapon();
            if (leftWeapon == unarmedWeapon)
            {
                SelectNextLeftWeapon();
            }
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        }

        private void SelectNextLeftWeapon()
        {
            currentLeftWeaponIndex++;
            if (currentLeftWeaponIndex > weaponsInLeftHandSlots.Length - 1)
            {
                currentLeftWeaponIndex = 0;
            }
            leftWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex] != null ?
                              weaponsInLeftHandSlots[currentLeftWeaponIndex] : unarmedWeapon;
        }


        public void UpdateWeaponSlots()
        {
            leftWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex] != null ? weaponsInLeftHandSlots[currentLeftWeaponIndex] : unarmedWeapon;
            rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex] != null ? weaponsInRightHandSlots[currentRightWeaponIndex] : unarmedWeapon;
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        }

        public WeaponItem GetEquippedWeapon(EquipmentSlotEnum equipmentSlotID)
        {
            Tuple<WeaponItem[], int> equipmentSlot = GetEquippedWeaponSlot(equipmentSlotID);
            return equipmentSlot.Item1[equipmentSlot.Item2];
        }

        public Tuple<WeaponItem[], int> GetEquippedWeaponSlot(EquipmentSlotEnum equipmentSlotID)
        {
            switch (equipmentSlotID)
            {
                case EquipmentSlotEnum.RightHandSlot01:
                    return new Tuple<WeaponItem[], int>(weaponsInRightHandSlots, 0);
                case EquipmentSlotEnum.RightHandSlot02:
                    return new Tuple<WeaponItem[], int>(weaponsInRightHandSlots, 1);
                case EquipmentSlotEnum.RightHandSlot03:
                    return new Tuple<WeaponItem[], int>(weaponsInRightHandSlots, 2);
                case EquipmentSlotEnum.LeftHandSlot01:
                    return new Tuple<WeaponItem[], int>(weaponsInLeftHandSlots, 0);
                case EquipmentSlotEnum.LeftHandSlot02:
                    return new Tuple<WeaponItem[], int>(weaponsInLeftHandSlots, 1);
                case EquipmentSlotEnum.LeftHandSlot03:
                    return new Tuple<WeaponItem[], int>(weaponsInLeftHandSlots, 2);
                default:
                    return null;
            }
        }

        public void EquipWeapon(WeaponItem weapon, EquipmentSlotEnum equipmentSlotID)
        {
            Tuple<WeaponItem[], int> equipmentSlot = GetEquippedWeaponSlot(equipmentSlotID);
            if (equipmentSlot.Item1[equipmentSlot.Item2] != null)
                weaponsInInventory.Add(equipmentSlot.Item1[equipmentSlot.Item2]);

            equipmentSlot.Item1[equipmentSlot.Item2] = weapon;
            weaponsInInventory.Remove(weapon);

            UpdateWeaponSlots();
        }

        public void UnequipWeapon(EquipmentSlotEnum equipmentSlotID)
        {
            Tuple<WeaponItem[], int> equipmentSlot = GetEquippedWeaponSlot(equipmentSlotID);
            if (equipmentSlot.Item1[equipmentSlot.Item2] != null)
                weaponsInInventory.Add(equipmentSlot.Item1[equipmentSlot.Item2]);
            equipmentSlot.Item1[equipmentSlot.Item2] = null;

            UpdateWeaponSlots();
        }

        public void PickUpItem(Item item)
        {
            if (item is WeaponItem)
            {
                weaponsInInventory.Add((WeaponItem)item);
            }
        }
    }
}
