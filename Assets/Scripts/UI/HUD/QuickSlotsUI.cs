using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class QuickSlotsUI : MonoBehaviour
    {
        public Image leftWeaponIcon;
        public Image rightWeaponIcon;
        public Image consumableIcon;

        public void UpdateWeaponQuickSlotsUI(bool isLeft, WeaponItem weapon)
        {
            Image quickSlotImage = isLeft ? leftWeaponIcon : rightWeaponIcon;
            quickSlotImage.sprite = weapon.icon;
            quickSlotImage.enabled = weapon.icon != null;
        }

        public void UpdateConsumableUI(ConsumableItem consumable)
        {
            if (consumable == null)
            {
                consumableIcon.sprite = null;
                consumableIcon.enabled = false;
            }
            else
            {
                consumableIcon.sprite = consumable.icon;
                consumableIcon.enabled = consumable.icon != null;
            }
        }
    }
}
