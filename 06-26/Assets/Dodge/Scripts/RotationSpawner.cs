using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSpawner : MonoBehaviour
{
    public GameObject m_Bullet;

    public float m_RotationSpeed = 120f;
    public float Tick = 0f;


    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {

            Tick += Time.deltaTime;
            if (Tick > 1)
            {
                GameObject bullet = GameObject.Instantiate(m_Bullet);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;

                Tick = 0;
            }

            transform.Rotate(0, m_RotationSpeed * Time.deltaTime, 0);
        }
    }
}
