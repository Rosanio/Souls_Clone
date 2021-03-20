using UnityEngine;

namespace SoulsLikeTutorial
{
    public class DamageCollider : MonoBehaviour
    {
        Collider damageCollider;

        private void Awake()
        {
            damageCollider = GetComponent<Collider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true; 
            damageCollider.enabled = false;
        }

        public void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }

        public void DisableDamageCollider()
        {
            damageCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider collision)
        {
            CharacterStats stats = collision.GetComponent<CharacterStats>();
            Attacker attacker = GetComponentInParent<Attacker>();
            if (stats != null)
            {
                stats.TakeDamage(attacker.GetCurrentAttackDamage(), attacker.GetCurrentAttackPoiseDamage());
            }
        }
    }
}
