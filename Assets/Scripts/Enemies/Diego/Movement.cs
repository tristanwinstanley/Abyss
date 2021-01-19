using Assets.Scripts.Utility;
using UnityEngine;
namespace Assets.Scripts.Enemies.Diego
{
    public class Movement : MonoBehaviour
    {
        Rigidbody2D rb;
        float previousDirection;
        SpriteRenderer spriteRenderer;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            
            // Move left slowly
            rb.velocity = new Vector2(-6, rb.velocity.y);
        }
    }

}
