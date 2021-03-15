using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class AnimatorHandler : MonoBehaviour
    {
        public Animator anim;

        public void PlayTargetAnimation(string targetAnim, bool isInteracting)
        {
            if (anim.GetBool("isInteracting"))
                anim.Rebind();
            anim.applyRootMotion = isInteracting;
            anim.SetBool("isInteracting", isInteracting);
            anim.CrossFade(targetAnim, 0.2f);
        }

        public virtual void EnableRotation()
        {
            
        }

        public virtual void DisableRotation()
        {
            
        }
    }
}

