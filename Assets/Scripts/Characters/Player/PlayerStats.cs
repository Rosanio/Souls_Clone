using UnityEngine;

namespace SoulsLikeTutorial
{
    public class PlayerStats : CharacterStats
    {
        public StaminaBar staminaBar;

        PlayerManager playerManager;

        public float staminaRegenerationAmount = 1;
        public float staminaRegenDelay = 0.5f;

        private float staminaRegenTimer = 0;

        protected override void Start()
        {
            base.Start();
            healthBar.SetMax(maxHealth);
            SetMaxStaminaFromStaminaLevel();
            currentStamina = maxStamina;
            staminaBar.SetMax(maxStamina);
            playerManager = GetComponent<PlayerManager>();
        }

        public override void TakeDamage(int damage, int poiseDamage)
        {
            if (playerManager.isInvulnerable) return;
            base.TakeDamage(damage, poiseDamage);
        }

        private void SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina -= damage;

            staminaBar.SetValue(currentStamina);
            staminaRegenTimer = 0;
        }

        public override void HandleStatRegeneration()
        {
            base.HandleStatRegeneration();
            if (!playerManager.isInteracting)
                RegenerateStamina();
        }

        public void RegenerateStamina()
        {
            staminaRegenTimer += Time.deltaTime;
            if (currentStamina < maxStamina && staminaRegenTimer > staminaRegenDelay)
            {
                currentStamina += staminaRegenerationAmount * Time.deltaTime;
                staminaBar.SetValue(Mathf.RoundToInt(currentStamina));
            }
        }
    }
}
