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

        protected virtual void Start()
        {
            Physics.IgnoreCollision(characterCollider, characterCollisionBlockerCollider, true);
        }
    }
}
