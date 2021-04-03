using UnityEngine;

namespace SoulsLikeTutorial
{
    public class ConsumableSlotManager : MonoBehaviour
    {
        QuickSlotsUI quickSlotsUI;
        ConsumableHolderSlot consumableSlot;
        PlayerAnimatorHandler animator;
        PlayerWeaponSlotManager weaponSlotManager;

        private void Awake()
        {
            quickSlotsUI = FindObjectOfType<QuickSlotsUI>();
            consumableSlot = GetComponentInChildren<ConsumableHolderSlot>();
            animator = GetComponent<PlayerAnimatorHandler>();
            weaponSlotManager = GetComponent<PlayerWeaponSlotManager>();
        }

        public void LoadConsumableOnQuickSlot(ConsumableItem consumable)
        {
            quickSlotsUI.UpdateConsumableUI(consumable);
        }

        public void UseConsumable(ConsumableItem consumable)
        {
            weaponSlotManager.UnloadWeaponOnSlot(WeaponSlotID.RightHandSlot);
            consumableSlot.LoadConsumableModel(consumable);
            animator.PlayTargetAnimation(consumable.useAnimation, true);
        }

        public void TriggerConsumableEffect()
        {
            Consumable consumable = consumableSlot.itemModel.GetComponent<Consumable>();
            consumable.Use();
        }

        public void OnConsumableAnimationEnd()
        {
            consumableSlot.UnloadItemModelAndDestroy();
            weaponSlotManager.LoadRightWeapon();
        }
    }
}
