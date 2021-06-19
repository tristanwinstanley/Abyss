using Assets.Scripts.Entities.BaseEntityScripts;
using UnityEngine;
namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class Movement : MonoBehaviour
    {
        private EntityData entityData;
        private Rigidbody2D rb;
        private int speed;
        
        void Start()
        {
            entityData = GetComponent<EntityData>();
            rb = GetComponent<Rigidbody2D>();
            speed = entityData.entitySO.Speed;
        }

        // Update is called once per frame
        void Update()
        {
            // Move left slowly
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

}
