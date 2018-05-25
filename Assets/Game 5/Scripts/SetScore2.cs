using UnityEngine;
using System.Collections;

public class SetScore2 : MonoBehaviour 
{
	public TextMesh bestScoreLabel;
	public TextMesh scoreLabel;


	void Start () 
	{
		scoreLabel.text = "Score Game: " + GameManager2.score.ToString();
		if (GameManager2.score > 0)
		{
			if (PlayerPrefs.GetInt("ScoreSlingshot", 0) < GameManager2.score)
			{
				PlayerPrefs.SetInt("ScoreSlingshot", GameManager2.score);
				PlayerPrefs.Save();
			}
		}
		bestScoreLabel.text = "HighScore Game: " + PlayerPrefs.GetInt("ScoreSlingshot", 0).ToString();
		GameManager2.score = 0;

	}
}