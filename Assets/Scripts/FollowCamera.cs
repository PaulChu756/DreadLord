using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    // The Follow Camera - This type of camera is commonly used in platforming games like Mario Galaxy. 
    // The camera sits behind and above the player and rotates around the character as they turn.

    public GameObject target;
    [SerializeField]
    private Vector3 offSet;

    void Start()
    {
        offSet = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        // orient the camera behind the target, and get the angle of the target and turn it into a rotation
        float angle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);

        // multiply the offset by the rotation to orient the offset the same as the target.
        // Subtract the result from the position of the target.
        transform.position = target.transform.position - (rotation * offSet);
        transform.LookAt(target.transform);

    }
}
