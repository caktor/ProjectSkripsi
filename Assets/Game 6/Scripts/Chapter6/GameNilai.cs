using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameNilai : MonoBehaviour {

	private Text text;
		public static int poinAmount;

	public static int scoreNilai;
	public int ScoreNilai
	{
		set
		{
			scoreNilai = value;

			text.text =  ScoreNilai.ToString ();
		}
		get
		{
			return scoreNilai;
		}

	}

	// Use this for initialization
	void Start () {
		
		text = GetComponent<Text> ();

		text.text = scoreNilai.ToString ();
	}

	// Update is called once per frame
	void Update () {
		text.text = scoreNilai.ToString ();
	}
}
