using UnityEngine;

namespace Assets.Scripts.Player.Gun
{
    public class SelfRotation : MonoBehaviour
    {
        private Transform _transform;
        public Vector3 _mouseVector;
        private Vector3 _stickParentVector;
        public float MouseDelta;
        public float testValue;
        void Start()
        {
            _transform = GetComponent<Transform>();
            // Hide mouse cursor
            Cursor.visible = true;
        }
        private void Update()
        {
            
        }
        void FixedUpdate()
        {
            RotateTowardsMouse();
        }
        /// <summary>
        /// Move aiming line towards Mouse exact location
        /// </summary>
        private void RotateTowardsMouse()
        {
            //Vector between mouse and current position
            _mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _transform.position;

            //Angle between mouse and right vector (0, 0, 0-360 deg)
            Vector3 mouseAngle = ComputeTotalAngle(_mouseVector, Vector3.right);

            //Rotate by setting angle to match mouse angle
            _transform.eulerAngles = mouseAngle;
        }

        /// <summary>
        /// Move aiming line when mouse is moved up and down
        /// </summary>
        private void RotateWithoutMouse()
        {
            MouseDelta = Input.GetAxis("Mouse Y");
            Vector3 angleToRotate = new Vector3(0, 0, MouseDelta * testValue);
            _transform.Rotate(angleToRotate);
        }
        public static Vector3 ComputeTotalAngle(Vector3 a, Vector3 b)
        {
            a = new Vector2(a.x, a.y);
            b = new Vector2(b.x, b.y);

            float x = Vector2.Dot(a, b) / (a.magnitude * b.magnitude);

            float outputAngle = Mathf.Acos(x);

            //Return angle in degrees not rad
            outputAngle = Mathf.Rad2Deg * outputAngle;

            //To return total angle and not only angle up to 180
            if (a.y < 0)
                outputAngle = 360 - outputAngle;

            // output is (0, 0, 0-360 deg)
            return Vector3.forward * outputAngle;
        }

        public static Vector2 DegreeToVector2(float degree)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad);
        }

        public static Vector2 RadianToVector2(float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }

        private Vector3 GetVectorWithParent(Vector3 inputPosition)
        {
            //Return vector between input position and parent position
            return inputPosition - _transform.parent.position;
        }

    }
}

