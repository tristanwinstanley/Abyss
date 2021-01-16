using Assets.Scripts.Utility;
using UnityEngine;
namespace Assets.Scripts.Enemies.ShieldedKami
{
    public class AutoMove : MonoBehaviour
    {
        // Start is called before the first frame update
        Rigidbody2D rb;
        float previousDirection;
        SpriteRenderer spriteRenderer;
        Animator animator;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            previousDirection = 1;
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //Move in horiz player direction, dont change y component
            //1:right  -1:left
            GameObject player = GameObject.FindWithTag(Constants.PLAYER_TAG);

            float direction;
            if (player.transform.position.x - transform.position.x > 0)
            {
                //face right
                direction = 1;
            }
            else
            {
                //face left
                direction = -1;
            }

            int speedBoost = 1;
            if (direction == player.transform.right.x) //Attack
            {
                //Enemy and player are both looking in same direction
                //Hence player is not looking at enemy
                speedBoost = 2;
                animator.SetBool("FacingPlayer", false);
            }
            else //Defense
            {
                animator.SetBool("FacingPlayer", true);
            }

            //Flip left and right
            if (transform.right.x != direction)
            {
                transform.Rotate(0, 180, 0);
            }

            rb.velocity = new Vector2(direction * Constants.ENEMY_SPEED * speedBoost, rb.velocity.y);
        }
    }

}
