using UnityEngine;

namespace Assets.Scripts.Enemies.EnemySpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject sniperPrefab;
        float timeSinceLastSpawn;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Time.realtimeSinceStartup - timeSinceLastSpawn > 10f)
            {
                GameObject prefabInstance = Instantiate(sniperPrefab, this.transform.position, Quaternion.identity);
                timeSinceLastSpawn = Time.realtimeSinceStartup;
            }
        }
    }
}

