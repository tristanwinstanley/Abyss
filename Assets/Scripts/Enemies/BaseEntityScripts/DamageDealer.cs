using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class DamageDealer: MonoBehaviour
    {
        private GameObject castle;
        public float Damage;
        void Start()
        {
            castle = GameObject.FindWithTag(Constants.CASTLE_TAG);
        }
        public void Update()
        {
            if (transform.position.x < -15)
            {
                castle.GetComponent<DamageReceiver>().TakeDamage(Damage);
            }
        }
    }
}

