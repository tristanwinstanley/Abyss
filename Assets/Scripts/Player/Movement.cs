using Assets.Scripts.Utility;
using UnityEngine;
namespace Assets.Scripts.Player
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D Blob;
        private int _jumpCount;
        public bool _grounded;
        private Collider2D _collider;
        private Vector2 velocity;
        private float timeOfLastJump;

        public int playerSpeed = 20;
        public int jumpforce = 40;
        [SerializeField]
        private Collider2D bottomCollider;
        void Start()
        {
            Blob = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
            _jumpCount = 0;
            timeOfLastJump = Time.realtimeSinceStartup;
        }
        void Update()
        {
            velocity = Blob.velocity;

            //Get User input
            float HorizontalAx = Input.GetAxisRaw("Horizontal");
            float VerticalAx = Input.GetAxisRaw("Vertical");

            //Horizontal Move
            if (HorizontalAx != 0)
            {
                Utils.ApplyVelocity(Blob, HorizontalAx * playerSpeed, velocity.y);
            }

            if (HorizontalAx != 0 && transform.right.x != HorizontalAx)
            {
                transform.Rotate(0, 180, 0);
            }

            //Jump every 0.2s
            float currentTime = Time.realtimeSinceStartup;
            if (Input.GetKeyDown("space") && currentTime - timeOfLastJump > 0.2f)
            {
                if (_grounded || _jumpCount == 1)
                {
                    Utils.ApplyVelocity(Blob, y: jumpforce);
                    _jumpCount++;
                }

                //Reset timer
                timeOfLastJump = currentTime;
            }

            //Cap Speed
            CapVerticalPlayerSpeed();
        }

        private void CapVerticalPlayerSpeed()
        {
            if (Blob.velocity.y > Constants.PL_MAX_UP_SPEED)
                Utils.ApplyVelocity(Blob, y: Constants.PL_MAX_UP_SPEED);
            else if (Blob.velocity.y < -Constants.PL_MAX_DOWN_SPEED)
                Utils.ApplyVelocity(Blob, x: Blob.velocity.x, y: -Constants.PL_MAX_DOWN_SPEED);

        }
        void OnCollisionEnter2D(Collision2D collision)
        {    
            if (collision.gameObject.tag == "Floor")
            {
                _grounded = true;
                _jumpCount = 0;
            }
        }
        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                _grounded = false;
            }
        }
    }
}
    

