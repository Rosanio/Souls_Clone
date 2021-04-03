using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class InventoryTabButton : MonoBehaviour
    {
        public Image icon;
        public InventoryPanel panel;

        public InventoryTabButton leftTab;
        public InventoryTabButton rightTab;

        public void SetIconColor(string color)
        {
            Color newColor;
            ColorUtility.TryParseHtmlString(color, out newColor);
            icon.color = newColor;
        }
    }
}

