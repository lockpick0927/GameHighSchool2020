using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (GameManager.Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool m_IsGameOver = false;
    public GameObject m_GameOverUI;
    public Text m_ScoreUI;
    public float m_Score = 0;
    public void Start()
    {
        m_ScoreUI.text = string.Format("SCORE : {0}", (int)m_Score);
    }
    
    private void Update()
    {
        
    }
    public void Restart()
    {
        if (m_IsGameOver)
        {
            SceneManager.LoadScene("Level_UniRun");
        }
    }

    public void OnPlayerDead()
    {
        m_IsGameOver = true;
        m_GameOverUI.SetActive(true);

        Scroll_Object[] scroll_Objects = FindObjectsOfType<Scroll_Object>();
        foreach (var Scrollobj in scroll_Objects) Scrollobj.enabled = false;
        FindObjectOfType<Platform_Spawner>().enabled = false;

    }

    public void OnAddScore()
    {
        m_Score += 1;
        m_ScoreUI.text = string.Format("SCORE : {0}", (int)m_Score);
    }

}
