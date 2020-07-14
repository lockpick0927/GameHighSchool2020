using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator m_Animator;

    public bool m_IsGround = false;
    public bool m_Dead = false;
    public float m_Speed = 50f;

    // Update is called once per frame
    void Update()
    {
        m_Animator.SetBool("IsGround", m_IsGround);

        Rigidbody2D rigidbody = /*gameObject.*/GetComponent<Rigidbody2D>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        float J_Axis = Input.GetAxis("Jump");

        rigidbody.AddForce(new Vector2(xAxis, yAxis) * m_Speed);
        if(m_IsGround == true) rigidbody.AddForce(new Vector2(0, J_Axis) * 300f);
        //m_Animator.SetBool("IsDead", m_Dead);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            m_IsGround = true;
        }        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            m_IsGround = false;
        }
    }


}
