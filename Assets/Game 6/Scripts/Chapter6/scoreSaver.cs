using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreSaver : MonoBehaviour {

	public Text scoreNilaiLabel;

	public Text BestscoreNilai;

	void Start () 
	{
		scoreNilaiLabel.text = "Score Nilai: " +GameNilai.scoreNilai.ToString();
		if (GameNilai.scoreNilai > 0)
		{
			if (PlayerPrefs.GetInt("ScoreNilai1", 0) < GameNilai.scoreNilai)
			{
				PlayerPrefs.SetInt("ScoreNilai1", GameNilai.scoreNilai);
				PlayerPrefs.Save();
			}
		}
		 
		BestscoreNilai.text =  PlayerPrefs.GetInt("ScoreNilai1", 0).ToString();
		GameNilai.scoreNilai =0;

	}	
}
