using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class Panel : MonoBehaviour
    {
        public MenuButton defaultMenuButton;
        protected MenuButton currentlySelectedButton;

        protected List<MenuButton> menuButtons = new List<MenuButton>();

        protected virtual string selectedButtonColor {
            get
            { return "#ffffff"; }
        }

        protected virtual string unselectedButtonColor
        {
            get { return "#ffffff"; }
        }

        protected virtual void Awake()
        {
            menuButtons = Utils.GetListOfComponentsInChildren<MenuButton>(this);
        }

        public virtual void Open()
        {
            SelectDefaultButton();
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnNavigateRight()
        {
            if (currentlySelectedButton != null && currentlySelectedButton.rightButton != null)
                currentlySelectedButton.rightButton.SelectThisMenuItem();
        }
        public virtual void OnNavigateLeft()
        {
            if (currentlySelectedButton != null && currentlySelectedButton.leftButton != null)
                currentlySelectedButton.leftButton.SelectThisMenuItem();
        }

        public virtual void OnNavigateUp()
        {
            if (currentlySelectedButton != null && currentlySelectedButton.upButton != null)
                currentlySelectedButton.upButton.SelectThisMenuItem();
        }

        public virtual void OnNavigateDown()
        {
            if (currentlySelectedButton != null && currentlySelectedButton.downButton != null)
                currentlySelectedButton.downButton.SelectThisMenuItem();
        }

        public virtual void ResetToDefault()
        {
            currentlySelectedButton = null;
            ResetButtonColors();
        }

        public virtual void SelectDefaultButton()
        {
            if (currentlySelectedButton != null)
                SetSelectedButton(currentlySelectedButton);
            else if (defaultMenuButton != null)
                SetSelectedButton(defaultMenuButton);
        }

        public void SetSelectedButton(MenuButton button)
        {
            currentlySelectedButton = button;
            SetAllButtonColorsToUnselected();
            button.SetButtonColor(selectedButtonColor);
        }

        public void SetAllButtonColorsToUnselected()
        {
            foreach (MenuButton menuButton in menuButtons)
            {
                menuButton.SetButtonColor(unselectedButtonColor);
            }
        }

        public void ResetButtonColors()
        {
            // Null check needed in case this method is called before the menu manager
            // is awake.
            if (menuButtons == null) return;

            foreach (MenuButton menuButton in menuButtons)
            {
                if (menuButton == defaultMenuButton)
                    menuButton.SetButtonColor(selectedButtonColor);
                else
                    menuButton.SetButtonColor(unselectedButtonColor);
            }
        }

        public MenuButton GetCurrentlySelectedButton()
        {
            return currentlySelectedButton;
        }
    }
}
