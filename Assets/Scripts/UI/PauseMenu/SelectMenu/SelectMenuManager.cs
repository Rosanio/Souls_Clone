namespace SoulsLikeTutorial
{
    public class SelectMenuManager : MenuManager
    {
        public SelectMenuButton[] selectMenuButtons;

        private SelectMenuPanel selectMenuPanel;

        protected override void Awake()
        {
            base.Awake();
            selectMenuButtons = GetComponentsInChildren<SelectMenuButton>();
            selectMenuPanel = GetComponent<SelectMenuPanel>();
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

        protected override Panel GetPanel()
        {
            return selectMenuPanel;
        }

        public override void ResetToDefault()
        {
            if (selectMenuPanel != null)
                selectMenuPanel.ResetToDefault();
        }

        public void SetSelectedButton(SelectMenuButton menuButton)
        {
            selectMenuPanel.SetSelectedButton(menuButton);
        }

        public void OpenSelectedMenu()
        {
            SelectMenuButton selectedButton = (SelectMenuButton)selectMenuPanel.GetCurrentlySelectedButton();
            switch (selectedButton.selectMenuItemID)
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
