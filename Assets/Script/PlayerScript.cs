using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    public bool estoyAtacando;
    public float n_speed;
    public bool IsRunning;

    public BoxCollider[] armasBoxCol;

    void Start()
    {
        estoyAtacando = false;
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !estoyAtacando)
        {
            m_Animator.SetTrigger("Attack1");
            estoyAtacando = true;
        }

    }
    void FixedUpdate()
    {
        if (!estoyAtacando)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            m_Movement.Set(horizontal, 0f, vertical);
            m_Movement.Normalize();

            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
            IsRunning = hasHorizontalInput || hasVerticalInput;
            m_Animator.SetBool("IsRunning", IsRunning);

            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desiredForward);
            m_Rigidbody.MovePosition(transform.position + m_Movement * n_speed * Time.deltaTime);
            m_Rigidbody.MoveRotation(m_Rotation);
        }
    }

    public void DejoDeAtacar()
    {
        estoyAtacando = false;
    }
}