using Assets.Utility;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    Transform CurrentTransform;
    [SerializeField] private GameObject projectilePrefab;
    void Start()
    {
        CurrentTransform = GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Normalized vector between Current transform and player
            Vector2 projectileVelocityVector = Utils.Get2DNormVector(GameObject.FindWithTag(Constants.PLAYER_TAG).transform.position - CurrentTransform.position);
            //Shoot projectile from current position with specific direction and speed
            Shoot(transform.position, projectileVelocityVector * Constants.BULLET_SPEED);
        }

    }
    private void Shoot(Vector2 position, Vector2 velocity)
    {
        //Create an instance of prefab in world
        GameObject prefabInstance = Instantiate(projectilePrefab, position, Quaternion.identity);
        //Apply velocity to prefab to make it move
        Rigidbody2D prefabRB = prefabInstance.GetComponent<Rigidbody2D>();
        Utils.ApplyVelocity(prefabRB, velocity.x, velocity.y);
    }
}
