using UnityEngine;

namespace Assets.Scripts.Enemies.BaseEnemies
{
    public class BaseHealthController : MonoBehaviour
    {
        protected float _health;
        
        #region Unity Methods
        protected void Start()
        {
            
        }

        protected void Update()
        {
            if (_health <= 0)
                Destroy(gameObject);
        }
        #endregion

        #region Custom Methods
        /// <summary>
        /// Should be called from a Damage Receiver, amends the health of the entity positively (heal) or negatively (damage)
        /// </summary>
        public void AddToHealth(float value)
        {
            _health += value;
        }
        #endregion


    }
}
