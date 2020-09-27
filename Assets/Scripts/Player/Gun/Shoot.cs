using Assets.Scripts.Utility;
using UnityEngine;
namespace Assets.Scripts.Player.Gun
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        private Rigidbody2D Blob;
        void Start()
        {
            Blob = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootProjectile();
            }

        }
        void ShootProjectile()
        {
            //Vector between mouse and current position
            Vector3 mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(Blob.position.x, Blob.position.y, 0) ;
            Vector2 mouseVector2d = new Vector2(mouseVector.x, mouseVector.y);

            //Spawn projectile away from player to avoid collision issues
            Vector2 spawnPosition = Blob.position + mouseVector2d * 0.3f;

            GameObject projectile = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            projectile.tag = Constants.PLAYER_BULLET_TAG;
            projectile.layer = Constants.ENEMY_LAYER;
            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            //Transform projectileTR = projectile.GetComponent<Transform>();

            //Apply normalized velocity vector to bullet in direction of mouse
            Utils.ApplyVelocity(projectileRB, mouseVector2d.normalized.x * Constants.BULLET_SPEED, mouseVector2d.normalized.y * Constants.BULLET_SPEED);
        }
    }
}
    
