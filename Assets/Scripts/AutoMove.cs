using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private Rigidbody2D bullet;
    private Transform bulletTransform;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        bulletTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletTransform.position += new Vector3(0.2f, 0.2f);
        //ApplyVelocity(bullet, 10, 10);
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
