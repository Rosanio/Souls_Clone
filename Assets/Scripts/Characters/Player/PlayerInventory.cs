using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class PlayerInventory : MonoBehaviour
    {
        PlayerWeaponSlotManager weaponSlotManager;
        ConsumableSlotManager consumableSlotManager;

        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;
        public ConsumableItem consumable;

        public WeaponItem unarmedWeapon;

        public WeaponItem[] weaponsInRightHandSlots = new WeaponItem[2];
        public WeaponItem[] weaponsInLeftHandSlots = new WeaponItem[2];

        public ConsumableItem[] equippedConsumables = new ConsumableItem[8];

        public int currentRightWeaponIndex = 0;
        public int currentLeftWeaponIndex = 0;
        public int currentConsumableIndex = 0;

        public List<WeaponItem> weaponsInInventory;
        public List<ConsumableItem> consumablesInInventory;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<PlayerWeaponSlotManager>();
            consumableSlotManager = GetComponentInChildren<ConsumableSlotManager>();
        }

        private void Start()
        {
            rightWeapon = weaponsInRightHandSlots[0] == null ? unarmedWeapon : weaponsInRightHandSlots[0];
            leftWeapon = weaponsInLeftHandSlots[0] ==  null ? unarmedWeapon : weaponsInLeftHandSlots[0];

            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, WeaponSlotID.RightHandSlot);
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, WeaponSlotID.LeftHandSlot);
        }

        public void ChangeRightWeapon()
        {
            SelectNextRightWeapon();
            if (rightWeapon == unarmedWeapon)
            {
                SelectNextRightWeapon();
            }
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, WeaponSlotID.RightHandSlot);
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
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, WeaponSlotID.LeftHandSlot);
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


        private void UpdateWeaponSlots()
        {
            leftWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex] != null ? weaponsInLeftHandSlots[currentLeftWeaponIndex] : unarmedWeapon;
            rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex] != null ? weaponsInRightHandSlots[currentRightWeaponIndex] : unarmedWeapon;
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, WeaponSlotID.RightHandSlot);
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, WeaponSlotID.LeftHandSlot);
        }

        private void UpdateConsumableSlots()
        {
            consumable = equippedConsumables[currentConsumableIndex];
            consumableSlotManager.LoadConsumableOnQuickSlot(consumable);
        }

        public WeaponItem GetEquippedWeapon(EquipmentSlotEnum equipmentSlotID)
        {
            switch (equipmentSlotID)
            {
                case EquipmentSlotEnum.RightHandSlot01:
                    return weaponsInRightHandSlots[0];
                case EquipmentSlotEnum.RightHandSlot02:
                    return weaponsInRightHandSlots[1];
                case EquipmentSlotEnum.RightHandSlot03:
                    return weaponsInRightHandSlots[2];
                case EquipmentSlotEnum.LeftHandSlot01:
                    return weaponsInLeftHandSlots[0];
                case EquipmentSlotEnum.LeftHandSlot02:
                    return weaponsInLeftHandSlots[1];
                case EquipmentSlotEnum.LeftHandSlot03:
                    return weaponsInLeftHandSlots[2];
                default:
                    return null;
            }
        }

        public ConsumableItem GetEquippedConsumable(EquipmentSlotEnum equipmentSlotID)
        {
            switch(equipmentSlotID)
            {
                case EquipmentSlotEnum.ConsumableSlot01:
                    return equippedConsumables[0];
                case EquipmentSlotEnum.ConsumableSlot02:
                    return equippedConsumables[1];
                case EquipmentSlotEnum.ConsumableSlot03:
                    return equippedConsumables[2];
                case EquipmentSlotEnum.ConsumableSlot04:
                    return equippedConsumables[3];
                case EquipmentSlotEnum.ConsumableSlot05:
                    return equippedConsumables[4];
                case EquipmentSlotEnum.ConsumableSlot06:
                    return equippedConsumables[5];
                case EquipmentSlotEnum.ConsumableSlot07:
                    return equippedConsumables[6];
                case EquipmentSlotEnum.ConsumableSlot08:
                    return equippedConsumables[7];
                default:
                    return null;
            }
        }

        public void EquipWeapon(WeaponItem weapon, EquipmentSlotEnum equipmentSlotID)
        {
            MoveWeaponBackToInventory(equipmentSlotID);
            SetWeaponInSlot(weapon, equipmentSlotID);

            UpdateWeaponSlots();
        }

        public void UnequipWeapon(EquipmentSlotEnum equipmentSlotID)
        {
            MoveWeaponBackToInventory(equipmentSlotID);
            SetWeaponInSlot(null, equipmentSlotID);

            UpdateWeaponSlots();
        }

        public void EquipConsumable(ConsumableItem consumable, EquipmentSlotEnum equipmentSlotID)
        {
            MoveConsumableBackToInventory(equipmentSlotID);
            SetConsumableInSlot(consumable, equipmentSlotID);

            UpdateConsumableSlots();
        }

        public void UnequipConsumable(EquipmentSlotEnum equipmentSlotID)
        {
            MoveConsumableBackToInventory(equipmentSlotID);
            SetConsumableInSlot(null, equipmentSlotID);

            UpdateConsumableSlots();
        }

        public void PickUpItem(Item item)
        {
            if (item is WeaponItem weapon)
                weaponsInInventory.Add(weapon);
            else if (item is ConsumableItem consumable)
                consumablesInInventory.Add(consumable);
        }

        private void MoveWeaponBackToInventory(EquipmentSlotEnum equipmentSlotID)
        {
            WeaponItem equippedWeapon = GetEquippedWeapon(equipmentSlotID);
            if (equippedWeapon != null)
                weaponsInInventory.Add(equippedWeapon);
        }

        private void MoveConsumableBackToInventory(EquipmentSlotEnum equipmentSlotID)
        {
            ConsumableItem equippedConsumable = GetEquippedConsumable(equipmentSlotID);
            if (equippedConsumable != null)
                consumablesInInventory.Add(equippedConsumable);
        }

        private void SetWeaponInSlot(WeaponItem weapon, EquipmentSlotEnum equipmentSlotID)
        {
            switch (equipmentSlotID)
            {
                case EquipmentSlotEnum.RightHandSlot01:
                    weaponsInRightHandSlots[0] = weapon;
                    break;
                case EquipmentSlotEnum.RightHandSlot02:
                    weaponsInRightHandSlots[1] = weapon;
                    break;
                case EquipmentSlotEnum.RightHandSlot03:
                    weaponsInRightHandSlots[2] = weapon;
                    break;
                case EquipmentSlotEnum.LeftHandSlot01:
                    weaponsInLeftHandSlots[0] = weapon;
                    break;
                case EquipmentSlotEnum.LeftHandSlot02:
                    weaponsInLeftHandSlots[1] = weapon;
                    break;
                case EquipmentSlotEnum.LeftHandSlot03:
                    weaponsInLeftHandSlots[2] = weapon;
                    break;
            }

            if (weapon != null)
                weaponsInInventory.Remove(weapon);
        }

        private void SetConsumableInSlot(ConsumableItem consumable, EquipmentSlotEnum equipmentSlotID)
        {
            switch (equipmentSlotID)
            {
                case EquipmentSlotEnum.ConsumableSlot01:
                    equippedConsumables[0] = consumable;
                    break;
                case EquipmentSlotEnum.ConsumableSlot02:
                    equippedConsumables[1] = consumable;
                    break;
                case EquipmentSlotEnum.ConsumableSlot03:
                    equippedConsumables[2] = consumable;
                    break;
                case EquipmentSlotEnum.ConsumableSlot04:
                    equippedConsumables[3] = consumable;
                    break;
                case EquipmentSlotEnum.ConsumableSlot05:
                    equippedConsumables[4] = consumable;
                    break;
                case EquipmentSlotEnum.ConsumableSlot06:
                    equippedConsumables[5] = consumable;
                    break;
                case EquipmentSlotEnum.ConsumableSlot07:
                    equippedConsumables[6] = consumable;
                    break;
                case EquipmentSlotEnum.ConsumableSlot08:
                    equippedConsumables[7] = consumable;
                    break;
            }

            if (consumable != null)
                consumablesInInventory.Remove(consumable);
        }
    }
}
