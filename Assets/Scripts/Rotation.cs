using UnityEngine;


public class Rotation : MonoBehaviour
{
    private Transform _transform;
    private Renderer _renderer;

    private Vector3 mousePosition;
    private Vector3 stickParentVector;
    private float angleToMouse;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _renderer = GetComponent<Renderer>();
    }
    void FixedUpdate()
    {
        
        //todo test angle to mouse result step by step
        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ////Get mouse position vector
        ////mouseParentVector = GetVectorWithParent(mousePosition);
        //stickParentVector = GetVectorWithParent(_transform.position);
        //angleToMouse = ComputeAngle(mousePosition, stickParentVector);

        ////Rotate
        //if (Input.GetKey("space"))
        //{

        //    //Rotate around players position
        //    _transform.RotateAround(_transform.parent.position, Vector3.forward, angleToMouse);
        //}
    }
    
    private Vector3 GetVectorWithParent(Vector3 inputPosition)
    {
        //return vector between input position and parent position
        return inputPosition - _transform.parent.position;
    }
    private float ComputeAngle(Vector3 a, Vector3 b)
    {
        a = new Vector2(a.x, a.y);
        b = new Vector2(b.x, b.y);
        
        float x = Vector2.Dot(a, b) / (a.magnitude * b.magnitude);

        float angle = Mathf.Acos(x);
        //return angle in degrees not rad
        return Mathf.Rad2Deg * angle;
    }
}

