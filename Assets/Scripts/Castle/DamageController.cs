using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.UIElements;

namespace Assets.Scripts.Castle
{
    public class DamageController : MonoBehaviour
    {
        public float currentHealth;
        public MySlider healthBar;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = Constants.PLAYER_HEALTH;
            healthBar.SetMaxValue(currentHealth);
            healthBar.SetValue(currentHealth);
        }

        // Update is called once per frame
        void Update()
        {
            healthBar.SetValue(currentHealth);

            //Kill when zero health
            if (currentHealth == 0)
            {
                //end game
            }
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            healthBar.SetValue(currentHealth);
        }
    }
}

