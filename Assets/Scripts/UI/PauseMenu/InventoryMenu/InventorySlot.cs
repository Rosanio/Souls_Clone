using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class InventorySlot : MenuButton
    {
        protected InventoryMenuManager inventoryMenuManager;

        public Image icon;

        protected void Awake()
        {
            inventoryMenuManager = FindObjectOfType<InventoryMenuManager>();
        }

        public void AddItem(Item item)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
            gameObject.SetActive(true);
        }

        public virtual void ClearInventorySlot()
        {
            icon.sprite = null;
            icon.enabled = false;
        }

        public override void SelectThisMenuItem()
        {
            if (!menuButton.interactable) return;
            inventoryMenuManager.SetSelectedButton(this);
        }

        public void ConfirmThisSlot()
        {
            inventoryMenuManager.OnConfirmInventorySlot(this);
        }
    }
}
