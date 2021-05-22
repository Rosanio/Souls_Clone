using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class CheckpointMenuButton : MenuButton
    {
        public CheckpointMenuItemEnum checkpointMenuItem;

        private CheckpointMenuManager checkpointMenuManager;

        private void Awake()
        {
            checkpointMenuManager = FindObjectOfType<CheckpointMenuManager>();
        }

        public override void SelectThisMenuItem()
        {
            checkpointMenuManager.SetSelectedButton(this);
        }

        public void ConfirmThisButton()
        {
            checkpointMenuManager.Confirm(this);
        }
    }
}
