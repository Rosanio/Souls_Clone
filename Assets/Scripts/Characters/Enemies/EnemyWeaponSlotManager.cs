using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class EnemyWeaponSlotManager : WeaponSlotManager
    {
        public WeaponItem rightHandWeapon;
        public WeaponItem leftHandWeapon;

        EnemyStats stats;
        EnemyAttacker attacker;
        EnemyManager enemyManager;

        private void Awake()
        {
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.slotID == WeaponSlotID.LeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if (weaponSlot.slotID == WeaponSlotID.RightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
            }

            stats = GetComponentInParent<EnemyStats>();
            attacker = GetComponentInParent<EnemyAttacker>();
            enemyManager = GetComponentInParent<EnemyManager>();
        }

        private void Start()
        {
            LoadWeaponsOnBothHands();
        }

        public void LoadWeaponsOnBothHands()
        {
            if (rightHandWeapon != null)
            {
                LoadWeaponOnSlot(rightHandWeapon, false);
            }
            if (leftHandWeapon != null)
            {
                LoadWeaponOnSlot(leftHandWeapon, true);
            }
        }

        public void LoadWeaponOnSlot(WeaponItem weapon, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.currentWeapon = weapon;
                leftHandSlot.LoadWeaponModel(weapon);
                LoadWeaponDamageCollider(true);
            }
            else
            {
                rightHandSlot.currentWeapon = weapon;
                rightHandSlot.LoadWeaponModel(weapon);
                LoadWeaponDamageCollider(false);
            }
        }

        public void LoadWeaponDamageCollider(bool isLeft)
        {
            if (isLeft)
            {
                leftHandDamageCollider = leftHandSlot.itemModel.GetComponentInChildren<DamageCollider>();
            }
            else
            {
                rightHandDamageCollider = rightHandSlot.itemModel.GetComponentInChildren<DamageCollider>();
            }
        }

        public override void OpenDamageCollider()
        {
            if (stats.isStaggered || stats.isDead) return;

            rightHandDamageCollider.EnableDamageCollider();
        }

        public override void CloseDamageCollider()
        {
            if (rightHandDamageCollider)
                rightHandDamageCollider.DisableDamageCollider();
        }

        public void SpawnProjectile()
        {
            if (stats.isDead || stats.isStaggered) return;
            GameObject projectile = Instantiate(attacker.GetLastAttack().projectile, rightHandSlot.transform);
            projectile.GetComponentInChildren<ProjectileBehavior>().SetTeamID(enemyManager.teamID);
            projectile.GetComponentInChildren<ProjectileBehavior>().SetTarget(enemyManager.currentTarget.transform);
        }

        public void FireProjectile()
        {
            ProjectileBehavior projectile = rightHandSlot.GetComponentInChildren<ProjectileBehavior>();
            if (projectile != null)
                projectile.Fire();
        }

        public void DespawnPorjectile()
        {
            ProjectileBehavior projectile = rightHandSlot.GetComponentInChildren<ProjectileBehavior>();
            if (projectile != null)
            {
                Destroy(projectile.transform.parent.parent.gameObject);
            }
        }
    }
}
