using UnityEngine;

namespace Assets.Utility
{
    public class Utils
    {
        public static void ApplyVelocity(Rigidbody2D rb, float x = 0f, float y = 0f)
        {
            rb.velocity = new Vector2(x, y);
        }
    }
}
