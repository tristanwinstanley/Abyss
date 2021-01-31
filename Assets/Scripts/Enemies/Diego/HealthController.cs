using Assets.Scripts.Enemies.BaseEnemies;
using Assets.Scripts.UIElements;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemies.Diego
{
    public class HealthController : BaseHealthController
    {
        public MySlider _healthBar;
        new void Start()
        {
            base.Start();
            _health = Constants.DIEGO_HEALTH;
            _healthBar.SetMaxValue(_health);
            _healthBar.SetValue(_health);
        }
        new void Update()
        {
            _healthBar.SetValue(_health);
            base.Update();
        }

    }
}