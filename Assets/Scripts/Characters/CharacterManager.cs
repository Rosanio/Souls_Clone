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

        public virtual void TakeDamage(int damage, int poiseDamage)
        {
            stats.TakeDamage(damage, poiseDamage);
        }
    }
}
