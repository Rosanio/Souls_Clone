using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class QuickSlotsUI : MonoBehaviour
    {
        public Image leftWeaponIcon;
        public Image rightWeaponIcon;

        public void UpdateWeaponQuickSlotsUI(bool isLeft, WeaponItem weapon)
        {
            Image quickSlotImage = isLeft ? leftWeaponIcon : rightWeaponIcon;
            quickSlotImage.sprite = weapon.itemIcon;
            quickSlotImage.enabled = weapon.itemIcon != null;
        }
    }
}
