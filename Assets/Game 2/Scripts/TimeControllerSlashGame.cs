using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeControllerSlashGame : MonoBehaviour {
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public Text scoreLabelPanel;
    public Text warningScoreJelek;
    public Slider slider;
    public float timeMinValue = 0f;
    public float timeMaxValue = 30f;
    public float timeCurValue;
    private bool condition = false;
    int jmlStar =0;
     void Start()
    {
        condition = false;
        timeCurValue = timeMaxValue;
        slider.value = timeCurValue;
    }

     void Update()
    {
        slider.value = timeCurValue - Time.time;
        scoreLabelPanel.text = "Score : " + statsScore.score;
        if (timeCurValue <= Time.time)
        {
            GameOver();
        }
    }


   /* public void TimeDecrease(float penguranganWaktu)
    {
        timeCurValue -= penguranganWaktu;
    }*/

    public void GameOver()
    {
        Time.timeScale = 0;
        timeCurValue = 0;
        Debug.Log("Game Over And Try Again");

     /*   if (statsScore.score <= 10  && statsScore.score<=50)
        {
            SetActiveWinPanel(false);
            SetActiveLosePanel(false);
            StarController(0);
            if (statsScore.score >= 10 && statsScore.score <= 30)
            {
                StarController(1);
            }
            else if (statsScore.score >= 31 && statsScore.score <= 50)
            {
                StarController(1);
                StarController(2);
            }
            else if (statsScore.score >= 51 && statsScore.score <= 70)
            {
                StarController(1);
                StarController(2);
                StarController(3);
            }
            if (statsScore.score <= 10)
            {
                warningScoreJelek.text = "Score kamu kurang dari 10 dan tidak mendapatkan bintang";
            }
        }
        else if (timeCurValue <= Time.time && statsScore.score >= 71 && statsScore.score >= 80)
        {
            SetActiveLosePanel(false);
            SetActiveWinPanel(false);
            if (statsScore.score >= 10)
            {
                warningScoreJelek.text = "";
            }
        }
        */
    }


    public void SetActiveLosePanel(bool condition)
    {
        condition = true;
        LosePanel.SetActive(condition);
    }
    public void StarController(int _jmlStar)
    {
        jmlStar = _jmlStar;
        int score = statsScore.score;
        if (jmlStar == 1)
        {
            condition = true;
            Star1.SetActive(condition);
        }
        else if(jmlStar == 2)
        {
            condition = true;
            Star1.SetActive(condition);
            Star2.SetActive(condition);
        }
        else if (jmlStar == 3)
        {
            condition = true;
            Star1.SetActive(condition);
            Star2.SetActive(condition);
            Star3.SetActive(condition);
        }else if(jmlStar == 0)
        {
            condition = false;
            Star1.SetActive(condition);
            Star2.SetActive(condition);
            Star3.SetActive(condition);
        }
    }
    public void SetActiveWinPanel(bool condition)
    {
        condition = true;
        WinPanel.SetActive(condition);
    }
}
