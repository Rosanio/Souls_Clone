using System.Collections;

using UnityEngine;

namespace SoulsLikeTutorial
{
    public class PlayerStats : CharacterStats
    {
        PlayerManager playerManager;

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

        protected override void HandleDeath()
        {
            StartCoroutine(RespawnPlayer());
        }

        private void SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
        }

        public override void HandleStatRegeneration()
        {
            base.HandleStatRegeneration();
            if (!playerManager.isInteracting)
                RegenerateStamina();
        }

        private void RegenerateStamina()
        {
            staminaRegenTimer += Time.deltaTime;
            if (currentStamina < maxStamina && staminaRegenTimer > staminaRegenDelay)
            {
                float regenAmount = staminaRegenerationAmount;
                if (playerManager.isBlocking)
                    regenAmount /= 5;
                UpdateStamina(regenAmount * Time.deltaTime);
            }
        }

        private IEnumerator RespawnPlayer()
        {
            yield return new WaitForSeconds(6);
            ResetStats();
            playerManager.RespawnPlayer();
        }
    }
}
