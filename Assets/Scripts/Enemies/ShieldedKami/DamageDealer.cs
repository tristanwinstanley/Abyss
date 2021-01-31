using Assets.Scripts.Enemies.BaseEnemies;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemies.ShieldedKami
{
    public class DamageDealer : MonoBehaviour
    {
        void Start()
        {
        }
        public void Update()
        {
            if (transform.position.x < -14)
            {
                GameObject castle = GameObject.FindWithTag(Constants.CASTLE_TAG);
                castle.GetComponent<BaseDamageReceiver>().TakeDamage(0.1f);
            }
        }
    }
}

