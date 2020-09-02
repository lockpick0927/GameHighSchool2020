using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D m_Rigidbody2D;

    public float m_XAxisSpeed = 5f;
    public float m_ClimpSpeed = 3f;
    public float m_YJumpPower = 500f;

    public bool Climp = false;
    public bool Dead = false;
    public bool FallDown = false;

    public int m_JumpCount = 0;

    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if (!Dead)
        {
            float xAxis = Input.GetAxis("Horizontal");
            float yAxis = Input.GetAxis("Vertical");

            Vector2 velocity = m_Rigidbody2D.velocity;
            velocity.x = xAxis * m_XAxisSpeed;
            if (Climp)
            {
                velocity.y = yAxis * m_ClimpSpeed;
            }
            m_Rigidbody2D.velocity = velocity;

            if (velocity.y < -0.1)
            {
                FallDown = true;
            }
            else
            {
                FallDown = false;
            }
            if (!Climp)
            {
                var animator = GetComponent<Animator>();
                animator.SetFloat("VelocityX", Mathf.Abs(xAxis));
                animator.SetFloat("VelocityY", velocity.y);
                if (velocity.y < -20) Dead = true;
            }

            if (xAxis > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (xAxis < 0)
                transform.localScale = new Vector3(-1, 1, 1);


            if (Input.GetKeyDown(KeyCode.UpArrow) && m_JumpCount <= 0 && Climp == false)
            {
                m_Rigidbody2D.AddForce(Vector3.up
                    * m_YJumpPower);

                m_JumpCount++;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
                m_Rigidbody2D.gravityScale = 0.0f;
                // m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
                var animators = GetComponent<Animator>();
                animators.SetBool("Climp", true);
            }

        }
    }


}