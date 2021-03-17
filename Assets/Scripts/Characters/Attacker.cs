using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public abstract class Attacker : MonoBehaviour
    {
        public abstract int GetCurrentAttackDamage();

        public abstract int GetCurrentAttackPoiseDamage();
    }
}
