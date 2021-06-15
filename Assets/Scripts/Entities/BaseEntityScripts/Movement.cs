using UnityEngine;
namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private int speed;
        private Rigidbody2D rb;
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Move left slowly
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

}
