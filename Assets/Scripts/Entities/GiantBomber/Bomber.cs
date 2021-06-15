using Assets.Scripts.Enemies.BaseEntityScripts;
using Assets.Scripts.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies.GiantBomber
{
    public class Bomber : MonoBehaviour
    {
        private GameObject projectilePrefab;
        private float timer;
        private void Start()
        {
            timer = 0;
        }
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                ThrowBomb();
                timer = 0;
            }
        }
        private void ThrowBomb()
        {
            Vector2 shotAngle = new Vector2(-1, 1);


            // Spawn arrow
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(shotAngle));

            // Set damage of arrow
            //DamageDealer damageDealer = projectile.GetComponent<DamageDealer>();
            //damageDealer.DamagePercentage = shotIntensity;

            // Set velocity of arrow
            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            Utils.ApplyVelocity(projectileRB, shotAngle.x * 150, shotAngle.y * 150);
        }
    }
}
