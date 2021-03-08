using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public abstract class MenuManager : MonoBehaviour
    {
        protected UIManager uiManager;
        public MenuButton defaultMenuButton;
        protected MenuButton currentlySelectedButton;

        protected MenuButton[] menuButtons;

        protected string selectedButtonColor;
        protected string unselectedButtonColor;

        protected virtual void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
            menuButtons = GetComponentsInChildren<MenuButton>();
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
            SelectDefaultButton();
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }

        public abstract void OnConfirm();

        public abstract void OnBack();

        public abstract void OnOption1();

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
                currentlySelectedButton.SelectThisMenuItem();
            else if (defaultMenuButton != null)
                defaultMenuButton.SelectThisMenuItem();
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
    }
}
