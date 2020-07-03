using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform m_PlayerTransfrom;

    public GameObject m_Bullet;

    public float Tick = 0f;
    public float m_RotationSpeed = 60f;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {

            Tick += Time.deltaTime;
            if (Tick > 1)
            {
                GameObject bullet = GameObject.Instantiate(m_Bullet);
                bullet.transform.position = transform.position;//총알의 위치를 스포너 위치로 옮긴다
                bullet.transform.rotation = transform.rotation;//

                Tick = 0;
            }

            
            Vector3 attackPoint = player.transform.position;
            attackPoint.y = transform.position.y;
            transform.LookAt(attackPoint);
        }
    }

}
//GameObject.Find("게임오브젝트의 이름");
//GameObject player = GameObject.FindGameObjectWithTag("Player");
// GameObject.FindObjectOfType<PlayerController>();

//GameObject.FindGameObjectsWithTag("모든 태그");
//GameObject.FindSceneObjectsOfType<PlayerController>(); 모든 PlayerController 검색