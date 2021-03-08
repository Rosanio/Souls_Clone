using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class SelectMenuButton : MenuButton
    {
        public SelectMenuEnum selectMenuItemID;

        SelectMenuManager selectMenuManager;

        protected override void Awake()
        {
            selectMenuManager = FindObjectOfType<SelectMenuManager>();
            base.Awake();
        }

        public override void SelectThisMenuItem()
        {
            selectMenuManager.SetSelectedButton(this);
        }

        public void OpenMenu()
        {
            selectMenuManager.SetSelectedButton(this);
            selectMenuManager.OpenSelectedMenu();
        }
    }
}
