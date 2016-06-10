using UnityEngine;
using System;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 20.0f;
    [SerializeField]
    private float m_Jump = 20.0f;
    private Vector3 m_direction = Vector3.zero;
    private bool isJump;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
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
        if(Input.GetKey(KeyCode.W))
        {
            m_direction = new Vector3(0, 0, 1);
            transform.position += m_direction * m_Speed * Time.deltaTime;
            //rb.MovePosition(transform.position + m_direction * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_direction = new Vector3(-1, 0, 0);
            transform.position += m_direction * m_Speed * Time.deltaTime;
            //rb.MovePosition(transform.position + m_direction * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_direction = new Vector3(1, 0, 0);
            transform.position += m_direction * m_Speed * Time.deltaTime;
            //rb.MovePosition(transform.position + m_direction * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_direction = new Vector3(0, 0, -1);
            transform.position += m_direction * m_Speed * Time.deltaTime;
            //rb.MovePosition(transform.position + m_direction * m_Speed * Time.deltaTime);
        }

        rb.MovePosition(transform.position + m_direction * m_Speed * Time.deltaTime);
    }
}
