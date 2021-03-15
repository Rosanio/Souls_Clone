using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class AttackState : State
    {
        public CombatStanceState combatStanceState;

        protected override void Awake()
        {
            base.Awake();
            combatStanceState = transform.parent.GetComponentInChildren<CombatStanceState>();
        }

        public override State Tick()
        {

            locomotionManager.HandleRotateTowardsTarget(false);

            float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
            Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

            if (attacker.IsAbleToAttack() && attacker.IsInAttackRange(distanceFromTarget, viewableAngle))
            {
                attacker.Attack();
            }
            else if (attacker.IsTooCloseToAttack(distanceFromTarget))
            {
                attacker.GetNewAttack(distanceFromTarget);
            }

            return combatStanceState;
        }
    }
}
