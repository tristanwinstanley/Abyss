using Assets.Scripts.Enemies.BaseEnemies;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Projectiles.Arrow
{
    public class DamageDealer : MonoBehaviour
    {
        public float DamagePercentage { get; set; }
       
        private void OnTriggerEnter2D(Collider2D col)
        {
            InflictDamage(col);
        }
        
        private void InflictDamage(Collider2D col)
        {
            BaseDamageReceiver damageReceiver = col.gameObject.GetComponent<BaseDamageReceiver>();
            if (damageReceiver != null)
            {
                damageReceiver.TakeDamage(DamagePercentage * Constants.ARROW_DAMAGE);
            }
        }
        
    }
}
