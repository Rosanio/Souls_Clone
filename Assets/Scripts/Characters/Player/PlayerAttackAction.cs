using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    [CreateAssetMenu(menuName = "Actions/Player Attack Action")]
    public class PlayerAttackAction : Action
    {
        public float damageMultiplier;
        public float poiseDamageMultiplier;
    }
}
