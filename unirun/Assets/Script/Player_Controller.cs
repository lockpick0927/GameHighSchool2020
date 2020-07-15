using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator m_Animator;
    public AudioSource m_AudioSource;

    public AudioClip m_jump;
    public AudioClip m_die;

    public bool m_IsGround = false;
    public bool m_Dead = false;
    public float m_Speed = 50f;

    // Update is called once per frame
    void Update()
    {
        if (m_Dead) return;
        m_Animator.SetBool("IsGround", m_IsGround);

        Rigidbody2D rigidbody = /*gameObject.*/GetComponent<Rigidbody2D>();
        GameManager.Instance.OnAddScore();
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        rigidbody.AddForce(new Vector2(xAxis, yAxis) * m_Speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float J_Axis = Input.GetAxis("Jump");
            if (m_IsGround == true)
            {
                rigidbody.AddForce(new Vector2(0, J_Axis) * 300f);
                m_AudioSource.clip = m_jump;
                m_AudioSource.Play();
            }
        }
        //m_Animator.SetBool("IsDead", m_Dead);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            m_IsGround = true;
        }
        if(collision.collider.tag == "DeathZone")
        {
            m_Dead = true;
            m_Animator.SetBool("IsDead", m_Dead);
            m_AudioSource.clip = m_die;
            m_AudioSource.Play();
            GameManager.Instance.OnPlayerDead();
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
