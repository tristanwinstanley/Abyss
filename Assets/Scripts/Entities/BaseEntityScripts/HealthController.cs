using Assets.Scripts.UIElements;
using UnityEngine;

namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class HealthController : MonoBehaviour
    {
        public float Health;
        public MySlider HealthBar;

        #region Unity Methods
        protected void Start()
        {
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
                Destroy(gameObject);
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
        #endregion


    }
}
