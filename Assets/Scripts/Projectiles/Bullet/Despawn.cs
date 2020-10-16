using UnityEngine;
using Assets.Scripts.Utility;

namespace Assets.Scripts.Projectiles.Bullet
{
    public class Despawn : MonoBehaviour
    {
        float timezero;
        int currentLayer;
        int collisionCount;

        // Start is called before the first frame update
        void Start()
        {
            timezero = Time.timeSinceLevelLoad;
            currentLayer = this.gameObject.layer;
            collisionCount = 0;
        }

        void Update()
        {
            //Destroy once BULLET_LIFETIME is reached
            if (Time.timeSinceLevelLoad - timezero > Constants.BULLET_LIFETIME)
                Destroy(gameObject);
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Destroy on second rebound
            collisionCount++;
            if (collisionCount > 1)
                Destroy(this.gameObject);
        }
    }
}
