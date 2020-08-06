using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Todo move bullets, delete bullets that have travelled a certain distance
    [SerializeField] private GameObject _prefab;
    private Rigidbody2D Blob;
    private int _bulletCount;
    void Start()
    {
        Blob = GetComponent<Rigidbody2D>();
        _bulletCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject bullet = null;
        if (Input.GetMouseButtonDown(0))
        {
            bullet = Instantiate(_prefab, Blob.position, Quaternion.identity);
            
            Rigidbody2D bulletRB = _prefab.GetComponent<Rigidbody2D>();
            //currently applying velocity does not change anything..
            //ApplyVelocity(bulletRB, 100, 100);
            _bulletCount++;
        }

        if (bullet != null)
        {
            bullet.transform.position += new Vector3(10, 10);
        }

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
