using Assets.Scripts.Enemies.BaseEntityScripts;
using Assets.Scripts.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities.DamageDealers
{
    public class Kamikaze : DamageDealer
    {
        private GameObject castle;
        void Start()
        {
            castle = GameObject.FindWithTag(Constants.CASTLE_TAG);
        }
        public void Update()
        {
            if (transform.position.x < -15)
            {
                SelfDestruct();
            }
        }
        /// <summary>
        /// Inflict damage and then die
        /// </summary>
        private void SelfDestruct()
        {
            InflictDamage(castle, Damage);
            Destroy(gameObject);
        }
    }
}
