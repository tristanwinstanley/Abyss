using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class DamageDealer: MonoBehaviour
    {
        public float Damage;
        public float DamagePercentage { get; set; }
        public void Awake()
        {
            DamagePercentage = 1;
        }
        
        public void InflictDamage(GameObject target, float damage)
        {
            DamageReceiver damageReceiver = target.GetComponent<DamageReceiver>();
            if (damageReceiver != null)
            {
                damageReceiver.TakeDamage(DamagePercentage * damage);
            }
        }
    }
}

