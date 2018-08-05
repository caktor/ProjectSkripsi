using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningTime : MonoBehaviour {

	public TextMesh runningTime;
	public float startingTime;
	private float currentTime;
	// Use this for initialization
	void Start () 
	{
		currentTime = startingTime;
		runningTime.GetComponent<TextMesh>().text = Mathf.Round(currentTime)+" detik";
	}
	
	// Update is called once per frame
	void Update () {
		
		currentTime -= Time.deltaTime;
		if(currentTime<=0){
			currentTime =0;
			Application.LoadLevel("Chap2 MainMenu");
		}
		runningTime.GetComponent<TextMesh>().text = Mathf.Round(currentTime)+" detik";
	}
}
