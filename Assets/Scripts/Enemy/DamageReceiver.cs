using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class DamageReceiver : MonoBehaviour
    {
        private BoxCollider2D monsterCollider;
        private int health;
        int currentLayer;
        void Start()
        {
            health = Constants.MONSTER_HEALTH;
            currentLayer = this.gameObject.layer;
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
            if (health == 0)
                Destroy(gameObject);
        }

    }
}

