using Assets.Scripts.Utility;
using UnityEngine;
namespace Assets.Scripts.Player
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D blob;
        private int jumpCount;
        public bool grounded;
        private Collider2D collider;
        private Vector2 velocity;
        private float timeOfLastJump;

        private int playerSpeed = 80;
        public int jumpforce = 40;
        void Start()
        {
            blob = GetComponent<Rigidbody2D>();
            collider = GetComponent<Collider2D>();
            jumpCount = 0;
            timeOfLastJump = Time.realtimeSinceStartup;
            
        }
        void Update()
        {
            velocity = blob.velocity;

            //Get User input
            float HorizontalAx = Input.GetAxisRaw("Horizontal");
            float VerticalAx = Input.GetAxisRaw("Vertical");

            //Horizontal Move
            if (HorizontalAx != 0)
            {
                Utils.ApplyVelocity(blob, HorizontalAx * playerSpeed, velocity.y);
            }

            // Make sprite look left and right
            if (HorizontalAx != 0 && transform.right.x != HorizontalAx)
            {
                //transform.Rotate(0, 180, 0);
            }

            //Jump every 0.2s
            float currentTime = Time.realtimeSinceStartup;
            if (Input.GetKeyDown("space") && currentTime - timeOfLastJump > 0.2f)
            {
                if (grounded || jumpCount == 1)
                {
                    Utils.ApplyVelocity(blob, y: jumpforce);
                    jumpCount++;
                }

                //Reset timer
                timeOfLastJump = currentTime;
            }

            //Cap Speed
            CapVerticalPlayerSpeed();
        }

        private void CapVerticalPlayerSpeed()
        {
            if (blob.velocity.y > Constants.PL_MAX_UP_SPEED)
                Utils.ApplyVelocity(blob, y: Constants.PL_MAX_UP_SPEED);
            else if (blob.velocity.y < -Constants.PL_MAX_DOWN_SPEED)
                Utils.ApplyVelocity(blob, x: blob.velocity.x, y: -Constants.PL_MAX_DOWN_SPEED);

        }
        void OnCollisionEnter2D(Collision2D collision)
        {    
            if (collision.gameObject.tag == "Floor")
            {
                grounded = true;
                jumpCount = 0;
            }
        }
        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                grounded = false;
            }
        }
    }
}
    

