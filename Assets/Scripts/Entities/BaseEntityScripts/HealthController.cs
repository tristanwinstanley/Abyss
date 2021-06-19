using Assets.Scripts.Entities.BaseEntityScripts;
using Assets.Scripts.UIElements;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class HealthController : MonoBehaviour
    {
        private GameObject player;
        private EntityData entityData;
        public MySlider HealthBar;
        public float Health { get; protected set; }

        #region Unity Methods
        protected void Start()
        {
            entityData = GetComponent<EntityData>();
            Health = entityData.entitySO.MaxHealth;
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
