using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class DamagePlayer : MonoBehaviour
    {
        private int damage = 25;
        private void OnTriggerEnter(Collider other)
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                WeaponSlotManager weaponSlotManager = other.GetComponentInChildren<WeaponSlotManager>();
                weaponSlotManager.CloseDamageCollider();
                playerStats.TakeDamage(damage, 0);
            }
        }
    }
}
