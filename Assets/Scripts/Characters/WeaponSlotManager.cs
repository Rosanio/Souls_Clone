using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class WeaponSlotManager : MonoBehaviour
    {
        protected DamageCollider leftHandDamageCollider;
        protected DamageCollider rightHandDamageCollider;

        protected WeaponHolderSlot rightHandSlot;
        protected WeaponHolderSlot leftHandSlot;

        public virtual void OpenDamageCollider() { }

        public virtual void CloseDamageCollider() { }

        public virtual void DrainStaminaLightAttack() { }

        public virtual void DrainStaminaHeavyAttack() { }
    }

}
