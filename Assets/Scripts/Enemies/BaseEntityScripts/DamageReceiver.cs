using UnityEngine;
using System;

namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class DamageReceiver : MonoBehaviour
    {
        private HealthController _healthController;

        #region Unity Methods
        protected void Start()
        {
            // Find BaseHealthController attached to transform of root gameObject
            // Use root so that this damage receiver can be anywhere on the tree of gameObjects
            _healthController = transform.root.GetComponent<HealthController>();
        }

        protected void Update()
        {

        }
        #endregion

        #region Custom Methods
        /// <summary>
        /// Should be called from external scripts attached to projectiles for example
        /// TakeDamage then applies some processing to the damage depending on which collider is hit and then sends the damage to the health controller which will modify the health
        /// </summary>
        public void TakeDamage(float damage)
        {
            // Take triple damage on headshot
            if (tag == "HeadCollider")
                _healthController.AddToHealth(-damage * 3);
            else
                _healthController.AddToHealth(-damage);
        }
        #endregion


    }
}
