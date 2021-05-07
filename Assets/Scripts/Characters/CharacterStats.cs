using UnityEngine;

namespace SoulsLikeTutorial
{
    public class CharacterStats : MonoBehaviour
    {
        protected AnimatorHandler animatorHandler;
        protected WeaponSlotManager weaponSlotManager;

        public StatMeter healthBar;
        public StaminaBar staminaBar;

        public int healthLevel = 10;
        public int maxHealth;
        public float currentHealth;

        public int staminaLevel = 10;
        public float maxStamina;
        public float currentStamina;
        public float staminaRegenerationAmount = 1;
        public float staminaRegenDelay = 0.5f;
        protected float staminaRegenTimer = 0;

        public int poise;
        public float currentPoiseBuildUp;
        public float poiseRegenerationAmount = 1;

        public bool isStaggered;
        [HideInInspector] public bool isDead;

        float healthRegenerationRate;
        float healingTimer = 0;

        protected virtual void Start()
        {
            SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        public virtual void TakeDamage(int damage, int poiseDamage)
        {
            if (isDead) return;

            weaponSlotManager.CloseDamageCollider();

            UpdateHealth(-damage);

            if (!isStaggered)
                currentPoiseBuildUp += poiseDamage;

            if (currentHealth <= 0)
            {
                animatorHandler.PlayTargetAnimation("Death 01", true);
                isDead = true;
            }
            else if(currentPoiseBuildUp > poise)
            {
                currentPoiseBuildUp = 0;
                animatorHandler.PlayTargetAnimation("Damage Light", true);
                isStaggered = true;
            }
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina -= damage;

            if (staminaBar != null)
                staminaBar.SetValue(currentStamina);

            staminaRegenTimer = 0;
        }

        public virtual void HandleStatRegeneration()
        {
            if (currentPoiseBuildUp > 0)
            {
                currentPoiseBuildUp -= poiseRegenerationAmount * Time.deltaTime;
            }

            if (healingTimer > 0)
            {
                UpdateHealth(healthRegenerationRate * Time.deltaTime);
                healingTimer -= Time.deltaTime;
            }
        }

        public virtual void HealOverTime(int healingAmount, float seconds)
        {
            healthRegenerationRate = healingAmount / seconds;
            healingTimer = seconds;
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

        private void UpdateHealth(float healthDelta)
        {
            currentHealth += healthDelta;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
            if (currentHealth < 0)
                currentHealth = 0;
            if (healthBar)
                healthBar.SetValue(currentHealth);
        }
    }
}
