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
            //Move in horiz player direction, dont change y component
            float direction = GameObject.FindWithTag(Constants.PLAYER_TAG).transform.position.x - currentTransform.position.x > 0 ? 1 : -1;
            rb.velocity = new Vector2(direction * Constants.ENEMY_SPEED, rb.velocity.y);
        }
    }

}
