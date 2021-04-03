using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{

    public class WeaponsInventoryPanel : InventoryPanel
    {
        public PlayerInventory playerInventory;

        protected override void AddItem(int index)
        {
            ((WeaponInventorySlot)inventorySlots[index]).AddItem(playerInventory.weaponsInInventory[index]);
        }

        protected override int NumberOfItemsInInventory()
        {
            return playerInventory.weaponsInInventory.Count;
        }
    }
}
