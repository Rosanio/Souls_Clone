using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class EnemyAnimatorHandler : AnimatorHandler
    {
        EnemyManager enemyManager;
        EnemyLocomotionManager locomotionManager;

        protected override void Awake()
        {
            base.Awake();
            anim = GetComponent<Animator>();
            enemyManager = GetComponentInParent<EnemyManager>();
            locomotionManager = GetComponentInParent<EnemyLocomotionManager>();
        }

        private void OnAnimatorMove()
        {
            float delta = Time.deltaTime;
            enemyManager.enemyRigidbody.drag = 0;
            Vector3 deltaPosition = anim.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            enemyManager.enemyRigidbody.velocity = velocity;
        }

        public override void EnableRotation()
        {
            locomotionManager.canRotate = true;
        }

        public override void DisableRotation()
        {
            locomotionManager.canRotate = false;
        }
    }
}

