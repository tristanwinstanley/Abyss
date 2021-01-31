using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.UIElements;
using Assets.Scripts.Enemies.BaseEnemies;

namespace Assets.Scripts.Castle
{
    public class HealthController : BaseHealthController
    {
        public MySlider _healthBar;

        // Start is called before the first frame update
        new void Start()
        {
            base.Start();
            _health = Constants.CASTLE_HEALTH;
            _healthBar.SetMaxValue(_health);
            _healthBar.SetValue(_health);
        }

        // Update is called once per frame
        new void Update()
        {
            _healthBar.SetValue(_health);

            //Kill when zero health
            if (_health == 0)
            {
                //end game
            }
        }
    }
}

