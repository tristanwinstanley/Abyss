using Assets.Utility;
using UnityEngine;
namespace Assets.Scripts.Player
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D Blob;
        private int JUMPFORCE = 145;
        private int MAXVERTICALSPEED = 25;
        private bool _grounded;

        private Vector2 velocity;
        void Start()
        {
            Blob = GetComponent<Rigidbody2D>();
        }
        void FixedUpdate()
        {
            velocity = Blob.velocity;

            //CheckGrounded();
            //Get User input
            float HorizontalAx = Input.GetAxisRaw("Horizontal");
            float VerticalAx = Input.GetAxisRaw("Vertical");

            //Horizontal Move
            Utils.ApplyVelocity(Blob, HorizontalAx * Constants.PLAYER_SPEED, VerticalAx * Constants.PLAYER_SPEED);
            //Vertical Move
            //ApplyVelocity(Blob, VerticalAx * THRUST);

            //Rotate
            if (Input.GetKeyDown("space"))
            {

                //if (_grounded)
                //    ApplyVelocity(Blob, y: JUMPFORCE);
            }

            //Cap Speed
            //CapVerticalPlayerSpeed();
        }

        private void CheckGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 1f, 0), -Vector2.up, 0.2f);
            if (hit.collider != null)
                _grounded = true;
            else
                _grounded = false;
        }
        private void CapVerticalPlayerSpeed()
        {
            if (Blob.velocity.y > MAXVERTICALSPEED)
                Utils.ApplyVelocity(Blob, y: MAXVERTICALSPEED);
            else if (Blob.velocity.y < -MAXVERTICALSPEED)
                Utils.ApplyVelocity(Blob, y: -MAXVERTICALSPEED);

        }
    }
}
    

