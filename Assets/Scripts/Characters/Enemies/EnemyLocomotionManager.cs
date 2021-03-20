using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SoulsLikeTutorial
{
    public class EnemyLocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        EnemyAnimatorHandler enemyAnimatorManager;
        NavMeshAgent navMeshAgent;
        public Rigidbody enemyRigidbody;

        public LayerMask detectionLayer;

        [Header("A.I. Settings")]
        public float detectionRadius = 20;
        public float maximumDetectionAngle = 50;
        public float minimumDetectionAngle = -50;
        public float rotationSpeed = 15;

        public bool canRotate = true;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorHandler>();
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
            enemyRigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            navMeshAgent.enabled = false;
            enemyRigidbody.isKinematic = false;
        }

        public void HandleDetection()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

            for (int i = 0; i < colliders.Length; i++)
            {
                CharacterManager character = colliders[i].transform.GetComponent<CharacterManager>();

                if (character != null)
                {
                    // Check for team ID
                    if (character.teamID == enemyManager.teamID) continue;

                    Vector3 targetDirection = character.transform.position - transform.position;
                    float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                    if (viewableAngle > minimumDetectionAngle && viewableAngle < maximumDetectionAngle)
                    {
                        enemyManager.currentTarget = character;
                    }
                }
            }
        }

        public void HandleMoveToTarget()
        {
            if (enemyManager.isPerformingAction)
            {
                enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                navMeshAgent.enabled = false;
            }
            else
            {
                enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
            }

            HandleRotateTowardsTarget(true);

            navMeshAgent.transform.localPosition = Vector3.zero;
        }

        public void HandleRotateTowardsTarget(bool useNavMesh, float speed = 10)
        {
            if (!canRotate) return;
            if (enemyManager.isPerformingAction || !useNavMesh)
            {
                Vector3 direction = enemyManager.currentTarget.transform.position - transform.position;
                direction.y = 0;
                direction.Normalize();

                if (direction == Vector3.zero)
                {
                    direction = transform.forward;
                }

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
                print(transform.rotation);
            }
            else
            {
                Vector3 targetVelocity = enemyRigidbody.velocity;

                navMeshAgent.enabled = true;
                navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
                enemyRigidbody.velocity = targetVelocity;
                transform.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, rotationSpeed / Time.deltaTime);
                navMeshAgent.transform.localRotation = Quaternion.identity;
            }
        }
    }
}
