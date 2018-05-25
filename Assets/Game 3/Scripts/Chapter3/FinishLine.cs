using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {
	public GameObject FinishScreen;

	//public PlayerController player;

	public AudioSource audio;

	// Use this for initialization
	void Update()
	{
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject hitObj = collider.gameObject;

		if (hitObj.tag == "Player") 
		{
			FinishScreen.SetActive (true);
			//player.gameObject.SetActive (false);
			audio.gameObject.SetActive (false);
		}
	}
}
