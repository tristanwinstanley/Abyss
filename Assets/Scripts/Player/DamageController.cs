using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.UIElements;

namespace Assets.Scripts.Player
{
    public class DamageController : MonoBehaviour
    {
        public MySlider healthBar;
        private Rigidbody2D bulletRB;
        private Transform bulletTransform;
        private int currentHealth;
        int currentLayer;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = Constants.PLAYER_HEALTH;
            healthBar.SetMaxValue(currentHealth);
            currentLayer = this.gameObject.layer;
        }

        // Update is called once per frame
        void Update()
        {
            healthBar.SetValue(currentHealth);

            //Kill when zero health
            if (currentHealth == 0)
                Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Lose 1 health on bullet collision
            if (collision.tag == Constants.ENEMY_BULLET_TAG)
            {
                currentHealth -= 1;
                Debug.Log(currentHealth);
            }

        }
    }
}

