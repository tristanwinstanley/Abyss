using Assets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
