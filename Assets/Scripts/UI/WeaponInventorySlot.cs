using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class WeaponInventorySlot : MenuButton
    {
        InventoryMenuManager inventoryMenuManager;

        public Image icon;
        
        [HideInInspector]
        public WeaponItem item;

        protected override void Awake()
        {
            base.Awake();
            inventoryMenuManager = FindObjectOfType<InventoryMenuManager>();
        }

        public void AddItem(WeaponItem newItem)
        {
            item = newItem;
            icon.sprite = item.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);
        }

        public void ClearInventorySlot()
        {
            item = null;
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