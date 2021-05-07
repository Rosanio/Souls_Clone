using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem : Item
    {
        public bool isUnarmed;

        [Header("Idle Animations")]
        public string Right_Hand_Idle;
        public string Left_Hand_Idle;
        public string Two_Hand_Idle;

        [Header("One Handed Attacks")]
        public PlayerAttackAction OH_Light_Attack_1;
        public PlayerAttackAction OH_Light_Attack_2;
        public PlayerAttackAction OH_Heavy_Attack_1;
        public PlayerAttackAction OH_Heavy_Attack_2;

        [Header("Two Handed Attack Animations")]
        public PlayerAttackAction TH_Light_Attack_1;
        public PlayerAttackAction TH_Light_Attack_2;
        public PlayerAttackAction TH_Heavy_Attack_1;
        public PlayerAttackAction TH_Heavy_Attack_2;

        [Header("Damage")]
        public int baseDamage;
        public int basePoiseDamage;

        [Header("Absorbtion")]
        public float physicalDamageAbsorbtion;
        public int stability;

        [Header("Stamina Costs")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;
    }
}
