using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class PlayerAttacker : MonoBehaviour
    {
        AnimatorHandler animatorHandler;
        InputHandler inputHandler;
        WeaponSlotManager weaponSlotManager;
        public string lastAttack;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            inputHandler = GetComponent<InputHandler>();
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        public void HandleWeaponCombo(WeaponItem weapon)
        {
            if (inputHandler.comboFlag)
            {
                animatorHandler.anim.SetBool("canDoCombo", false);
                if (lastAttack == weapon.OH_Light_Attack_1)
                {
                    LightAttack2(weapon);
                }
                else if (lastAttack == weapon.OH_Light_Attack_2)
                {
                    LightAttack1(weapon);
                }
                else if (lastAttack == weapon.OH_Heavy_Attack_1)
                {
                    HeavyAttack2(weapon);
                }
                else if (lastAttack == weapon.OH_Heavy_Attack_2)
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
            weaponSlotManager.attackingWeapon = weapon;
            animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
            lastAttack = weapon.OH_Light_Attack_1;
        }

        private void LightAttack2(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;
            animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_2, true);
            lastAttack = weapon.OH_Light_Attack_2;
        }

        private void HeavyAttack1(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;
            animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
            lastAttack = weapon.OH_Heavy_Attack_1;
        }

        private void HeavyAttack2(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;
            animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_2, true);
            lastAttack = weapon.OH_Heavy_Attack_2;
        }
    }
}
