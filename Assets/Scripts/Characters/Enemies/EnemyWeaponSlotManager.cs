﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class EnemyWeaponSlotManager : WeaponSlotManager
    {
        public WeaponItem rightHandWeapon;
        public WeaponItem leftHandWeapon;

        public Transform projectileSpawnPoint;

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
            rightHandDamageCollider.DisableDamageCollider();
        }

        public void SpawnProjectile()
        {
            GameObject projectile = Instantiate(attacker.GetLastAttack().projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.GetComponent<ProjectileBehavior>().SetTeamID(enemyManager.teamID);
        }
    }
}
