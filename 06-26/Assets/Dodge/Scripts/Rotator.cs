using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float m_Speed = 30f;
    void Update()
    {
        transform.Rotate(new Vector3(0, m_Speed * Time.deltaTime, 0));
    }
}
