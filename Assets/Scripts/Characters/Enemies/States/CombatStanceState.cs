using UnityEngine;

namespace SoulsLikeTutorial
{
    public class CombatStanceState : State
    {
        AttackState attackState;
        PursueTargetState pursueTargetState;

        protected override void Awake()
        {
            base.Awake();
            pursueTargetState = transform.parent.GetComponentInChildren<PursueTargetState>();
            attackState = transform.parent.GetComponentInChildren<AttackState>();
        }

        public override State Tick()
        {

            if (enemyManager.isPerformingAction)
            {
                locomotionManager.HandleRotateTowardsTarget(false);
                animatorHandler.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                return this;
            }
            locomotionManager.HandleRotateTowardsTarget(false, 5);

            // Reset canRotate in case the attack animation was interrupted
            if (!locomotionManager.canRotate)
                locomotionManager.canRotate = true;

            float distanceFromTarget = enemyManager.GetDistanceFromTarget();
            float angleToTarget = enemyManager.GetAngleToTarget();
            attacker.QueueNextAttack(distanceFromTarget);

            if (attacker.IsCloseEnoughToAttack(distanceFromTarget))
            {
                if (attacker.IsWithinAttackAngle(angleToTarget) && enemyManager.currentRecoveryTime <= 0)
                {
                    return attackState;
                }
            }
            else
            {
                return pursueTargetState;
            }

            return this;
        }
    }
}
