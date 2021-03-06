﻿using UnityEngine;
using System;

namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class DamageReceiver : MonoBehaviour
    {
        private HealthController healthController;

        #region Unity Methods
        protected void Start()
        {
            // Find HealthController attached to current gameobject or root gameObject
            // Use root so that this damage receiver can be anywhere on the tree of gameObjects
            healthController = gameObject.GetComponent<HealthController>() ?? transform.root.GetComponent<HealthController>();
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
                healthController.AddToHealth(-damage * 3);
            else
                healthController.AddToHealth(-damage);
        }
        #endregion


    }
}
