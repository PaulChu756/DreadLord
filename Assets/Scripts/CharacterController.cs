using UnityEngine;
using System;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    // Serializefield shows variable inside inspector.
    [SerializeField] 
    private float m_Speed = 20.0f;
    [SerializeField]
    private float m_Turn = 20.0f;
    [SerializeField]
    private float m_Jump = 100.0f;
    [SerializeField]
    private Vector3 m_Velocity = Vector3.zero;
    [SerializeField]
    private Vector3 m_direction = Vector3.zero;
    [SerializeField]
    private Vector3 m_Rotate = Vector3.zero;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() // Use FixedUpdate because physic cal's on rigidbodies.
    {
        Movement();
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * m_Jump, ForceMode.VelocityChange);
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_direction = new Vector3(0, 0, 1);
            m_Velocity += m_direction * m_Speed * Time.deltaTime;
            transform.Rotate(0,  m_Turn * Time.deltaTime, 0);
            //m_Rotate += m_direction * m_Turn * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_direction = new Vector3(-1, 0, 0);
            m_Velocity += m_direction * m_Speed * Time.deltaTime;
            transform.Rotate(0, m_Turn * Time.deltaTime, 0);
            //m_Rotate += m_direction * m_Turn * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_direction = new Vector3(1, 0, 0);
            m_Velocity += m_direction * m_Speed * Time.deltaTime;
            transform.Rotate(0, m_Turn * Time.deltaTime, 0);
            //m_Rotate += m_direction * m_Turn * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_direction = new Vector3(0, 0, -1);
            m_Velocity += m_direction * m_Speed * Time.deltaTime;
            transform.Rotate(0, m_Turn * Time.deltaTime, 0);
            //m_Rotate += m_direction * m_Turn * Time.deltaTime;
        }
        //Quaternion rotate = Quaternion.Euler(m_Rotate * Time.deltaTime);
        rb.MovePosition(transform.position + m_Velocity * Time.deltaTime);
        //rb.MoveRotation(rb.rotation * rotate);
    }
}
