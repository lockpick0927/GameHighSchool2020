using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject FireBall;
    public Transform[] m_FireMuzzles;
    public Animator m_Animator;

    public bool m_IsRun = false;
    public bool m_Dead = false;

    public float m_Speed = 2f;
    public float m_AttackCooltime = 0f;
    public float m_AttackInterval = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // transform.position.x = xAxis;
        transform.position -= new Vector3(0, 3, 0) * m_Speed * Time.deltaTime;
        if (transform.position.y > 17f)
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
}
