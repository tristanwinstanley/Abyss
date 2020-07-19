using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D Blob;
    private int THRUST = 10;
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
        ApplyVelocity(Blob, HorizontalAx * THRUST, VerticalAx * THRUST);
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
            ApplyVelocity(Blob, y: MAXVERTICALSPEED);
        else if (Blob.velocity.y < -MAXVERTICALSPEED)
            ApplyVelocity(Blob, y: -MAXVERTICALSPEED);

    }
    private void ApplyVelocity(Rigidbody2D rb, float x = 0f, float y = 0f)
    {
        // if x or y is 0, use previous velocity, i.e don't change
        //if (x == 0f)
        //    x = rb.velocity.x;
        //if (y == 0f)
        //    y = rb.velocity.y;
        
        rb.velocity = new Vector2(x, y);
    }
}

