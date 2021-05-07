using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class AnimatorHandler : MonoBehaviour
    {
        public Animator anim;

        CharacterStats stats;

        protected virtual void Awake()
        {
            stats = GetComponentInParent<CharacterStats>();
        }

        public void PlayTargetAnimation(string targetAnim, bool isInteracting, bool enableRotation = false)
        {
            anim.applyRootMotion = isInteracting;
            anim.SetBool("isInteracting", isInteracting);
            anim.SetBool("canRotate", enableRotation);
            anim.CrossFade(targetAnim, 0.2f);
        }

        public virtual void EnableRotation()
        {
            
        }

        public virtual void DisableRotation()
        {
            
        }

        public virtual void EnableCombo()
        {

        }

        public virtual void DisableCombo()
        {

        }

        public virtual void ExitStaggerState()
        {
            stats.isStaggered = false;
        }

        public void StopMovement()
        {
            anim.SetFloat("Vertical", 0, 0.01f, Time.deltaTime);
            anim.SetFloat("Horizontal", 0, 0.01f, Time.deltaTime);
        }
    }
}

