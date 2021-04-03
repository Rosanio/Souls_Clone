namespace SoulsLikeTutorial
{
    public class ConsumablesInventoryPanel : InventoryPanel
    {
        public PlayerInventory playerInventory;

        protected override void AddItem(int index)
        {
            ((ConsumableInventorySlot)inventorySlots[index]).AddItem(playerInventory.consumablesInInventory[index]);
        }

        protected override int NumberOfItemsInInventory()
        {
            return playerInventory.consumablesInInventory.Count;
        }
    }
}
