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

        private void SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
        }

        public override void TakeDamage(int damage)
        {
            if (playerManager.isInvulnerable) return;

            base.TakeDamage(damage);
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina -= damage;

            staminaBar.SetValue(currentStamina);
            staminaRegenTimer = 0;
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
