using Assets.Utility;
using UnityEngine;

namespace Assets.Scripts
{
    public class AutoMove : MonoBehaviour
    {
        private Rigidbody2D bulletRB;
        private Transform bulletTransform;
        // Start is called before the first frame update
        void Start()
        {
            bulletRB = GetComponent<Rigidbody2D>();
            bulletTransform = GetComponent<Transform>();
            Utils.ApplyVelocity(bulletRB, x: Constants.BULLET_SPEED);
        }

        // Update is called once per frame
        void Update()
        {
            //bulletTransform.position += new Vector3(0.2f, 0.2f);
        }

    }
}
    
