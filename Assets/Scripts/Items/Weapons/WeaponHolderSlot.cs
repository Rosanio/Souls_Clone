using UnityEngine;

namespace SoulsLikeTutorial
{
    public class WeaponHolderSlot : HolderSlot
    {
        public WeaponSlotID slotID;

        public WeaponItem currentWeapon;

        public void LoadWeaponModel(WeaponItem weaponItem)
        {
            UnloadItemModelAndDestroy();

            if (weaponItem == null)
            {
                UnloadItemModel();
                return;
            }

            LoadItemModel(weaponItem);
        }
    }

}
