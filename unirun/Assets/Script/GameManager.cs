using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public void OnPlayerDead()
    {
        m_IsGameOver = true;
        m_GameOverUI.SetActive(true);
    }

    public void OnAddScore()
    {
        m_Score += Time.deltaTime;
        m_ScoreUI.text = string.Format("SCORE : {0}", (int)m_Score);
    }

}
