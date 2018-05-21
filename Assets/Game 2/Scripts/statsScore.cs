using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsScore : MonoBehaviour {

    private Text myText;
    public static int score=0;

    float timer;
    void Start()
    {
        myText = GetComponent<Text>();
    }
    private void Update()
    {
        myText.text = "Score : " + score;
    }
    public void AddScore(int scorePlus)
    {
        Debug.Log("Score Gain");
        score += scorePlus;
        myText.text = "Score  : " + score.ToString();
    }
    
}
