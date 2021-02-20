using Assets.Scripts.Enemies.BaseEntityScripts;
using Assets.Scripts.Projectiles.Arrow;
using Assets.Scripts.UIElements;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Player.Gun
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject arrowPrefab;
        public MySlider shotPower;
        private Rigidbody2D Blob;
        private float timeOfLastShot;
        private GameObject currentBullet;
        public bool isCharging;
        private float chargeTime;
        public int shot_speed;
        private float maxTimeRange;
        private GameObject Hinge;
        private bool shootAtMouse = true;
        void Start()
        {
            Blob = GetComponent<Rigidbody2D>();
            timeOfLastShot = Time.realtimeSinceStartup;
            isCharging = false;
            chargeTime = 0f;
            maxTimeRange = 0.75f;
            shotPower.SetMaxValue(maxTimeRange);
            shotPower.SetValue(0);
            Hinge = GameObject.FindWithTag(Constants.HINGE_TAG);
        }

        // Update is called once per frame
        void Update()
        {

            // Mouse button still pressed, increase charge time
            if (isCharging)
            {
                chargeTime += Time.deltaTime;
                // Add to power only if value hasn't reached x
                if (shotPower.slider.value < 2)
                    shotPower.AddValue(Time.deltaTime);
            }

            if (Input.GetMouseButtonDown(0))
            {
                isCharging = true;
            }

            
            // Shoot when mouse button is released
            if (Input.GetMouseButtonUp(0))
            {
                isCharging = false;
                float shotIntensity = GetFinalShotIntensity(chargeTime);
                ShootArrow(shotIntensity);
                shotPower.SetValue(0);
                chargeTime = 0;
                timeOfLastShot = Time.realtimeSinceStartup;
            }
        }
        /// <summary>
        /// Spawn arrow and apply velocity to it
        /// </summary>
        private void ShootArrow(float shotIntensity)
        {
            Vector2 shotVector = GetShotVector();
            Vector2 shotAngle = GetShotAngle(shotVector);

            // Spawn arrow away from player to avoid collisions
            Vector2 spawnPosition = Blob.position + shotVector * 8;

            // Spawn arrow
            GameObject projectile = Instantiate(arrowPrefab, spawnPosition, Quaternion.Euler(shotAngle));
            projectile.tag = Constants.PLAYER_BULLET_TAG;

            // Set damage of arrow
            DamageDealer damageDealer = projectile.GetComponent<DamageDealer>();
            damageDealer.DamagePercentage = shotIntensity;

            // Set velocity of arrow
            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            Utils.ApplyVelocity(projectileRB, shotVector.x * shot_speed * shotIntensity, shotVector.y * shot_speed * shotIntensity);
        }

        private Vector2 GetShotVector()
        {
            Vector2 shotVector;
            if (shootAtMouse)
            {
                //Vector between mouse and current position
                Vector3 mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(Blob.position.x, Blob.position.y, 0);
                shotVector = new Vector2(mouseVector.x, mouseVector.y);
                shotVector = shotVector.normalized;
            }
            else
            {
                shotVector = SelfRotation.DegreeToVector2(Hinge.transform.rotation.eulerAngles.z);
                // Shoot left when player is looking left
                if (transform.right.x == -1f)
                    shotVector *= new Vector2(-1, 1);
            }

            return shotVector;
        }

        private Vector2 GetShotAngle(Vector2 shotVector)
        {
            Vector2 shotAngle;
            if (shootAtMouse)
            {
                //Angle between mouse and right vector 0-360 deg
                shotAngle = SelfRotation.ComputeTotalAngle(shotVector, Vector3.right);
            }
            else
            {
                shotAngle = Hinge.transform.rotation.eulerAngles;
            }

            return shotAngle;
        }
        
        private float GetFinalShotIntensity(float shotIntensity)
        {
            float minTimeRange = 0.2f;
            float result;
            // min is minTimeRange , max is 1
            if (shotIntensity < minTimeRange)
                result = minTimeRange / maxTimeRange;
            else if (shotIntensity < maxTimeRange)
                result = shotIntensity / maxTimeRange;
            else
                result = 1;

            return result;
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
    
