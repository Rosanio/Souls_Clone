using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class PursueTargetState : State
    {
        CombatStanceState combatStanceState;

        protected override void Awake()
        {
            base.Awake();
            combatStanceState = transform.parent.GetComponentInChildren<CombatStanceState>();
        }
        public override State Tick()
        {
            if (enemyManager.isPerformingAction)
            {
                animatorHandler.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                return this;
            }

            float distanceFromTarget = enemyManager.GetDistanceFromTarget();
            attacker.QueueNextAttack(distanceFromTarget);

            locomotionManager.HandleMoveToTarget();

            if (attacker.IsCloseEnoughToAttack(distanceFromTarget))
            {
                return combatStanceState;
            }
            return this;
        }
    }
}
