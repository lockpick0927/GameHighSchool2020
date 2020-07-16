using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class Player_Controller : MonoBehaviour
{
    public Animator m_Animator;
    public AudioSource m_AudioSource;
    public Rigidbody2D m_rigidbody;
    public AudioClip m_jump;
    public AudioClip m_die;

    public bool m_IsGround = false;
    public bool m_Dead = false;
    public float m_Speed = 50f;
    public int JumpCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (m_Dead) return;
        m_Animator.SetBool("IsGround", m_IsGround);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (JumpCount < 2)
            {
                Debug.Log("입력");
                m_rigidbody.velocity = Vector2.zero;
                m_rigidbody.AddForce(Vector2.up * 400);
                JumpCount++;

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
            JumpCount = 0;
        }
        if (collision.collider.tag == "DeathZone")
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
