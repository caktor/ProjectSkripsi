using UnityEngine;
using System.Collections;

public class SetScore : MonoBehaviour 
{
	public TextMesh bestScoreLabel;
	public TextMesh scoreLabel;
	public TextMesh bestScoreQuiz;
	public TextMesh scoreQuiz;

	void Start () 
	{
		scoreLabel.text = "Score Game: " + GameManager1.score.ToString();
		scoreQuiz.text = "Score Quiz: "+TextControl.scoreQuiz.ToString();
		if (GameManager1.score > 0)
		{
			if (PlayerPrefs.GetInt("Score", 0) < GameManager1.score)
			{
				PlayerPrefs.SetInt("Score", GameManager1.score);
				PlayerPrefs.Save();
			}
		}
		 if(TextControl.scoreQuiz>0){
			if(PlayerPrefs.GetFloat("ScoreQuiz",0)<TextControl.scoreQuiz){
				PlayerPrefs.SetFloat("ScoreQuiz",TextControl.scoreQuiz);
				PlayerPrefs.Save();
			}
		}

		bestScoreLabel.text = "HighScore Game: " + PlayerPrefs.GetInt("Score", 0).ToString();
		GameManager1.score = 0;
		bestScoreQuiz.text = "HighScore Quiz: " + PlayerPrefs.GetFloat("ScoreQuiz", 0).ToString();
		TextControl.scoreQuiz = 0;
	}
}