using Assets.Scripts.Enemies.BaseEntityScripts;
using Assets.Scripts.UIElements;
using Assets.Scripts.Utility;

namespace Assets.Scripts.Castle
{
    public class CastleHealthController : HealthController
    {
        //public MySlider _healthBar;
        //public float Health;

        new void Start()
        {
            base.Start();
        }
        new void Update()
        {
            HealthBar.SetValue(Health);

            //Kill when zero health
            if (Health == 0)
            {
                //end game
            }
        }
    }
}

