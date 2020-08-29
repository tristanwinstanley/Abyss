using UnityEngine;

namespace Assets.Utility
{
    public class Utils
    {
        public static void ApplyVelocity(Rigidbody2D rb, float x = 0f, float y = 0f)
        {
            rb.velocity = new Vector2(x, y);
        }

        public static Vector2 Get2DNormVector(Vector3 vector)
        {
            Vector2 outputVector;
            Vector2 returnVector2d = new Vector2(vector.x, vector.y);
            outputVector = new Vector2(returnVector2d.normalized.x, returnVector2d.normalized.y);
            return outputVector;
        }
    }
}
