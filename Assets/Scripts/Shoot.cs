using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Todo move bullets, delete bullets that have travelled a certain distance
    [SerializeField] private Transform _prefab;
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
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_prefab, Blob.position, Quaternion.identity);
            _bulletCount++;
        }

    }
}
