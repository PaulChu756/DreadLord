using UnityEngine;
using System;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    // Serializefield shows variable inside inspector.

    // Completed
    [SerializeField] 
    private float m_MovementSpeed = 10.0f;
    [SerializeField]
    private float m_Jump = 10.0f;
    [SerializeField]
    private float m_Friction = 2.5f;
    [SerializeField]
    private Vector3 m_Velocity = Vector3.zero;

    // Testing
    [SerializeField]
    private float m_TurnSpeed = 10.0f;
    [SerializeField]
    private Vector3 m_Direction = Vector3.zero;
    [SerializeField]
    private Vector3 m_AngleVel = Vector3.zero;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use FixedUpdate because physic cal's on rigidbodies.
    void FixedUpdate() 
    {
        Movement();
        Jump();
    }

    // May take out
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * m_Jump, ForceMode.VelocityChange);
        }
    }

    void Movement()
    {
        // Friction force
        m_Velocity -= m_Velocity * m_Friction * rb.mass * Time.deltaTime;

        // Rotate
        Quaternion Rotate = Quaternion.identity;

        m_AngleVel = Quaternion.LookRotation(rb.velocity).eulerAngles;

        if (Input.GetKey(KeyCode.W))
        {
            m_Velocity += transform.forward = new Vector3(0, 0, 1) * m_MovementSpeed * Time.deltaTime;

            //m_Direction = m_Velocity.normalized;
            //Rotate = Quaternion.LookRotation(m_Direction);
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_Velocity += transform.forward = new Vector3(0, 0, -1) * m_MovementSpeed * Time.deltaTime;

            //m_Direction -= m_Velocity.normalized;
            //Rotate = Quaternion.LookRotation(m_Direction);
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_Velocity += transform.forward = new Vector3(-1, 0, 0) * m_MovementSpeed * Time.deltaTime;

            //m_Direction = m_Velocity.normalized;
            //Rotate = Quaternion.LookRotation(m_Direction);
            //transform.rotation = Rotate;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_Velocity += transform.forward = new Vector3(1,0,0) * m_MovementSpeed * Time.deltaTime;
            //m_Direction = m_Velocity.normalized;
            //Rotate = Quaternion.LookRotation(m_Direction);
            //transform.rotation = Rotate;
        }
        rb.MovePosition(rb.position + m_Velocity * Time.deltaTime);
        
        //rb.MoveRotation(rb.rotation * Rotate);
    }
}
