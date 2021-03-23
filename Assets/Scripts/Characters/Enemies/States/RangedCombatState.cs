using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class RangedCombatState : State
    {
        public float maximumFiringDistance;

        IdleStateRanged idleStateRanged;

        protected override void Awake()
        {
            base.Awake();
            idleStateRanged = transform.parent.GetComponentInChildren<IdleStateRanged>();
        }

        public override State Tick()
        {
            float distanceFromTarget = enemyManager.GetDistanceFromTarget();
            if (distanceFromTarget > maximumFiringDistance)
                return idleStateRanged;

            locomotionManager.HandleRotateTowardsTarget(false);

            if (enemyManager.isPerformingAction)
            {
                return this;
            }

            attacker.QueueNextAttack(distanceFromTarget);
            if (attacker.IsAbleToAttack())
            {
                attacker.Attack();
            }

            return this;
        }
    }
}
