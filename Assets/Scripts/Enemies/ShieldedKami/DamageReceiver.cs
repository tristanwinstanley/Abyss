using Assets.Scripts.UIElements;
using Assets.Scripts.Utility;
using UnityEngine;
using static Assets.Scripts.Utility.Enums;

namespace Assets.Scripts.Enemies.ShieldedKami
{
    public class DamageReceiver : MonoBehaviour
    {
        private BoxCollider2D monsterCollider;
        private int health;
        public HealthBar _healthBar;
        void Start()
        {
            health = Constants.KAMI_HEALTH;
            _healthBar.SetMaxValue(health);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject player = GameObject.FindWithTag(Constants.PLAYER_TAG);

            float direction;
            if (player.transform.position.x - transform.position.x > 0)
                direction = 1;//facing right
            else
                direction = -1;//facing left
            Stance currentStance;
            if (direction == player.transform.right.x)
                currentStance = Stance.Attack;
            else
                currentStance = Stance.Defense;
            

            //Lose 1 health on bullet collision and when not defending
            if (collision.tag == Constants.PLAYER_BULLET_TAG && currentStance != Stance.Defense)
            {
                health -= 2;
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

