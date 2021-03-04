using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class EnemyStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        Animator animator;

        void Start()
        {
            SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            animator = GetComponentInChildren<Animator>();
        }

        private void SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth > 0)
            {
                animator.Play("Damage Light");
            }
            else
            {
                animator.Play("Death 01");
            }
        }
    }
}
