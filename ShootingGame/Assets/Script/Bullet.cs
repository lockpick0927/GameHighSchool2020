using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_Speed = 3f;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.up * m_Speed * Time.deltaTime;

        transform.position += movement;

        if(transform.position.y > 17f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
