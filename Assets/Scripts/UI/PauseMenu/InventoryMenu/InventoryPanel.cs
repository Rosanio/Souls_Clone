using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public abstract class InventoryPanel : Panel
    {
        public GameObject inventorySlotPrefab;

        protected List<InventorySlot> inventorySlots = new List<InventorySlot>();
        private List<InventorySlot> enabledInventorySlots = new List<InventorySlot>();

        private int gridColumnCount = 4;

        protected override string selectedButtonColor
        {
            get { return "#191919"; }
        }

        protected override string unselectedButtonColor
        {
            get { return "#5A5A5A"; }
        }

        public void Open(int minimmumInventorySlots)
        {
            SetUpInventorySlots(minimmumInventorySlots);
            base.Open();
        }

        public void SetUpInventorySlots(int minimumInventorySlots)
        {
            InitializeInventorySlots(minimumInventorySlots);
            InitializeButtonNavigation();
            SetDefaultButton();
        }

        public InventorySlot GetSelectedInventorySlot()
        {
            return (InventorySlot)currentlySelectedButton;
        }

        private void InitializeInventorySlots(int minimumInventorySlots)
        {
            enabledInventorySlots.Clear();
            inventorySlots = Utils.GetListOfComponentsInChildren<InventorySlot>(this);
            int inventorySlotsCount = Mathf.Max(minimumInventorySlots, NumberOfItemsInInventory());
            for (int i = 0; i < inventorySlotsCount; i++)
            {
                if (i >= inventorySlots.Count)
                {
                    GameObject newSlotGameObject = Instantiate(inventorySlotPrefab, transform);
                    inventorySlots.Add(newSlotGameObject.GetComponent<InventorySlot>());
                }
                if (i < NumberOfItemsInInventory())
                {
                    inventorySlots[i].SetEnabled();
                    AddItem(i);
                    enabledInventorySlots.Add(inventorySlots[i]);
                }
                else
                {
                    inventorySlots[i].SetDisabled();
                    inventorySlots[i].ClearInventorySlot();
                }
            }
            for (int i = inventorySlots.Count - 1; i >= inventorySlotsCount; i--)
            {
                inventorySlots[i].ClearInventorySlot();
                Destroy(inventorySlots[i].gameObject);
                inventorySlots.RemoveAt(i);
                if (menuButtons.Count - 1 >= i)
                    menuButtons.RemoveAt(i);
            }
        }

        private void InitializeButtonNavigation()
        {
            for (int i = 0; i < enabledInventorySlots.Count; i++)
            {
                SetUpButton(i);
                SetDownButton(i);
                SetLeftButton(i);
                SetRightButton(i);
            }
        }

        protected void SetDefaultButton()
        {
            if (enabledInventorySlots.Count > 0)
                defaultMenuButton = enabledInventorySlots[0];
        }

        protected abstract void AddItem(int index);

        protected abstract int NumberOfItemsInInventory();

        private void SetUpButton(int currentSlotIndex)
        {
            int columnIndex = currentSlotIndex % gridColumnCount;
            if (currentSlotIndex > columnIndex)
            {
                enabledInventorySlots[currentSlotIndex].upButton = enabledInventorySlots[currentSlotIndex - gridColumnCount];
            }
            else
            {
                int lastInColumnIndex = GetLastIndexInColumn(columnIndex);
                enabledInventorySlots[currentSlotIndex].upButton = enabledInventorySlots[lastInColumnIndex];
            }
        }

        private void SetDownButton(int currentSlotIndex)
        {
            int columnIndex = currentSlotIndex % gridColumnCount;
            int lastInColumnIndex = GetLastIndexInColumn(columnIndex);

            if (currentSlotIndex < lastInColumnIndex)
                enabledInventorySlots[currentSlotIndex].downButton = enabledInventorySlots[currentSlotIndex + gridColumnCount];
            else
                enabledInventorySlots[currentSlotIndex].downButton = enabledInventorySlots[columnIndex];
        }

        private void SetLeftButton(int currentSlotIndex)
        {
            if (currentSlotIndex == 0)
                enabledInventorySlots[currentSlotIndex].leftButton = enabledInventorySlots[enabledInventorySlots.Count - 1];
            else
                enabledInventorySlots[currentSlotIndex].leftButton = enabledInventorySlots[currentSlotIndex - 1];
        }

        private void SetRightButton(int currentSlotIndex)
        {
            if (currentSlotIndex == enabledInventorySlots.Count - 1)
                enabledInventorySlots[currentSlotIndex].rightButton = enabledInventorySlots[0];
            else
                enabledInventorySlots[currentSlotIndex].rightButton = enabledInventorySlots[currentSlotIndex + 1];
        }

        private int GetLastIndexInColumn(int columnIndex)
        {
            int lastIndexInColumn = enabledInventorySlots.Count - ((enabledInventorySlots.Count - columnIndex) % gridColumnCount);
            if (lastIndexInColumn == enabledInventorySlots.Count)
                lastIndexInColumn -= gridColumnCount;
            return lastIndexInColumn;
        }
    }
}
