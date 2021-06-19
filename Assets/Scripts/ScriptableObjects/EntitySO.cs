using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Entity SO", menuName = "EntitySO")]
    public class EntitySO : ScriptableObject
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private int damage;
        [SerializeField] private int speed;
        public float MaxHealth { get { return maxHealth; } private set { maxHealth = value; } }

        public int Damage { get { return damage; } private set { damage = value; } }
        public int Speed { get { return speed; } private set { speed = value; } }
    }
}
