using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public abstract class State : MonoBehaviour
    {
        protected EnemyManager enemyManager;
        protected EnemyStats enemyStats;
        protected EnemyAnimatorHandler animatorHandler;
        protected EnemyLocomotionManager locomotionManager;
        protected EnemyAttacker attacker;

        protected virtual void Awake()
        {
            enemyManager = transform.parent.parent.GetComponent<EnemyManager>();
            enemyStats = transform.parent.parent.GetComponent<EnemyStats>();
            animatorHandler = transform.parent.parent.GetComponentInChildren<EnemyAnimatorHandler>();
            locomotionManager = transform.parent.parent.GetComponent<EnemyLocomotionManager>();
            attacker = transform.parent.parent.GetComponent<EnemyAttacker>();
        }

        public abstract State Tick();
    }
}
