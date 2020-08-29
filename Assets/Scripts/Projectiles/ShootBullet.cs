using Assets.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Projectiles
{
    public class ShootBullet : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;

        public void Shoot(Vector2 position, Vector2 velocity)
        {
            Instantiate(bulletPrefab, position, Quaternion.identity);
            Utils.ApplyVelocity(bulletPrefab.GetComponent<Rigidbody2D>(), velocity.normalized.x, velocity.normalized.y);
        }
    }
}
    
