using UnityEngine;
using Assets.Scripts.Utility;
using Assets.Scripts.Player.Gun;

namespace Assets.Scripts.Projectiles.Arrow
{
    public class Movement : MonoBehaviour
    {
        Rigidbody2D _rb;
        Transform _transform;
        BoxCollider2D _cd;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
            _cd = GetComponent<BoxCollider2D>();
        }
        private void FixedUpdate()
        {
            if (_rb != null)
            {
                RotateTowardsVelocity();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            //_rb.velocity = Vector3.zero;
            ArrowStick();
        }
        void ArrowStick()
        {
            _rb.velocity = Vector3.zero;
            // Make the arrow a child of the thing it's stuck to
            //transform.parent = col.transform;
            //Destroy the arrow's rigidbody2D and collider2D
            Destroy(_rb);
            Destroy(_cd);
        }

        private void RotateTowardsVelocity()
        {
            Vector3 velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, 0);
            Vector3 angle = SelfRotation.ComputeTotalAngle(velocity, Vector3.right);
            _transform.eulerAngles = angle;
        }
    }
}
