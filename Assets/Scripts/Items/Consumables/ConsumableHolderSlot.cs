using UnityEngine;

namespace SoulsLikeTutorial
{
    public class ConsumableHolderSlot : HolderSlot
    {
        public ConsumableItem currentConsumable;

        public void LoadConsumableModel(ConsumableItem consumable)
        {
            LoadItemModel(consumable);
            currentConsumable = consumable;
        }
    }
}
