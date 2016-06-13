using UnityEngine;
using System.Collections;

public class AimMouseCamera : MonoBehaviour
{
    // The Mouse Aim Camera - This type of camera is similar to the Follow camera, 
    // except the rotation is controlled by the mouse, 
    // which then points the character in whatever direction the camera is facing.

    public GameObject target;
    [SerializeField]
    private float rotateSpeed = 5;
    [SerializeField]
    private Vector3 offSet;

    void Start()
    {
        offSet = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        //use Get Axis Mouse X, to rotate on X-Axis
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal,  0);

        //float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //target.transform.Rotate(vertical, 0, 0);

        // give an offset same direction and put camera behind target.
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offSet);

        transform.LookAt(target.transform);
    }

}
