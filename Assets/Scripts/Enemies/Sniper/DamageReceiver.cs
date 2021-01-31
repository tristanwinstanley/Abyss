using Assets.Scripts.UIElements;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemies.Sniper
{
    public class DamageReceiver : MonoBehaviour
    {
        private BoxCollider2D monsterCollider;
        private int health;
        public MySlider _healthBar;
        void Start()
        {
            health = Constants.KAMI_HEALTH;
            _healthBar.SetMaxValue(health);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Lose 1 health on bullet collision
            if (collision.tag == Constants.PLAYER_BULLET_TAG)
            {
                health -= 1;
                _healthBar.SetValue(health);
            }
                
        }
        void Update()
        {
            if (health == 0)
                Destroy(gameObject);
        }

    }
}

