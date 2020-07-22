using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject m_Enemy;

    public float m_MinX = -17.0f;
    public float m_MaxX = 17.0f;

    public float m_MinDelay = 1.1f;
    public float m_MaxDelay = 2.3f;

    public float m_SpawnDelay = 0;
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

            Vector2 SpawnPosition = new Vector2(Random.Range(m_MinX, m_MaxX),15);
            Instantiate(m_Enemy, SpawnPosition , m_Enemy.transform.rotation);
        }
    }
}
