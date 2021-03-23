using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    [CreateAssetMenu(menuName = "Actions/Enemy Attack Action")]
    public class EnemyAttackAction : Action
    {
        public int attackScore = 3;
        public float recoveryTime = 2;

        public float maximumAttackAngle = 35;
        public float minimumAttackAngle = -35;

        public float minimumDistanceNeededToAttack = 0;
        public float maximumDistanceNeededToAttack = 3;

        public int damage;
        public int poiseDamage;

        public GameObject projectile;
    }
}
