using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        public EnemyManager enemy;

        public void RespawnEnemy()
        {
            enemy.transform.position = transform.position;
            enemy.transform.rotation = transform.rotation;
            enemy.Respawn();
        }
    }
}
