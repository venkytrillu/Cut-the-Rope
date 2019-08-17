using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject PanelGameOver,PanelGamePlay;

    public GameObject[] GoldStars;

    public GameObject[] WhiteStars;
    public int assignScore;
    public Text ScoretxtFiels;
    [HideInInspector]
    public int scoreCount, satrCount;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        DisplayScore();
    }
    public void EnableStarts(int count)
    {
        count--;
        for(int i=0;i<=count;i++)
        {
            GoldStars[i].SetActive(true);
            WhiteStars[i].SetActive(true);
            scoreCount += assignScore;
        }
        DisplayScore();
    }

    void DisplayScore()
    {
        ScoretxtFiels.text = scoreCount.ToString();
    }

    public void GameOver()
    {
        StartCoroutine(LevelCompleted(1.5f));
    }


    IEnumerator LevelCompleted(float delay)
    {
        yield return new WaitForSeconds(delay);
        PanelGamePlay.SetActive(false);
        PanelGameOver.SetActive(true);
    }
}// class
















































