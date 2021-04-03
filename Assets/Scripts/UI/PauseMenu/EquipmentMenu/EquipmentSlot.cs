using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public abstract class EquipmentSlot : MenuButton
    {
        public EquipmentSlotEnum equipmentSlotID;
        public Image icon;

        protected EquipmentMenuManager equipmentMenuManager;

        protected void Awake()
        {
            equipmentMenuManager = FindObjectOfType<EquipmentMenuManager>();
        }

        public override void SelectThisMenuItem()
        {
            equipmentMenuManager.SetSelectedEquipmentSlot(this);
        }

        public virtual void UnequipItem()
        {
            icon.sprite = null;
            icon.enabled = false;
        }
    }
}
