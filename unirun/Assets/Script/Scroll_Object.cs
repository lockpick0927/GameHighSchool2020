using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Object : MonoBehaviour
{
    public float m_Speed = 5f;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * m_Speed * Time.deltaTime;
    }
}
