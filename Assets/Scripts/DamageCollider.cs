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
            print(collision.gameObject.name);
            int attackDamage;
            int poiseDamage;
            float hitAngle;
            ProjectileBehavior projectile = null;

            CharacterManager character = collision.GetComponent<CharacterManager>();
            if (character == null) return;

            Attacker attacker = GetComponentInParent<Attacker>();
            BlockingCollider shield = collision.transform.GetComponentInChildren<BlockingCollider>();

            Team teamID;

            // If the attacker cannot be found, this is a projectile
            if (attacker == null)
            {
                projectile = GetComponent<ProjectileBehavior>();
                attackDamage = projectile.damage;
                poiseDamage = projectile.poiseDamage;
                teamID = projectile.team;
                hitAngle = Vector3.Angle(-projectile.transform.forward, character.transform.forward);
            }
            else
            {
                attackDamage = attacker.GetCurrentAttackDamage();
                poiseDamage = attacker.GetCurrentAttackPoiseDamage();
                teamID = GetComponentInParent<CharacterManager>().teamID;
                hitAngle = Vector3.Angle(attacker.transform.forward, character.transform.forward);
            }
            if (character != null && character.teamID != teamID)
            {
                character.TakeDamage(attackDamage, poiseDamage, hitAngle);
            }

            if (projectile != null && (character == null || character.teamID != teamID))
                Destroy(gameObject);
        }
    }
}
