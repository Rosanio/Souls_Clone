using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class IdleState : State
    {
        public LayerMask detectionLayer;

        PursueTargetState pursueTargetState;

        protected override void Awake()
        {
            base.Awake();
            pursueTargetState = transform.parent.GetComponentInChildren<PursueTargetState>();
        }

        public override State Tick()
        {
            locomotionManager.HandleDetection();

            if (enemyManager.currentTarget != null)
            {
                return pursueTargetState;
            }
            return this;
        }
    }
}
