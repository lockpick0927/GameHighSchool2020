using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D m_Rigidbody2D;

    public float m_XAxisSpeed = 5f;
    public float m_YJumpPower = 500f;

    public bool Climp = false;
    public float tmpg;

    public int m_JumpCount = 0;

    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = xAxis * m_XAxisSpeed;
        m_Rigidbody2D.velocity = velocity;

        if (xAxis > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (xAxis < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        
        var animator = GetComponent<Animator>();

        if (Input.GetKeyDown(KeyCode.UpArrow) && m_JumpCount <= 0 && Climp == false)
        {
            m_Rigidbody2D.AddForce(Vector3.up
                * m_YJumpPower);

            m_JumpCount++;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && Climp)
        {
            m_Rigidbody2D.AddForce(Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Climp)
        {
            m_Rigidbody2D.AddForce(Vector3.down);
        }

        if(!Climp)
        {
            animator.SetFloat("VelocityY", velocity.y);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("엔터충돌");
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            if (contact.normal.y > 0.5f)
            {
                m_JumpCount = 0;
            }
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            if (Climp)
            {
                Climp = false;
                m_Rigidbody2D.gravityScale = 3.5f;
                var animators = GetComponent<Animator>();
                animators.SetBool("Climp", false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder" && Input.GetKeyDown(KeyCode.Space))
        {
            if (!Climp)
            {
                Climp = true;
                m_Rigidbody2D.gravityScale = 0f;
                var animators = GetComponent<Animator>();
                animators.SetBool("Climp", true);
            }
        }
    }


}