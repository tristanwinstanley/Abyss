using Assets.Scripts.UIElements;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class HealthController : MonoBehaviour
    {
        public float Health;
        private GameObject player;
        public MySlider HealthBar;

        #region Unity Methods
        protected void Start()
        {
            player = GameObject.FindWithTag("Player");
            if (HealthBar != null)
            {
                HealthBar.SetMaxValue(Health);
                HealthBar.SetValue(Health);
            }
        }

        protected void Update()
        {
            if (HealthBar != null)
                HealthBar.SetValue(Health);
            if (Health <= 0)
                Die();
        }
        #endregion

        #region Custom Methods
        /// <summary>
        /// Should be called from a Damage Receiver, amends the health of the entity positively (heal) or negatively (damage)
        /// </summary>
        public void AddToHealth(float value)
        {
            Health += value;
        }

        private void Die()
        {
            if (gameObject.layer == Constants.ENEMY_LAYER)
            {
                GameObject player = GameObject.FindWithTag("Player");
                
                ExperienceController xpController = player.GetComponent<ExperienceController>();
                if (xpController != null)
                {
                    xpController.AddExperience(1);
                }
            }
            Destroy(gameObject);
        }
        #endregion


    }
}
