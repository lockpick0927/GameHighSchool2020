using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 m_Velocity;
    public float m_Speed = 2f;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.up * m_Speed * Time.deltaTime;

        transform.position += movement;
    }
}
