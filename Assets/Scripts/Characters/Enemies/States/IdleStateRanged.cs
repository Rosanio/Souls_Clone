using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class IdleStateRanged : State
    {
        RangedCombatState rangedCombatState;

        protected override void Awake()
        {
            base.Awake();
            rangedCombatState = transform.parent.GetComponentInChildren<RangedCombatState>();
        }

        public override State Tick()
        {
            locomotionManager.HandleDetection();

            if (enemyManager.currentTarget != null)
            {
                return rangedCombatState;
            }
            return this;
        }
    }
}
