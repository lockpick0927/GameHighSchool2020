using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject FireBall;
    public Transform[] m_FireMuzzles;
    public Animator m_Animator;

    public bool m_IsDead = false;

    public float m_Speed = 10f;
    public float m_AttackCooltime = 0f;
    public float m_AttackInterval = 0.85f;

    private void Awake()
    {
        m_Animator.SetBool("IsDead", m_IsDead);
    }
    // Update is called once per frame
    void Update()
    {
        // transform.position.x = xAxis;
        if (m_IsDead) return;
        Vector3 Move = transform.up * m_Speed * Time.deltaTime;
        transform.position -= Move;
        if (transform.position.y < -33f)
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
            GameManager.instance.AddScore();
            m_Animator.SetBool("IsDead", m_IsDead);
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }


}
