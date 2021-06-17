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
        public float Health;
        public int Damage;
        public int Speed;
    }
}
