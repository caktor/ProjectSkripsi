using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nilai : MonoBehaviour {

	private Text text;
	public static int poinAmount;

	private static int score;
	public int Score
	{
		set
		{
			score = value;

			text.text = "Score : " + Score.ToString ();
		}
		get
		{
			return score;
		}

	}

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = score.ToString ();
	}

	// Update is called once per frame
	void Update () {
		text.text = score.ToString ();
	}
}
