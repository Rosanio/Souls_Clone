using System;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class PlayerWeaponSlotManager : WeaponSlotManager
    {
        public WeaponItem attackingWeapon;

        WeaponHolderSlot backSlot;

        Animator animator;

        QuickSlotsUI quickSlotsUI;

        PlayerManager playerManager;
        PlayerStats playerStats;
        InputHandler InputHandler;
        PlayerInventory playerInventory;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            quickSlotsUI = FindObjectOfType<QuickSlotsUI>();
            playerStats = GetComponentInParent<PlayerStats>();
            InputHandler = GetComponentInParent<InputHandler>();
            playerManager = GetComponentInParent<PlayerManager>();
            playerInventory = GetComponentInParent<PlayerInventory>();

            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.slotID == WeaponSlotID.LeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if (weaponSlot.slotID == WeaponSlotID.RightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
                else if (weaponSlot.slotID == WeaponSlotID.BackSlot)
                {
                    backSlot = weaponSlot;
                }
            }
        }

        public void LoadRightWeapon()
        {
            LoadWeaponOnSlot(playerInventory.rightWeapon, WeaponSlotID.RightHandSlot);
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem, WeaponSlotID slotID)
        {
            WeaponHolderSlot slot = GetWeaponHolderSlot(slotID);
            if (slot.slotID == WeaponSlotID.LeftHandSlot)
            {
                leftHandSlot.currentWeapon = weaponItem;
                leftHandSlot.LoadWeaponModel(weaponItem);
                LoadLeftWeaponDamageCollider();
                quickSlotsUI.UpdateWeaponQuickSlotsUI(true, weaponItem);

                if (weaponItem != null && weaponItem.Left_Hand_Idle != null)
                {
                    animator.CrossFade(weaponItem.Left_Hand_Idle, 0.2f);
                }
                else
                {
                    animator.CrossFade("Left Arm Empty", 0.2f);
                }
            }
            else
            {
                if (InputHandler.twoHandFlag)
                {
                    backSlot.LoadWeaponModel(leftHandSlot.currentWeapon);
                    leftHandSlot.UnloadItemModelAndDestroy();
                    animator.CrossFade(weaponItem.Two_Hand_Idle, 0.2f);
                }
                else
                {
                    backSlot.UnloadItemModelAndDestroy();
                    animator.CrossFade("Both Arms Empty", 0.2f);
                    if (weaponItem != null && weaponItem.Right_Hand_Idle != null)
                    {
                        animator.CrossFade(weaponItem.Right_Hand_Idle, 0.2f);
                    }
                    else
                    {
                        animator.CrossFade("Right Arm Empty", 0.2f);
                    }
                }

                rightHandSlot.currentWeapon = weaponItem;
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponDamageCollider();
                quickSlotsUI.UpdateWeaponQuickSlotsUI(false, weaponItem);
            }
        }

        public void UnloadWeaponOnSlot(WeaponSlotID slotID)
        {
            GetWeaponHolderSlot(slotID).UnloadItemModel();
        }

        #region Handle Weapon's Damage Collider

        private void LoadLeftWeaponDamageCollider()
        {
            leftHandDamageCollider = leftHandSlot.itemModel.GetComponentInChildren<DamageCollider>();
        }

        private void LoadRightWeaponDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.itemModel.GetComponentInChildren<DamageCollider>();
        }

        public override void OpenDamageCollider()
        {
            if (playerStats.isStaggered || playerStats.isDead) return;

            if (playerManager.isUsingRightHand)
                rightHandDamageCollider.EnableDamageCollider();
            else if (playerManager.isUsingLeftHand)
                leftHandDamageCollider.EnableDamageCollider();
        }

        public override void CloseDamageCollider()
        {
            if (rightHandDamageCollider != null)
                rightHandDamageCollider.DisableDamageCollider();
            if (leftHandDamageCollider != null)
                leftHandDamageCollider.DisableDamageCollider();
        }

        #endregion

        #region Handle Weapon's Stamina Drain
        public override void DrainStaminaLightAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
        }

        public override void DrainStaminaHeavyAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
        }
        #endregion

        private WeaponHolderSlot GetWeaponHolderSlot(WeaponSlotID slotID)
        {
            switch(slotID)
            {
                case WeaponSlotID.RightHandSlot:
                    return rightHandSlot;
                case WeaponSlotID.LeftHandSlot:
                    return leftHandSlot;
                case WeaponSlotID.BackSlot:
                    return backSlot;
                default:
                    throw new Exception("Invalid weapon slot ID");
            }
        }
    }
}
