using UnityEngine;

namespace SoulsLikeTutorial
{
    public class CharacterStats : MonoBehaviour
    {
        protected AnimatorHandler animatorHandler;

        public StatMeter healthBar;

        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public int staminaLevel = 10;
        public float maxStamina;
        public float currentStamina;

        public bool isDead;

        protected virtual void Start()
        {
            SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        public virtual void TakeDamage(int damage)
        {
            if (isDead) return;

            currentHealth -= damage;
            if (healthBar)
                healthBar.SetValue(currentHealth);

            if (currentHealth > 0)
            {
                animatorHandler.PlayTargetAnimation("Damage Light", true);
            }
            else
            {
                animatorHandler.PlayTargetAnimation("Death 01", true);
                isDead = true;
            }
        }

        public void SetTargetHealthBar(StatMeter targetHealthBar)
        {
            healthBar = targetHealthBar;
            healthBar.SetMax(maxHealth);
            healthBar.SetValue(currentHealth);
        }

        private void SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
        }
    }
}
