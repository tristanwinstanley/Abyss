using Assets.Scripts.Utility;
using UnityEngine;
namespace Assets.Scripts.Enemies.Sniper
{
    public class AutoShoot : MonoBehaviour
    {
        Transform CurrentTransform;
        [SerializeField] private GameObject projectilePrefab;
        float timeSinceLastShot;
        void Start()
        {
            CurrentTransform = GetComponent<Transform>();
            timeSinceLastShot = Time.realtimeSinceStartup;
        }


        // Update is called once per frame
        void Update()
        {
            if (Time.realtimeSinceStartup - timeSinceLastShot > 0.5f)
            {
                timeSinceLastShot = Time.realtimeSinceStartup;
                //Normalized vector between Current transform and player
                Vector2 projectileVelocityVector = Utils.Get2DNormVector(GameObject.FindWithTag(Constants.PLAYER_TAG).transform.position - CurrentTransform.position);
                //Shoot projectile from current position with specific direction and speed
                Shoot(transform.position, projectileVelocityVector * Constants.BULLET_SPEED);
            }
        }
        private void Shoot(Vector2 position, Vector2 velocity)
        {
            //Create an instance of prefab in world
            GameObject prefabInstance = Instantiate(projectilePrefab, position, Quaternion.identity);
            prefabInstance.tag = Constants.ENEMY_BULLET_TAG;
            //Apply velocity to prefab to make it move
            prefabInstance.layer = Constants.PLAYER_LAYER;
            Rigidbody2D prefabRB = prefabInstance.GetComponent<Rigidbody2D>();
            Utils.ApplyVelocity(prefabRB, velocity.x, velocity.y);
        }
    }

}

