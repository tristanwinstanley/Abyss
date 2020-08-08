using UnityEngine;
using Assets.Utility;

namespace Assets.Scripts
{
    public class Despawn : MonoBehaviour
    {
        float timezero;

        // Start is called before the first frame update
        void Start()
        {
            timezero = Time.timeSinceLevelLoad;
        }

        void Update()
        {
            //Destroy once BULLET_LIFETIME is reached
            if (Time.timeSinceLevelLoad - timezero > Constants.BULLET_LIFETIME)
                Destroy(gameObject);
            
        }
    }
}
