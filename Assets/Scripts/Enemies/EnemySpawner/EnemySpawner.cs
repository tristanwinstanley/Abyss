using Assets.Scripts.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies.EnemySpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject kamiPrefab;
        [SerializeField] private GameObject diegoPrefab;
        private float timeSinceLastKami;
        private float timeSinceLastDiego;
        private List<GameObject> _currentEnemies;
        private int currentRound;
        private float currentRoundTime;
        private float timer;
        private GameObject roundStarter;

        public bool CanSpawn { get; set; }
        void Start()
        {
            _currentEnemies = new List<GameObject>();
            roundStarter = GameObject.FindWithTag(Constants.ROUNDSTARTER_TAG);
        }

        public void StartRound()
        {
            CanSpawn = true;
            currentRound++;
            currentRoundTime = GetRoundTime(currentRound);
            timer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            ClearDestroyedInstances();
            if (CanSpawn)
            {
                timer += Time.deltaTime;
                if (timer <= currentRoundTime)
                {
                    List<GameObject> enemyPrefab = GetNextPrefabsToSpawn();
                    foreach (GameObject prefab in enemyPrefab)
                    {
                        GameObject prefabInstance = Instantiate(prefab, this.transform.position, Quaternion.identity);
                        _currentEnemies.Add(prefabInstance);
                    }
                }
                else
                {
                    // End of round
                    CanSpawn = false;
                }
            }

            // Show Start button when all enemies are dead
            if (_currentEnemies.Count == 0)
            {
                roundStarter.SetActive(true);
            }
        }

        private float GetRoundTime(int roundNumber)
        {
            float roundTime = 0;
            switch (roundNumber)
            {
                case 1:
                    roundTime = 5f;
                    break;
                case 2:
                    roundTime = 20f;
                    break;
                case 3:
                    roundTime = 30f;
                    break;
                case 4:
                    roundTime = 40f;
                    break;
            }
            return roundTime;
        }
        private void ClearDestroyedInstances()
        {
            _currentEnemies.RemoveAll(x => x == null);
        }

        private List<GameObject> GetNextPrefabsToSpawn()
        {
            List<GameObject> prefabs = new List<GameObject>();
            if (Time.realtimeSinceStartup - timeSinceLastKami > Constants.KAMI_SPAWN_FREQUENCY)
            {
                timeSinceLastKami = Time.realtimeSinceStartup;
                prefabs.Add(kamiPrefab);
            }

            if (Time.realtimeSinceStartup - timeSinceLastDiego > Constants.DIEGO_SPAWN_FREQUENCY)
            {
                timeSinceLastDiego = Time.realtimeSinceStartup;
                prefabs.Add(diegoPrefab);
            }

            return prefabs;
        }
    }
}

