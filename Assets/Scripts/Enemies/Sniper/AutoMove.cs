using Assets.Scripts.Utility;
using UnityEngine;
namespace Assets.Scripts.Enemies.Sniper
{
    public class AutoMove : MonoBehaviour
    {
        // Start is called before the first frame update
        Transform currentTransform;
        Rigidbody2D rb;
        void Start()
        {
            currentTransform = GetComponent<Transform>();
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //Move in player direction
            Vector2 VectorToPlayer = Utils.Get2DNormVector(GameObject.FindWithTag(Constants.PLAYER_TAG).transform.position - currentTransform.position);
            rb.velocity = VectorToPlayer * Constants.ENEMY_SPEED;
        }
    }

}
