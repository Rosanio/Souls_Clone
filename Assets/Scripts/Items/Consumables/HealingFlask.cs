using UnityEngine;

namespace SoulsLikeTutorial
{
    public class HealingFlask : Consumable
    {
        PlayerStats stats;

        private void Awake()
        {
            stats = FindObjectOfType<PlayerStats>();
        }

        public override void Use()
        {
            stats.HealOverTime(60, 0.5f);
        }
    }
}
