using Assets.Scripts.Utility;
using UnityEngine;
using Assets.Scripts.Player.Gun;
using Assets.Scripts.UIElements;

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
        private int shot_speed;

        void Start()
        {
            Blob = GetComponent<Rigidbody2D>();
            timeOfLastShot = Time.realtimeSinceStartup;
            isCharging = false;
            chargeTime = 0f;
            shot_speed = 90;
            shotPower.SetMaxValue(1);
            shotPower.SetValue(0);
        }

        // Update is called once per frame
        void Update()
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

            // Mouse button still pressed, increase charge time
            if (isCharging)
            {
                chargeTime += Time.deltaTime;
                if (shotPower.slider.value < 2)
                    shotPower.AddValue(Time.deltaTime);
                if (shotPower.slider.value > 2)
                {
                    //
                }
            }
            //timeOfLastShot is not working as expected
            if (Input.GetMouseButtonDown(0) && currentTime - timeOfLastShot > 0.1f)
            {
                isCharging = true;
            }

            
            // Shoot when mouse button is released
            if (Input.GetMouseButtonUp(0))
            {
                isCharging = false;
                currentBullet = ShootArrow(chargeTime);
                shotPower.SetValue(0);
                chargeTime = 0;
                timeOfLastShot = Time.realtimeSinceStartup;
            }
        }
        
        public GameObject ShootArrow(float shotIntensity)
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
            shotIntensity = GetFinalShotIntensity(shotIntensity);
            //Apply normalized velocity vector to bullet in direction of mouse
            Utils.ApplyVelocity(projectileRB, mouseVector2d.normalized.x * shot_speed * shotIntensity, mouseVector2d.normalized.y * shot_speed * shotIntensity);

            return projectile;
        }
        private float GetFinalShotIntensity(float shotIntensity)
        {
            float maxTimeRange = 1f;
            float minTimeRange = 0.2f;
            float result = 0f;
            //max is 1, min is 0.001
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
    
