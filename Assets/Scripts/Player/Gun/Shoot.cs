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
        public int shot_speed;
        private float maxTimeRange;
        private GameObject Hinge;
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
            float currentTime = Time.realtimeSinceStartup;

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
            if (Input.GetMouseButtonDown(0))
            {
                isCharging = true;
            }

            
            // Shoot when mouse button is released
            if (Input.GetMouseButtonUp(0))
            {
                isCharging = false;
                ShootArrowAtMouse(chargeTime);
                shotPower.SetValue(0);
                chargeTime = 0;
                timeOfLastShot = Time.realtimeSinceStartup;
            }
        }

        public GameObject ShootArrowAtMouse(float shotIntensity)
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
            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            shotIntensity = GetFinalShotIntensity(shotIntensity);
            //Apply normalized velocity vector to bullet in direction of mouse
            Utils.ApplyVelocity(projectileRB, mouseVector2d.normalized.x * shot_speed * shotIntensity, mouseVector2d.normalized.y * shot_speed * shotIntensity);
            return projectile;
        }

        public GameObject ShootArrow(float shotIntensity)
        {
            Vector3 shotAngle = Hinge.transform.rotation.eulerAngles;
            Vector2 shotVector = SelfRotation.DegreeToVector2(Hinge.transform.rotation.eulerAngles.z);

            // Shoot left when player is looking left
            if (transform.right.x == -1f)
                shotVector *= new Vector2(-1, 1);
            
            // Spawn arrow away from player to avoid collisions
            Vector2 spawnPosition = Blob.position + shotVector * 8;

            GameObject projectile = Instantiate(arrowPrefab, spawnPosition, Quaternion.Euler(shotAngle));
            projectile.tag = Constants.PLAYER_BULLET_TAG;
            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            shotIntensity = GetFinalShotIntensity(shotIntensity);


            //Apply normalized velocity vector to bullet in direction of mouse
            Utils.ApplyVelocity(projectileRB, shotVector.x * shot_speed * shotIntensity, shotVector.y * shot_speed * shotIntensity);

            return projectile;
        }
        private float GetFinalShotIntensity(float shotIntensity)
        {
            float minTimeRange = 0.2f;
            float result;
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
    
