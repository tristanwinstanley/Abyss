using Assets.Scripts.Utility;
using UnityEngine;
namespace Assets.Scripts.Enemies.ShieldedKami
{
    public class Movement : MonoBehaviour
    {
        // Start is called before the first frame update
        Rigidbody2D rb;
        Animator animator;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            animator.SetBool("FacingPlayer", false);

            rb.velocity = new Vector2(-Constants.ENEMY_SPEED, 0);
        }
    }

}
