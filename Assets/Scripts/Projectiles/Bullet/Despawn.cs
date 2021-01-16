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
        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            GameObject player = GameObject.FindWithTag(Constants.PLAYER_TAG);
            Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
            bool destroyCurrentGameObject = false;
            switch (otherCollider.gameObject.tag)
            {
                case Constants.PLAYER_TAG:
                    //destroyCurrentGameObject = true;
                    collisionCount++;
                    break;
                case Constants.JUMP_CLD_TAG:
                    Utils.ApplyVelocity(playerRB, y: 70);
                    //destroyCurrentGameObject = true;
                    break;
                default:
                    collisionCount++;
                    break;

            } 

            //Destroy on second rebound
            if (collisionCount > 5)
                destroyCurrentGameObject = true;

            if (destroyCurrentGameObject)
                Destroy(this.gameObject);
        }
    }
}
