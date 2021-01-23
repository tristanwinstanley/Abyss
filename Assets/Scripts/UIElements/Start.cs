using Assets.Scripts.Enemies.EnemySpawner;
using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UIElements
{
    public class Start : MonoBehaviour
    {
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Start new round when player hits start button
            if (collision.tag == Constants.PLAYER_BULLET_TAG)
            {
                GameObject spawner = GameObject.FindWithTag(Constants.SPAWNER_TAG);
                spawner.GetComponent<EnemySpawner>().StartRound();
                // Hide Start button
                gameObject.SetActive(false);
            }

        }
    }
}
