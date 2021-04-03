using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class HandEquipmentSlot : EquipmentSlot
    {
        WeaponItem weapon;

        public void AddItem(WeaponItem newWeapon)
        {
            if (newWeapon == null) return;

            weapon = newWeapon;
            icon.sprite = weapon.icon;
            icon.enabled = true;
        }

        public override void UnequipItem()
        {
            weapon = null;
            base.UnequipItem();
        }

        public void EquipItemInThisSlot()
        {
            equipmentMenuManager.EquipItemInSlot(this);
        }
    }
}