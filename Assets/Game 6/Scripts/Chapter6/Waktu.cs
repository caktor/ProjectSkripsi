using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waktu : MonoBehaviour {

	public float startingTime;
	private float countingTime;
		public static int totalclicks = 0;	

	public GameObject gameover;

	private Text theText;


	//public PlayerController player;


	// Use this for initialization
	void Start () 
	{
		countingTime = startingTime;

		theText = GetComponent<Text> ();

		//player = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		countingTime -= Time.deltaTime;

		if (countingTime <= 0) 
		{
			gameover.SetActive (true);
			//player.gameObject.SetActive (false);

		}
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			totalclicks += 1;
		}
	
		if (totalclicks >= 20) 
		{
			gameover.SetActive(true);
			totalclicks = 0;
		}
		theText.text = "" + Mathf.Round (countingTime);
	}
		
}
