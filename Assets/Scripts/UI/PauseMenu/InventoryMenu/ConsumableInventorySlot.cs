using UnityEngine;

namespace SoulsLikeTutorial
{
    public class ConsumableInventorySlot : InventorySlot
    {
        [HideInInspector] public ConsumableItem consumable;

        public void AddItem(ConsumableItem newItem)
        {
            consumable = newItem;
            base.AddItem(newItem);
        }

        public override void ClearInventorySlot()
        {
            consumable = null;
            base.ClearInventorySlot();
        }
    }
}
