using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawner : MonoBehaviour
{
    public GameObject m_PlatformPrefab;
    public GameObject[] m_PlatformPrefabs;

    public float m_MinY = -3.5f;
    public float m_MaxY = -1.5f;

    public float m_MinDelay = 2f;
    public float m_MaxDelay = 4f;

    public float m_SpawnDelay = 0;
    public int m_platformCount = 0;

    // Update is called once per frame
    private void Start()
    {
        m_PlatformPrefabs = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            m_PlatformPrefabs[i] = GameObject.Instantiate(m_PlatformPrefab);
            m_PlatformPrefabs[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(m_SpawnDelay <= 0)
        {
            m_PlatformPrefabs[m_platformCount].SetActive(false);
            m_PlatformPrefabs[m_platformCount].SetActive(true);

            Vector2 SpawnPosition = new Vector2(12, Random.Range(m_MinY, m_MaxY));
            m_PlatformPrefabs[m_platformCount].transform.position = SpawnPosition;

            m_platformCount = (m_platformCount + 1) % 3;



            m_SpawnDelay = Random.Range(m_MinDelay, m_MaxDelay);
        }
        m_SpawnDelay -= Time.deltaTime;
    }
}
