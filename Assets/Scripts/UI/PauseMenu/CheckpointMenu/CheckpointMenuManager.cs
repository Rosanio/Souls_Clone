using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class CheckpointMenuManager : MenuManager
    {
        private CheckpointPanel checkpointPanel;

        protected override void Awake()
        {
            base.Awake();
            checkpointPanel = GetComponentInChildren<CheckpointPanel>();
        }

        protected override Panel GetPanel()
        {
            return checkpointPanel;
        }

        public override void OnConfirm()
        {
            Confirm((CheckpointMenuButton)checkpointPanel.GetCurrentlySelectedButton());
        }

        public override void OnBack()
        {
            throw new System.NotImplementedException();
        }

        public override void OnOption1()
        {
            // do nothing
        }

        public override void Close()
        {
            base.Close();
        }

        public void SetSelectedButton(CheckpointMenuButton button)
        {
            checkpointPanel.SetSelectedButton(button);
        }

        public void Confirm(CheckpointMenuButton button)
        {
            switch(button.checkpointMenuItem)
            {
                case CheckpointMenuItemEnum.Leave:
                    uiManager.ExitCheckpointMenu();
                    break;
            }
        }
    }
}
