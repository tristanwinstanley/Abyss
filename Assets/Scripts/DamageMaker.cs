using Assets.Utility;
using UnityEngine;

namespace Assets.Scripts
{
    public class DamageMaker : MonoBehaviour
    {
        private BoxCollider2D monsterCollider;
        private int health;
        void Start()
        {
            health = Constants.MONSTER_HEALTH;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Lose 1 health on bullet collision
            if (collision.tag == Constants.PLAYER_BULLET_TAG)
            {
                health -= 1;
                Debug.Log(health);
            }
                
        }
        void Update()
        {
            //Destroy once BULLET_LIFETIME is reached
            if (health == 0)
                Destroy(gameObject);

        }

    }
}

