using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text m_ScoreUI;
    public Text m_RestartUI;

    public PlayerController m_PlayerController;
    public List<GameObject> m_BulletSpawners;

    public bool m_IsPlaying;
    public float Scores;

    private void Start()
    {
        //    GameStart();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (m_IsPlaying)
            {
                Scores += Time.deltaTime;
                m_ScoreUI.text = string.Format("Score : {0}", (int)Scores);
            }
            //else
            //{
            //    if(Input.GetKeyDown(KeyCode.R))
            //    {
            //        GameStart();
            //    }
            //}
        }
        else
        {
           //m_IsPlaying = false;
           //
           //if(Input.GetKeyDown(KeyCode.R))
           //{
           //    m_IsPlaying = true;
           //    GameObject PP = GameObject.Instantiate(player);
           //}
            //m_RestartUI.enabled = true;
        }
    }
}

//public void GameStart()
//{
//
//}