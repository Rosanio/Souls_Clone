using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public class GameManager : MonoBehaviour
    {
        public PlayerManager player;
        public Transform lastCheckpoint;
        public EnemySpawnPoint[] enemySpawnPoints;

        private void Awake()
        {
            enemySpawnPoints = GetComponentsInChildren<EnemySpawnPoint>();
        }

        private void Start()
        {
            lastCheckpoint.position = player.transform.position;
            lastCheckpoint.rotation = player.transform.rotation;
        }

        public void OnCheckpointEnter(Transform respawnPosition)
        {
            ResetEnemies();
            lastCheckpoint.position = respawnPosition.position;
            lastCheckpoint.rotation = respawnPosition.rotation;
        }

        public void ResetPlayerAndEnemies()
        {
            player.transform.position = lastCheckpoint.position;
            player.transform.rotation = lastCheckpoint.rotation;

            ResetEnemies();
        }

        public void ResetEnemies()
        {
            foreach (EnemySpawnPoint enemySpawnPoint in enemySpawnPoints)
            {
                enemySpawnPoint.RespawnEnemy();
            }
        }
    }
}
