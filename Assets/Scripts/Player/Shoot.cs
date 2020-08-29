using UnityEngine;
namespace Assets.Scripts.Player
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
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
                Instantiate(bulletPrefab, Blob.position, Quaternion.identity);
                _bulletCount++;
            }

        }
    }
}
    
