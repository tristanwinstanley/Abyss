using Assets.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using C = Assets.Utility.Constants;
public class AutoMove : MonoBehaviour
{
    private Rigidbody2D bulletRB;
    private Transform bulletTransform;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletTransform = GetComponent<Transform>();
        Utility.ApplyVelocity(bulletRB, x: C.DEFAULT_SPEED);
    }

    // Update is called once per frame
    void Update()
    {
        //bulletTransform.position += new Vector3(0.2f, 0.2f);
    }
    
}
