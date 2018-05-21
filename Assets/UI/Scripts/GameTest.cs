using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTest : MonoBehaviour
{
    private int m_level;
    private int m_sublevel;
    public GameObject LevelTitle;
    public GameObject ScoreText;
    public GameObject StarText;

    // Use this for initialization
    void Start()
    {
        m_level = Store.GetCurrentLevel();
        m_sublevel = Store.GetCurrentSubLevel();
        //LevelTitle.GetComponent<Text>().text = "Level : "+m_level + " - " + m_sublevel;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnWinClick()
    {
        int Score = int.Parse(ScoreText.GetComponent<Text>().text);
        int Star = int.Parse(StarText.GetComponent<Text>().text);
        Store.SubmitScore(m_level, m_sublevel, Score, Star);
        SceneManager.LoadScene("MainMenu");
    }
    public void OnLoseClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnVideoClick()
    {
        Debug.Log(m_level+"."+m_sublevel); 
        Store.SubmitScore(m_level, m_sublevel, 100, 2);
        SceneManager.LoadScene("MainMenu");
    }
}
