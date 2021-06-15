using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class CameraMovement : MonoBehaviour
    {
        private GameObject player;
        private void Start()
        {
            player = GameObject.FindWithTag("Player");
        }
        private void FixedUpdate()
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
