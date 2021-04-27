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
        [HideInInspector] public Transform target;

        DamageCollider damageCollider;
        ParticleSystem particleSystem;

        private void Start()
        {
            damageCollider = GetComponent<DamageCollider>();
            particleSystem = GetComponent<ParticleSystem>();
            var emission = particleSystem.emission;
            emission.enabled = false;
        }

        public void Fire()
        {
            transform.SetParent(null);
            var emission = particleSystem.emission;
            emission.enabled = true;
            Vector3 targetPosition = target.position + new Vector3(0, 1.3f, 0);
            Vector3 fireDirection = Vector3.Normalize(targetPosition - transform.position);
            GetComponent<Rigidbody>().velocity = speed * fireDirection;
            damageCollider.EnableDamageCollider();
        }

        public void SetTeamID(Team teamID)
        {
            team = teamID;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
