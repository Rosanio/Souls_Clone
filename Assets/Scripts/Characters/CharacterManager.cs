using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{

    public class CharacterManager : MonoBehaviour
    {
        public Transform lockOnTransform;
        public Transform healthBarTransform;
        public Team teamID;
        public CapsuleCollider characterCollider;
        public CapsuleCollider characterCollisionBlockerCollider;

        public bool isInteracting;
        public bool isBlocking;

        public CharacterStats stats;
        protected AnimatorHandler animatorHandler;

        protected virtual void Start()
        {
            Physics.IgnoreCollision(characterCollider, characterCollisionBlockerCollider, true);

            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            stats = GetComponent<CharacterStats>();
        }

        protected virtual void Update()
        {
            isInteracting = animatorHandler.anim.GetBool("isInteracting");

            // FIXME: This should be updated so that an animation event is not determining the enemies stagger state
            if (!isInteracting)
                stats.isStaggered = false;
        }

        public virtual void TakeDamage(int damage, int poiseDamage, float? attackAngle = null)
        {
            BlockingCollider shield = transform.GetComponentInChildren<BlockingCollider>();
            if (isBlocking && shield != null && attackAngle > 90)
            {
                damage = Mathf.RoundToInt(damage - (damage * shield.blockingPhysicalDamageAbsorbtion) / 100);
                int staminaDamage = poiseDamage * (100 / shield.stability);
                stats.TakeStaminaDamage(staminaDamage);
                poiseDamage = 0;
                animatorHandler.PlayTargetAnimation("Block Impact", true);
            }
            stats.TakeDamage(damage, poiseDamage);
        }
    }
}
