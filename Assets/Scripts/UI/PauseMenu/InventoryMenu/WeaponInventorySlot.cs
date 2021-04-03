using UnityEngine;

namespace SoulsLikeTutorial
{
    public class WeaponInventorySlot : InventorySlot
    {
        [HideInInspector]
        public WeaponItem weapon;

        public void AddItem(WeaponItem newItem)
        {
            weapon = newItem;
            base.AddItem(newItem);
        }

        public override void ClearInventorySlot()
        {
            weapon = null;
            base.ClearInventorySlot();
        }
    }
}