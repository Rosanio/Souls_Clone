using UnityEngine;

namespace SoulsLikeTutorial
{
    public class DamageCollider : MonoBehaviour
    {
        public Team teamID;

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
            int attackDamage;
            int poiseDamage;
            ProjectileBehavior projectile = null;

            CharacterManager character = collision.GetComponent<CharacterManager>();
            Attacker attacker = GetComponentInParent<Attacker>();

            Team teamID;

            // If the attacker cannot be found, this is a projectile
            if (attacker == null)
            {
                projectile = GetComponent<ProjectileBehavior>();
                attackDamage = projectile.damage;
                poiseDamage = projectile.poiseDamage;
                teamID = projectile.team;
            }
            else
            {
                attackDamage = attacker.GetCurrentAttackDamage();
                poiseDamage = attacker.GetCurrentAttackPoiseDamage();
                teamID = GetComponentInParent<CharacterManager>().teamID;
            }

            if (character != null && character.teamID != teamID)
            {
                character.TakeDamage(attackDamage, poiseDamage);
            }

            if (projectile != null && (character == null || character.teamID != teamID))
                Destroy(gameObject);
        }
    }
}
