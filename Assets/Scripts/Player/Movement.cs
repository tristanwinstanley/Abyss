using Assets.Scripts.Utility;
using UnityEngine;
namespace Assets.Scripts.Player
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D Blob;
        private int JUMPFORCE = 160;
        private int MAXVERTICALSPEED = 25;
        private bool _grounded;
        private Collider2D _collider;

        private Vector2 velocity;
        void Start()
        {
            Blob = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }
        void FixedUpdate()
        {
            velocity = Blob.velocity;

            //CheckGrounded();
            //Get User input
            float HorizontalAx = Input.GetAxisRaw("Horizontal");
            float VerticalAx = Input.GetAxisRaw("Vertical");

            //Horizontal Move
            Utils.ApplyVelocity(Blob, HorizontalAx * Constants.PLAYER_SPEED, velocity.y);
            
            //Rotate
            if (Input.GetKeyDown("space"))
            {
                if (_grounded)
                    Utils.ApplyVelocity(Blob, y: JUMPFORCE);
            }

            //Cap Speed
            CapVerticalPlayerSpeed();
        }

        private void CapVerticalPlayerSpeed()
        {
            if (Blob.velocity.y > MAXVERTICALSPEED)
                Utils.ApplyVelocity(Blob, y: MAXVERTICALSPEED);
            else if (Blob.velocity.y < -MAXVERTICALSPEED)
                Utils.ApplyVelocity(Blob, y: -MAXVERTICALSPEED);

        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                _grounded = true;
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
    

