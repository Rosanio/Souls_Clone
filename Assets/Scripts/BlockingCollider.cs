using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class BlockingCollider : MonoBehaviour
    {
        BoxCollider blockCollider;

        public float blockingPhysicalDamageAbsorbtion;
        public int stability;

        private void Awake()
        {
            blockCollider = GetComponent<BoxCollider>();
        }

        public void SetColliderDamageAbsorbtion(WeaponItem weapon)
        {
            if (weapon != null)
            {
                blockingPhysicalDamageAbsorbtion = weapon.physicalDamageAbsorbtion;
                stability = weapon.stability;
            }
        }

        public void EnableCollider()
        {
            blockCollider.enabled = true;
        }

        public void DisableCollider()
        {
            blockCollider.enabled = false;
        }
    }
}
