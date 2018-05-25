using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsScore : MonoBehaviour {

    public TextMesh bestScoreSlashLabel;
	public TextMesh scoreSlashLabel;
	public TextMesh bestScoreQuizSlash;
	public TextMesh scoreQuizSLash;

	void Start () 
	{
		scoreSlashLabel.text = "Score Game : " + ObjectSpawner.scoreSenyawa.ToString();
		scoreQuizSLash.text = "Score Quiz: "+TextControl1.scoreQuizSlash.ToString();
		if (ObjectSpawner.scoreSenyawa > 0)
		{
			if (PlayerPrefs.GetInt("ScoreSlash", 0) < ObjectSpawner.scoreSenyawa)
			{
				PlayerPrefs.SetInt("ScoreSlash", ObjectSpawner.scoreSenyawa);
				PlayerPrefs.Save();
			}
		}
		 if(TextControl1.scoreQuizSlash>0){
			if(PlayerPrefs.GetFloat("ScoreQuizSlash",0)<TextControl1.scoreQuizSlash){
				PlayerPrefs.SetFloat("ScoreQuizSlash",TextControl1.scoreQuizSlash);
				PlayerPrefs.Save();
			}
		}

		bestScoreSlashLabel.text = "HighScore Game: " + PlayerPrefs.GetInt("ScoreSlash", 0).ToString();
		ObjectSpawner.scoreSenyawa = 0;
		bestScoreQuizSlash.text = "HighScore Quiz: " + PlayerPrefs.GetFloat("ScoreQuizSlash", 0).ToString();
		TextControl1.scoreQuizSlash = 0;
	}
    
}
