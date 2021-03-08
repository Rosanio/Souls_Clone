using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public abstract class MenuButton : MonoBehaviour
    {
        public MenuButton leftButton;
        public MenuButton rightButton;
        public MenuButton upButton;
        public MenuButton downButton;

        protected Button menuButton;

        protected virtual void Awake()
        {
            menuButton = GetComponent<Button>();
        }

        public abstract void SelectThisMenuItem();

        public void SetButtonColor(string color)
        {
            Color highlightedColor;
            ColorUtility.TryParseHtmlString(color, out highlightedColor);
            var colors = menuButton.colors;
            colors.normalColor = highlightedColor;
            colors.highlightedColor = highlightedColor;
            colors.selectedColor = highlightedColor;
            menuButton.colors = colors;
        }

        public void SetEnabled()
        {
            menuButton.interactable = true;
        }

        public void SetDisabled()
        {
            menuButton.interactable = false;
        }
    }
}
