using UnityEngine;
using Assets.Utility;

namespace Assets.Scripts
{
    public class Despawn : MonoBehaviour
    {
        private Rigidbody2D bulletRB;
        private Transform bulletTransform;
        // Start is called before the first frame update
        void Start()
        {
            bulletRB = GetComponent<Rigidbody2D>();
            bulletTransform = GetComponent<Transform>();
            Utils.ApplyVelocity(bulletRB, x: Constants.DEFAULT_SPEED);
        }
    }
}
