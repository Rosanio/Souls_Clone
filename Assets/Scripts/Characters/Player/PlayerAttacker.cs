using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class PlayerAttacker : Attacker
    {
        PlayerAnimatorHandler animatorHandler;
        InputHandler inputHandler;
        PlayerStats playerStats;
        PlayerWeaponSlotManager weaponSlotManager;
        public PlayerAttackAction lastAttack;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<PlayerAnimatorHandler>();
            inputHandler = GetComponent<InputHandler>();
            playerStats = GetComponent<PlayerStats>();
            weaponSlotManager = GetComponentInChildren<PlayerWeaponSlotManager>();
        }

        public override int GetCurrentAttackDamage()
        {
            return Mathf.RoundToInt(weaponSlotManager.attackingWeapon.baseDamage * lastAttack.damageMultiplier);
        }

        public override int GetCurrentAttackPoiseDamage()
        {
            return Mathf.RoundToInt(weaponSlotManager.attackingWeapon.basePoiseDamage * lastAttack.poiseDamageMultiplier);
        }

        public void HandleWeaponCombo(WeaponItem weapon)
        {
            if (inputHandler.comboFlag)
            {
                animatorHandler.anim.SetBool("canDoCombo", false);
                if (lastAttack == weapon.OH_Light_Attack_1 || lastAttack == weapon.TH_Light_Attack_1)
                {
                    LightAttack2(weapon);
                }
                else if (lastAttack == weapon.OH_Light_Attack_2 || lastAttack == weapon.TH_Light_Attack_2)
                {
                    LightAttack1(weapon);
                }
                else if (lastAttack == weapon.OH_Heavy_Attack_1 || lastAttack == weapon.TH_Heavy_Attack_1)
                {
                    HeavyAttack2(weapon);
                }
                else if (lastAttack == weapon.OH_Heavy_Attack_2 || lastAttack == weapon.TH_Heavy_Attack_2)
                {
                    HeavyAttack1(weapon);
                }
            }
        }

        public void HandleLightAttack(WeaponItem weapon)
        {
            LightAttack1(weapon);
        }

        public void HandleHeavyAttack(WeaponItem weapon)
        {
            HeavyAttack1(weapon);
        }

        private void LightAttack1(WeaponItem weapon)
        {
            PlayerAttackAction attack = inputHandler.twoHandFlag ? weapon.TH_Light_Attack_1 : weapon.OH_Light_Attack_1;
            PerformAttack(weapon, attack);
        }

        private void LightAttack2(WeaponItem weapon)
        {
            PlayerAttackAction attack = inputHandler.twoHandFlag ? weapon.TH_Light_Attack_2 : weapon.OH_Light_Attack_2;
            PerformAttack(weapon, attack);
        }

        private void HeavyAttack1(WeaponItem weapon)
        {
            PlayerAttackAction attack = inputHandler.twoHandFlag ? weapon.TH_Heavy_Attack_1 : weapon.OH_Heavy_Attack_1;
            PerformAttack(weapon, attack);
        }

        private void HeavyAttack2(WeaponItem weapon)
        {
            PlayerAttackAction attack = inputHandler.twoHandFlag ? weapon.TH_Heavy_Attack_2 : weapon.OH_Heavy_Attack_2;
            PerformAttack(weapon, attack);
        }

        private void PerformAttack(WeaponItem weapon, PlayerAttackAction attack)
        {
            if (playerStats.currentStamina <= 0) return;
            weaponSlotManager.attackingWeapon = weapon;
            animatorHandler.PlayTargetAnimation(attack.actionAnimation, true);
            lastAttack = attack;
        }
    }
}
