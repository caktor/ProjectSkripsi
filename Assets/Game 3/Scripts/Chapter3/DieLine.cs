using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieLine : MonoBehaviour {
	public GameObject gameOverScreen;

	public PlayerController player;

	// Use this for initialization
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject hitObj = collider.gameObject;

		if (hitObj.tag == "Player") 
		{
			gameOverScreen.SetActive (true);
//			player.gameObject.SetActive (false);
		}
	}
}
