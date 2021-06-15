using Assets.Scripts.Enemies.EnemySpawner;
using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UIElements
{
    public class Parallax : MonoBehaviour
    {
        private GameObject gameCamera;
        private float initialPosition;
        public float parallaxAmount;
        private void Start()
        {
            gameCamera = GameObject.FindGameObjectWithTag(Constants.CAMERA_TAG);
            initialPosition = gameCamera.transform.position.x;
        }

        private void Update()
        {
            // Rules of Parallax:
            // When you move left, and camera follows you, everything else move right
            // whatever is closest to you moves the quickest

            float distance = gameCamera.transform.position.x - initialPosition;
            initialPosition = gameCamera.transform.position.x;



            // If parallaxAmount is 1, the object will follow the camera exactly, if less it will move slower
            // The further the object, the smaller the parallax to give the illusion it's moving very slowly


            transform.position = new Vector3(transform.position.x + distance * parallaxAmount, transform.position.y, transform.position.z);
        }
    }
}
