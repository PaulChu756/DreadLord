using UnityEngine;
using System;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 10.0f;
    [SerializeField]
    private float m_Jump = 10.0f;
    private Vector3 m_direction = Vector3.zero;

    void Movement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            m_direction = new Vector3(0, 0, 1);
            transform.position += m_direction * m_Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_direction = new Vector3(-1, 0, 0);
            transform.position += m_direction * m_Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_direction = new Vector3(1, 0, 0);
            transform.position += m_direction * m_Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_direction = new Vector3(0, 0, -1);
            transform.position += m_direction * m_Speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_direction = new Vector3(0, 1, 0);
            transform.position += m_direction * m_Jump * Time.deltaTime;
        }
    }

    void Update()
    {
        Movement();
    }
}
