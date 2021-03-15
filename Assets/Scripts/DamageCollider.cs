using UnityEngine;

namespace SoulsLikeTutorial
{
    public class DamageCollider : MonoBehaviour
    {
        Collider damageCollider;

        public int currentWeaponDamage = 25;

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
            if (stats != null)
            {
                WeaponSlotManager weaponSlotManager = collision.GetComponentInChildren<WeaponSlotManager>();
                weaponSlotManager.CloseDamageCollider();
                stats.TakeDamage(currentWeaponDamage);
            }
        }
    }
}
