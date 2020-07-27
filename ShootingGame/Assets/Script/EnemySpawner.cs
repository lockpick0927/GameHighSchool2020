using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject m_Enemy;

    public float m_MinX = -22.0f;
    public float m_MaxX = 22.0f;

    public float m_MinDelay = 1.1f;
    public float m_MaxDelay = 2.3f;

    public float m_SpawnDelay = 0;

    //public int m_EnemyCount = 0;
    private void Start()
    {
        m_SpawnDelay = Random.Range(m_MinDelay, m_MaxDelay);
    }
    // Update is called once per frame
    void Update()
    {
        m_SpawnDelay -= Time.deltaTime;

        if (m_SpawnDelay <= 0)
        {
            m_SpawnDelay = Random.Range(m_MinDelay, m_MaxDelay);
            float rand = Random.Range(m_MinX, m_MaxX);
            Vector2 SpawnPosition = new Vector2(rand, 33);
            if (rand > 36.5)
            {
                m_Enemy.transform.localEulerAngles = new Vector3(0, 0, -45);
            }
            else if (rand < -36.5)
            {
                m_Enemy.transform.localEulerAngles = new Vector3(0, 0, 45);
            }
            else
            {
                m_Enemy.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            Instantiate(m_Enemy, SpawnPosition, m_Enemy.transform.rotation);
        }
    }
}
