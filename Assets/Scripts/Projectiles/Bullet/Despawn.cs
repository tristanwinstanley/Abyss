using UnityEngine;
using Assets.Scripts.Utility;

namespace Assets.Scripts.Projectiles.Bullet
{
    public class Despawn : MonoBehaviour
    {
        float timezero;
        int currentLayer;

        // Start is called before the first frame update
        void Start()
        {
            timezero = Time.timeSinceLevelLoad;
            currentLayer = this.gameObject.layer;
        }

        void Update()
        {
            //Destroy once BULLET_LIFETIME is reached
            if (Time.timeSinceLevelLoad - timezero > Constants.BULLET_LIFETIME)
                Destroy(gameObject);
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Destroy when collider touches something in the same layer
            if (currentLayer == collision.gameObject.layer)
            {
                Destroy(gameObject);
            }

        }
    }
}
