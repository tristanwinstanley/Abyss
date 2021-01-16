using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class CameraMovement : MonoBehaviour
    {
        private void FixedUpdate()
        {
            GameObject player = GameObject.FindWithTag("Player");
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, transform.position.z);
        }
    }
}
