using Assets.Utility;
using UnityEngine;
using UnityEngine.UI;
using Assets.UIElements;

namespace Assets.Scripts.Player
{
    public class DamageController : MonoBehaviour
    {
        private Rigidbody2D bulletRB;
        private Transform bulletTransform;
        public int health;
        public HealthBar healthBar;

        // Start is called before the first frame update
        void Start()
        {
            health = Constants.PLAYER_HEALTH;
            healthBar.SetMaxValue(health);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                health -= 10;
            }
            healthBar.SetValue(health);
        }

    }
}

