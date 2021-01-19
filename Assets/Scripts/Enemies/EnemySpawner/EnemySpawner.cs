using Assets.Scripts.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies.EnemySpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        float timeSinceLastSpawn;
        List<GameObject> _currentEnemies;
        void Start()
        {
            _currentEnemies = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            ClearDestroyedInstances();

            // Spawn new enemy after 10s if fewer than 5
            if (Time.realtimeSinceStartup - timeSinceLastSpawn > Constants.ENEMY_SPAWN_FREQUENCY && _currentEnemies.Count < 5)
            {
                GameObject prefabInstance = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
                timeSinceLastSpawn = Time.realtimeSinceStartup;
                _currentEnemies.Add(prefabInstance);
            }
        }

        private void ClearDestroyedInstances()
        {
            _currentEnemies.RemoveAll(x => x == null);
        }
    }
}

