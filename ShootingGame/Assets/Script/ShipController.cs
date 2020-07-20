using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameObject FireBall;

    public float m_Speed = 2f;
    public float m_AttackCooltime = 0f;
    public float m_AttackInterval = 0.05f;

    private void Update()
    {
        Rigidbody2D rigidbody = /*gameObject.*/GetComponent<Rigidbody2D>();
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // transform.position.x = xAxis;
        transform.position += new Vector3(xAxis, yAxis, 0) * m_Speed * Time.deltaTime;
        //rigidbody.AddForce(new Vector2(xAxis, yAxis) * m_Speed * Time.deltaTime);

        m_AttackCooltime += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && m_AttackCooltime > m_AttackInterval)
        {
            SpawnBullet();
            //공격 선쿨타임 초기화
            m_AttackCooltime = 0;

        }
    }

    public void SpawnBullet()
    {
        GameObject bullet = GameObject.Instantiate(FireBall);
        GameObject bullet2 = GameObject.Instantiate(FireBall);
        bullet.transform.position = new Vector2(transform.position.x + 1.8f, transform.position.y - 0.1f);
        bullet2.transform.position = new Vector2(transform.position.x - 1.8f, transform.position.y - 0.1f);
        bullet.transform.rotation = transform.rotation;
        bullet2.transform.rotation = transform.rotation;

        var b = bullet.GetComponent<Bullet>();
        var b2 = bullet.GetComponent<Bullet>();
        b.m_Velocity = transform.forward;
        b2.m_Velocity = transform.forward;
    }
}
