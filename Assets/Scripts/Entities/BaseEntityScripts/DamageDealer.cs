using Assets.Scripts.Entities.BaseEntityScripts;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class DamageDealer: MonoBehaviour
    {
        private float damage;
        public float DamagePercentage { get; set; }
        private EntityData entityData;
        public void Awake()
        {
            entityData = GetComponent<EntityData>();
            DamagePercentage = 1;
            damage = entityData.entitySO.Damage;
        }
        
        public void InflictDamage(GameObject target)
        {
            DamageReceiver damageReceiver = target.GetComponent<DamageReceiver>();
            if (damageReceiver != null)
            {
                damageReceiver.TakeDamage(DamagePercentage * damage);
            }
        }
    }
}

