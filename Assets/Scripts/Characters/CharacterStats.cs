using UnityEngine;

namespace SoulsLikeTutorial
{
    public class CharacterStats : MonoBehaviour
    {
        protected AnimatorHandler animatorHandler;
        protected WeaponSlotManager weaponSlotManager;

        public StatMeter healthBar;

        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public int staminaLevel = 10;
        public float maxStamina;
        public float currentStamina;

        public int poise;
        public float currentPoiseBuildUp;
        public float poiseRegenerationAmount = 1;

        public bool isStaggered;
        [HideInInspector] public bool isDead;

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

            currentHealth -= damage;
            if (healthBar)
                healthBar.SetValue(currentHealth);

            if (!isStaggered)
                currentPoiseBuildUp += poiseDamage;

            if (currentHealth < 0)
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

        public virtual void HandleStatRegeneration()
        {
            if (currentPoiseBuildUp > 0)
            {
                currentPoiseBuildUp -= poiseRegenerationAmount * Time.deltaTime;
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
