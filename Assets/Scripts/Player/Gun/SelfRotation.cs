﻿using UnityEngine;

namespace Assets.Scripts.Player.Gun
{
    public class SelfRotation : MonoBehaviour
    {
        private Transform _transform;


        public Vector3 _mouseVector;
        private Vector3 _stickParentVector;
        private float _mouseAngle;
        void Start()
        {
            _transform = GetComponent<Transform>();
        }
        void FixedUpdate()
        {
            //Vector between mouse and current position
            _mouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _transform.position;

            //Angle between mouse and right vector 0-360 deg
            _mouseAngle = ComputeTotalAngle(_mouseVector, Vector3.right);

            //Rotate by setting angle to match mouse angle
            _transform.eulerAngles = Vector3.forward * _mouseAngle;

        }
        private float ComputeTotalAngle(Vector3 a, Vector3 b)
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

            return outputAngle;
        }
        private Vector3 GetVectorWithParent(Vector3 inputPosition)
        {
            //Return vector between input position and parent position
            return inputPosition - _transform.parent.position;
        }

    }
}
