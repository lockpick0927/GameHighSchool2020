using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameObject FireBall;

    public float m_Speed = 25f;
    public float m_AttackCooltime = 0f;
    public float m_AttackInterval = 0.5f;

    public Transform[] m_FireMuzzles;

    private void Update()
    {
        //Rigidbody2D rigidbody = /*gameObject.*/GetComponent<Rigidbody2D>();
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // transform.position.x = xAxis;
        transform.position += new Vector3(xAxis, yAxis, 0) * m_Speed * Time.deltaTime;
        //rigidbody.AddForce(new Vector2(xAxis, yAxis) * m_Speed * Time.deltaTime);

        m_AttackCooltime += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && m_AttackCooltime >= m_AttackInterval)
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
