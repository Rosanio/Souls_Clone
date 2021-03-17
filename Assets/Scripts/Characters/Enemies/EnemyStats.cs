using UnityEngine;

namespace SoulsLikeTutorial
{
    public class EnemyStats : CharacterStats
    {
        EnemyManager enemyManager;

        protected override void Start()
        {
            base.Start();
            enemyManager = GetComponent<EnemyManager>();
        }

        public override void TakeDamage(int damage, int poiseDamage)
        {
            base.TakeDamage(damage, poiseDamage);

            if (isDead)
                enemyManager.HandleDeath();
        }
    }
}
