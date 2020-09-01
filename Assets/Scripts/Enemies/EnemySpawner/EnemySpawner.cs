using Assets.Scripts.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies.EnemySpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject sniperPrefab;
        float timeSinceLastSpawn;
        List<GameObject> _currentEnemies;
        int _currentHealth;
        void Start()
        {
            _currentEnemies = new List<GameObject>();
            _currentHealth = Constants.ENEMY_SPAWNER_HEALTH;
        }

        // Update is called once per frame
        void Update()
        {
            if (_currentHealth == 0)
                Destroy(gameObject);

            ClearDestroyedInstances();

            //Spawn new enemy after 10s if fewer than 5
            if (Time.realtimeSinceStartup - timeSinceLastSpawn > Constants.ENEMY_SPAWN_FREQUENCY && _currentEnemies.Count < 5)
            {
                GameObject prefabInstance = Instantiate(sniperPrefab, this.transform.position, Quaternion.identity);
                timeSinceLastSpawn = Time.realtimeSinceStartup;
                _currentEnemies.Add(prefabInstance);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Lose 1 health on bullet collision
            if (collision.tag == Constants.PLAYER_BULLET_TAG)
            {
                _currentHealth -= 1;
            }

        }

        private void ClearDestroyedInstances()
        {
            _currentEnemies.RemoveAll(x => x == null);
        }
    }
}

