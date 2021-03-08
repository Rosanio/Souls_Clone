using System;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class SelectMenuManager : MenuManager
    {
        public SelectMenuButton[] selectMenuButtons;

        public SelectMenuEnum currentlySelectedMenuItemID;

        protected override void Awake()
        {
            base.Awake();
            selectMenuButtons = GetComponentsInChildren<SelectMenuButton>();
            selectedButtonColor = "#ffffff";
            unselectedButtonColor = "#878787";
        }

        public override void OnConfirm()
        {
            OpenSelectedMenu();
        }

        public override void OnBack()
        {
            uiManager.ExitPauseMenu();
        }

        public override void OnOption1()
        {
            // Do nothing
        }

        public void SetSelectedButton(SelectMenuButton menuButton)
        {
            currentlySelectedMenuItemID = menuButton.selectMenuItemID;
            base.SetSelectedButton(menuButton);
        }

        public void OpenSelectedMenu()
        {
            switch (currentlySelectedMenuItemID)
            {
                case SelectMenuEnum.Equipment:
                    uiManager.OpenEquipmentWindow();
                    break;
                case SelectMenuEnum.Inventory:
                    uiManager.OpenInventoryWindow();
                    break;
            }
        }
    }
}
