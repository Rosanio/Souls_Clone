using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{ 
    public class CameraHandler : MonoBehaviour
    {
        InputHandler inputHandler;
        PlayerManager playerManager;
        UIManager uiManager;
        
        public Transform targetTransform;
        public Transform cameraTransform;
        public Transform cameraPivotTransform;
        private Transform myTransform;
        private Vector3 cameraTransformPosition;
        public LayerMask ignoreLayers;
        public LayerMask environmentLayer;
        private Vector3 cameraFollowVelocity = Vector3.zero;

        public static CameraHandler singleton;

        public float lookSpeed = 0.1f;
        public float followSpeed = 0.1f;
        public float pivotSpeed = 0.1f;

        private float targetPosition;
        private float defaultPosition;
        private float lookAngle;
        private float pivotAngle;
        public float minimumPivot = -65;
        public float maximumPivot = 65;

        public float cameraSphereRadius = 0.2f;
        public float cameraCollisionOffset = 0.2f;
        public float minimumCollisionOffset = 0.2f;
        public float lockedPivotPosition = 2.25f;
        public float unlockedPivotPosition = 1.65f;

        public Transform currentLockOnTarget;
        List<CharacterManager> availableTargets = new List<CharacterManager>();
        public Transform nearestLockOnTarget;
        public Transform leftLockTarget;
        public Transform rightLockTarget;
        public float maximumLockOnDistance = 20;
        private bool lockOnRotationComplete = true;

        private void Awake()
        {
            singleton = this;
            myTransform = transform;
            defaultPosition = cameraTransform.localPosition.z;
            ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10);
            targetTransform = FindObjectOfType<PlayerManager>().transform;

            inputHandler = FindObjectOfType<InputHandler>();
            playerManager = FindObjectOfType<PlayerManager>();
            uiManager = FindObjectOfType<UIManager>();
        }

        private void Start()
        {
            environmentLayer = LayerMask.NameToLayer("Environment");
        }

        public void FollowTarget(float delta)
        {
            Vector3 targetPosition = Vector3.SmoothDamp
                (myTransform.position, targetTransform.position, ref cameraFollowVelocity, delta / followSpeed);
            myTransform.position = targetPosition;

            HandleCameraCollisions(delta);
        }

        private void HandleCameraCollisions(float delta)
        {
            targetPosition = defaultPosition;
            RaycastHit hit;
            Vector3 direction = cameraTransform.position - cameraPivotTransform.position;
            direction.Normalize();

            if (Physics.SphereCast(cameraPivotTransform.position, cameraSphereRadius, direction, out hit, Mathf.Abs(targetPosition),
                    ignoreLayers))
            {
                float dis = Vector3.Distance(cameraPivotTransform.position, hit.point);
                targetPosition = -(dis - cameraCollisionOffset);
            }

            if (Mathf.Abs(targetPosition) < minimumCollisionOffset)
            {
                targetPosition = -minimumCollisionOffset;
            }

            cameraTransformPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, delta / 0.2f);
            cameraTransform.localPosition = cameraTransformPosition;
        }

        public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
        {
            if (!inputHandler.lockOn_Input && currentLockOnTarget == null)
            {
                DefaultCameraRotation(delta, mouseXInput, mouseYInput);
            }
            else
            {
                LockedOnCameraRotation(delta);
            }
        }

        private void DefaultCameraRotation(float delta, float mouseXInput, float mouseYInput)
        {
            mouseXInput = Mathf.Clamp(mouseXInput, -1f, 1f);
            mouseYInput = Mathf.Clamp(mouseYInput, -1f, 1f);
            lookAngle += (mouseXInput * lookSpeed) / delta;
            pivotAngle -= (mouseYInput * pivotSpeed) / delta;
            pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);

            Vector3 rotation = Vector3.zero;
            rotation.y = lookAngle;
            Quaternion targetRotation = Quaternion.Euler(rotation);
            myTransform.rotation = targetRotation;

            rotation = Vector3.zero;
            rotation.x = pivotAngle;

            targetRotation = Quaternion.Euler(rotation);
            cameraPivotTransform.localRotation = targetRotation;
        }

        private void LockedOnCameraRotation(float delta)
        {
            Vector3 direction = currentLockOnTarget.position - transform.position;

            //Override the look angle so that the camera doesn't move unexpectedly when leaving the lock on state
            lookAngle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);

            direction.Normalize();
            direction.y = 0;

            Quaternion targetRotation;

            // When switching lock on targets, the camera should smoothly move from one target to the other. Otherwise it
            // stay locked to the target position.
            if (lockOnRotationComplete)
            {
                targetRotation = Quaternion.LookRotation(direction);
            }
            else
            {
                Quaternion tr = Quaternion.LookRotation(direction);
                targetRotation = Quaternion.Slerp(transform.rotation, tr, delta/0.4f);
                if (Quaternion.Angle(tr, targetRotation) < 2)
                {
                    lockOnRotationComplete = true;
                }
            }
            
            transform.rotation = targetRotation;

            direction = currentLockOnTarget.position - cameraPivotTransform.position;
            direction.Normalize();

            targetRotation = Quaternion.LookRotation(direction);
            Vector3 eulerAngle = targetRotation.eulerAngles;
            eulerAngle.y = 0;
            cameraPivotTransform.localEulerAngles = eulerAngle;

            //Ensure the target icon appears over the enemy being targeted.
            uiManager.lockOnTarget.transform.position = Camera.main.WorldToScreenPoint(currentLockOnTarget.position);

        }

        public void UpdateLockOnState()
        {
            if (!inputHandler.lockOnFlag) return;

            if (Vector3.Distance(targetTransform.position, currentLockOnTarget.position) > maximumLockOnDistance)
            {
                ClearLockOnTargets();
                if(!LockOnToNearestTarget())
                {
                    inputHandler.lockOnFlag = false;
                }
            }
        }

        public bool LockOnToNearestTarget()
        {
            float shortestDistance = Mathf.Infinity;
            GetLockOnTargetsInRange();

            foreach (CharacterManager target in availableTargets)
            {
                float distanceFromTarget = Vector3.Distance(targetTransform.position, target.transform.position);
                if (distanceFromTarget < shortestDistance)
                {
                    shortestDistance = distanceFromTarget;
                    nearestLockOnTarget = target.lockOnTransform;
                }
            }

            if (nearestLockOnTarget != null)
            {
                SetNewLockOnTarget(nearestLockOnTarget);
            }
            return nearestLockOnTarget != null;
        }

        public void SwitchLockOnTarget(bool isLeft)
        {
            float shortestDistanceOfLeftTarget = Mathf.Infinity;
            float shortestDistanceOfRightTarget = Mathf.Infinity;

            GetLockOnTargetsInRange();

            Transform newTarget = null;

            foreach(CharacterManager target in availableTargets)
            {
                Vector3 relativeEnemyPosition = currentLockOnTarget.InverseTransformPoint(target.transform.position);
                float distanceFromLeftTarget = currentLockOnTarget.transform.position.x - target.transform.position.x;
                float distanceFromRightTarget = currentLockOnTarget.transform.position.x + target.transform.position.x;

                if (relativeEnemyPosition.x > 0 && distanceFromLeftTarget < shortestDistanceOfLeftTarget && isLeft)
                {
                    shortestDistanceOfLeftTarget = distanceFromLeftTarget;
                    newTarget = target.lockOnTransform;
                }
                else if (relativeEnemyPosition.x < 0 && distanceFromRightTarget < shortestDistanceOfRightTarget && !isLeft)
                {
                    shortestDistanceOfRightTarget = distanceFromRightTarget;
                    newTarget = target.lockOnTransform;
                }
            }

            if (newTarget != null)
            {
                SetNewLockOnTarget(newTarget);
            }
        }

        public void ClearLockOnTargets()
        {
            availableTargets.Clear();
            leftLockTarget = null;
            rightLockTarget = null;
            nearestLockOnTarget = null;
            currentLockOnTarget = null;
            uiManager.lockOnTarget.SetActive(false);
        }

        public void SetCameraHeight()
        {
            Vector3 velocity = Vector3.zero;
            Vector3 targetCameraPosition = currentLockOnTarget != null ? new Vector3(0, lockedPivotPosition) : new Vector3(0, unlockedPivotPosition);

            cameraPivotTransform.transform.localPosition = Vector3.SmoothDamp(cameraPivotTransform.transform.localPosition, targetCameraPosition, ref velocity, 2 * Time.deltaTime);
        }

        private void GetLockOnTargetsInRange()
        {
            Collider[] colliders = Physics.OverlapSphere(targetTransform.position, maximumLockOnDistance);

            foreach (Collider collider in colliders)
            {
                CharacterManager character = collider.GetComponent<CharacterManager>();

                if (character != null)
                {
                    Vector3 lockTargetDirection = character.transform.position - targetTransform.position;
                    float distanceFromTarget = Vector3.Distance(targetTransform.position, character.transform.position);
                    float viewableAngle = Vector3.Angle(lockTargetDirection, cameraTransform.forward);
                    RaycastHit hit;

                    if (character.transform.root != targetTransform.transform.root &&
                        viewableAngle > -70 &&
                        viewableAngle < 70 &&
                        distanceFromTarget < maximumLockOnDistance)
                    {
                        if (Physics.Linecast(playerManager.lockOnTransform.position, character.lockOnTransform.position, out hit))
                        {

                            if (hit.transform.gameObject.layer == environmentLayer)
                            {
                                //Cannot lock on, something in the way
                            }
                            else
                            {
                                availableTargets.Add(character);
                            }
                        }
                    }
                }
            }
        }

        private void SetNewLockOnTarget(Transform newTarget)
        {
            lockOnRotationComplete = false;
            currentLockOnTarget = newTarget;
            uiManager.lockOnTarget.SetActive(true);
        }
    }

}
