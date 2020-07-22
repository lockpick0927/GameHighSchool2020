using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject FireBall;
    public Transform[] m_FireMuzzles;
    public Animator m_Animator;

    public bool m_IsDead = false;

    public float m_Speed = 2f;
    public float m_AttackCooltime = 0f;
    public float m_AttackInterval = 1.5f;

    private void Awake()
    {
        m_Animator.SetBool("IsDead", m_IsDead);
    }
    // Update is called once per frame
    void Update()
    {
        // transform.position.x = xAxis;
        if (m_IsDead) return;

        transform.position -= new Vector3(0, 3, 0) * m_Speed * Time.deltaTime;
        if (transform.position.y < -17f)
        {
            Destroy(gameObject);
        }

        m_AttackCooltime += Time.deltaTime;
        BulletSpawn();
    }

    void BulletSpawn()
    {
        if (m_AttackCooltime >= m_AttackInterval)
        {
            foreach (var FireMuzzle in m_FireMuzzles)
            {
                //SpawnBullet();
                var bullet = Instantiate(FireBall, FireMuzzle.position, FireMuzzle.rotation);
                //공격 선쿨타임 초기화
                m_AttackCooltime = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" || collision.tag == "Player")
        {
            m_IsDead = true;
             m_Animator.SetBool("IsDead", m_IsDead);
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }


}
