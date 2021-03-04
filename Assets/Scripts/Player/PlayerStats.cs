using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class PlayerStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public int staminaLevel = 10;
        public int maxStamina;
        public int currentStamina;


        public HealthBar healthBar;
        public StaminaBar staminaBar;

        AnimatorHandler animatorHandler;

        void Start()
        {
            SetMaxHealthFromHealthLevel();
            SetMaxStaminaFromStaminaLevel();
            currentHealth = maxHealth;
            currentStamina = maxStamina;
            healthBar.SetMaxHealth(maxHealth);
            staminaBar.SetMaxStamina(maxStamina);
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        private void SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
        }

        private void SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            healthBar.SetCurrentHealth(currentHealth);

            if (currentHealth > 0)
            {
                animatorHandler.PlayTargetAnimation("Damage Light", true);
            }
            else
            {
                animatorHandler.PlayTargetAnimation("Death 01", true);
            }
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina -= damage;

            staminaBar.SetCurrentStamina(currentStamina);
        }
    }
}
