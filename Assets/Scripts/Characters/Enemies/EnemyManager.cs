using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SoulsLikeTutorial
{

    public class EnemyManager : CharacterManager
    {
        public State currentState;
        public bool isPerformingAction;
        public CharacterManager currentTarget;
        public NavMeshAgent navMeshAgent;
        public Rigidbody enemyRigidbody;

        [HideInInspector]
        public float currentRecoveryTime = 0;

        private EnemyLocomotionManager locomotionManager;
        private State startingState;

        private void Awake()
        {
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
            enemyRigidbody = GetComponent<Rigidbody>();
            locomotionManager = GetComponent<EnemyLocomotionManager>();
            startingState = currentState;
        }

        protected override void Update()
        {
            if (stats.isDead) return;

            base.Update();

            HandleRecoveryTimer();
            stats.HandleStatRegeneration();

        }

        private void FixedUpdate()
        {
            if (stats.isDead) return;
            HandleStateMachine();
        }

        private void HandleStateMachine()
        {
            if (currentState != null)
            {
                State nextState = currentState.Tick();

                if (nextState != null)
                {
                    SwitchToNextState(nextState);
                }
            }
        }

        public float GetDistanceFromTarget()
        {
            return Vector3.Distance(currentTarget.transform.position, transform.position);
        }

        public float GetAngleToTarget()
        {
            Vector3 targetDirection = currentTarget.transform.position - transform.position;
            return Vector3.Angle(targetDirection, transform.forward);
        }

        public void HandleDeath()
        {
            // Layer 13 is DeadCharacter
            gameObject.layer = 13;
            characterCollisionBlockerCollider.gameObject.layer = 13;
        }

        public void Respawn()
        {
            stats.ResetStats();
            locomotionManager.canRotate = true;
            currentTarget = null;
            animatorHandler.PlayTargetAnimation("Empty", false, true);
            currentState = startingState;
        }

        private void SwitchToNextState(State nextState)
        {
            currentState = nextState;
        }

        private void HandleRecoveryTimer()
        {
            if (currentRecoveryTime > 0)
            {
                currentRecoveryTime -= Time.deltaTime;
            }

            if (isPerformingAction)
            {
                if (currentRecoveryTime <= 0)
                {
                    isPerformingAction = false;
                }
            }
        }
    }
}