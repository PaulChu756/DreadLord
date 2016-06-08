using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    public float m_movement = 10.0f;

    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * m_movement * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * m_movement * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * m_movement * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * m_movement * Time.deltaTime);
        }
    }

    void Update()
    {
        Move();
    }
}
