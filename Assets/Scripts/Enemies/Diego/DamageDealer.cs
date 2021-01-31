using Assets.Scripts.Castle;
using Assets.Scripts.Enemies.BaseEnemies;
using Assets.Scripts.UIElements;
using Assets.Scripts.Utility;
using UnityEngine;
using static Assets.Scripts.Utility.Enums;

namespace Assets.Scripts.Enemies.Diego
{
    public class DamageDealer: MonoBehaviour
    {
        void Start()
        {
        }
        public void Update()
        {
            if (transform.position.x < -15)
            {
                GameObject castle = GameObject.FindWithTag(Constants.CASTLE_TAG);
                castle.GetComponent<BaseDamageReceiver>().TakeDamage(0.5f);
            }
        }
    }
}

