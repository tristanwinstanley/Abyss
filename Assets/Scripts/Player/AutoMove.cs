using Assets.Utility;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class AutoMove : MonoBehaviour
    {
        private Rigidbody2D bulletRB;
        private Transform bulletTransform;
        public Vector3 _mouseVector;

        // Start is called before the first frame update
        void Start()
        {
            bulletRB = GetComponent<Rigidbody2D>();
            bulletTransform = GetComponent<Transform>();
            
            //Apply normalized velocity vector to bullet in direction of mouse
            //Vector between mouse and current position
            _mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletTransform.position;
            Vector2 mouseVector2d = new Vector2(_mouseVector.x, _mouseVector.y);
            Utils.ApplyVelocity(bulletRB, mouseVector2d.normalized.x * Constants.BULLET_SPEED, mouseVector2d.normalized.y * Constants.BULLET_SPEED);
        }
    }
}
    
