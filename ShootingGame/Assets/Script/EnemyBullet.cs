﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float m_Speed = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.up * m_Speed * Time.deltaTime;

        transform.position -= movement;

        if (transform.position.y < -17f)
        {
            Destroy(gameObject);
        }
    }
}