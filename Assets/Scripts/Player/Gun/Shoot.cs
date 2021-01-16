﻿using Assets.Scripts.Utility;
using UnityEngine;
using Assets.Scripts.Player.Gun;
namespace Assets.Scripts.Player.Gun
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject arrowPrefab;
        private Rigidbody2D Blob;
        private float timeOfLastShot;
        private GameObject currentBullet;
        public int shot_speed;
        void Start()
        {
            Blob = GetComponent<Rigidbody2D>();
            timeOfLastShot = Time.realtimeSinceStartup;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float currentTime = Time.realtimeSinceStartup;
            //if (Input.GetMouseButtonDown(0) && currentTime - timeOfLastShot > .05f)
            //{
            //    //Only 1 bullet at a time
            //    //if (currentBullet != null)
            //    //    Destroy(currentBullet);
            //    currentBullet = ShootBullet();
            //    timeOfLastShot = Time.realtimeSinceStartup;
            //}

            if (Input.GetMouseButtonDown(0) && currentTime - timeOfLastShot > .05f)
            {
                currentBullet = ShootArrow();
                timeOfLastShot = Time.realtimeSinceStartup;
            }

        }
        
        public GameObject ShootArrow()
        {
            //Vector between mouse and current position
            Vector3 mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(Blob.position.x, Blob.position.y, 0);
            Vector2 mouseVector2d = new Vector2(mouseVector.x, mouseVector.y);

            //Angle between mouse and right vector 0-360 deg
            Vector3 mouseAngle = SelfRotation.ComputeTotalAngle(mouseVector2d, Vector3.right);
            
            //Spawn projectile away from player to avoid collision issues
            Vector2 spawnPosition = Blob.position + mouseVector2d.normalized * 8;
            GameObject projectile = Instantiate(arrowPrefab, spawnPosition, Quaternion.Euler(mouseAngle));
            projectile.tag = Constants.PLAYER_BULLET_TAG;
            projectile.layer = Constants.ENEMY_LAYER;
            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            //Transform projectileTR = projectile.GetComponent<Transform>();

            //Apply normalized velocity vector to bullet in direction of mouse
            Utils.ApplyVelocity(projectileRB, mouseVector2d.normalized.x * shot_speed, mouseVector2d.normalized.y * shot_speed);

            return projectile;
        }
        GameObject ShootBullet()
        {
            //Vector between mouse and current position
            Vector3 mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(Blob.position.x, Blob.position.y, 0) ;
            Vector2 mouseVector2d = new Vector2(mouseVector.x, mouseVector.y);

            //Spawn projectile away from player to avoid collision issues
            Vector2 spawnPosition = Blob.position + mouseVector2d.normalized * 8;

            GameObject projectile = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            projectile.tag = Constants.PLAYER_BULLET_TAG;
            projectile.layer = Constants.ENEMY_LAYER;
            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            //Transform projectileTR = projectile.GetComponent<Transform>();

            //Apply normalized velocity vector to bullet in direction of mouse
            Utils.ApplyVelocity(projectileRB, mouseVector2d.normalized.x * shot_speed, mouseVector2d.normalized.y * shot_speed);

            return projectile;
        }
    }
}
    
