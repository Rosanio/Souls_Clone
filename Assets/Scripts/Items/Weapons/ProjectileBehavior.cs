using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class ProjectileBehavior : MonoBehaviour
    {
        public float speed;
        public int damage;
        public int poiseDamage;

        [HideInInspector] public Team team;

        DamageCollider damageCollider;

        private void Start()
        {
            damageCollider = GetComponent<DamageCollider>();
            GetComponent<Rigidbody>().velocity = speed * transform.up;
            damageCollider.EnableDamageCollider();
        }

        public void SetTeamID(Team teamID)
        {
            team = teamID;
        }
    }
}
