using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaCoon_Move : MonoBehaviour
{
    public float m_Speed = 5f;
    // Update is called once per frame
    void Update()
    {
        //주석 : 설명 필요없는 스크립트를 임시적으로 비활성화하기 위해서 사용
        /* 주석 */
        Rigidbody2D rigidbody = /*gameObject.*/GetComponent<Rigidbody2D>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        rigidbody.AddForce(new Vector2(xAxis, yAxis) * m_Speed);


        //정답
        //float fireAxis = Input.GetAxis("Fire1");

        //if (fireAxis > 0.95f)
        //    Die();
    }

    //이게 첫줄
    //public GameManager m_GameManager;

    public void Die()
    {
        Debug.Log("사망");
        //gameObject.SetActive(false)
    }
}
