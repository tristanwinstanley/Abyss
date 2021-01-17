using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class FollowPlayer : MonoBehaviour
    {
        private void Update()
        {
            GameObject player = GameObject.FindWithTag("Player");
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, transform.position.z);
        }
    }
}
