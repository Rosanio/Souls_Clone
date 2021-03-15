using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class AmbushState : State
    {
        public bool isSleeping;
        public float detectionRadius = 2;
        public string sleepAnimation;
        public string wakeAnimation;

        public LayerMask detectionLayer;

        PursueTargetState pursueTargetState;

        protected override void Awake()
        {
            base.Awake();
            pursueTargetState = transform.parent.GetComponentInChildren<PursueTargetState>();
        }

        public override State Tick()
        {
            if (isSleeping && !enemyManager.isInteracting)
            {
                animatorHandler.PlayTargetAnimation(sleepAnimation, true);
            }

            locomotionManager.HandleDetection();

            if (enemyManager.currentTarget != null)
            {
                isSleeping = false;
                animatorHandler.PlayTargetAnimation(wakeAnimation, true);
                return pursueTargetState;
            }
            else
            {
                return this;
            }
        }
    }
}
