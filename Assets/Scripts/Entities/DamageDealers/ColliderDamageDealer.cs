using Assets.Scripts.Enemies.BaseEntityScripts;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Entities.DamageDealers
{
    public class ColliderDamageDealer : DamageDealer
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            InflictDamage(col.gameObject, Damage);
            Destroy(gameObject);
        }
    }
}
