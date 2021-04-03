using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class ConsumableEquipmentSlot : EquipmentSlot
    {
        ConsumableItem consumable;

        public void AddItem(ConsumableItem newConsumable)
        {
            if (newConsumable == null) return;

            consumable = newConsumable;
            icon.sprite = consumable.icon;
            icon.enabled = true;
        }

        public override void UnequipItem()
        {
            consumable = null;
            base.UnequipItem();
        }
    }
}
