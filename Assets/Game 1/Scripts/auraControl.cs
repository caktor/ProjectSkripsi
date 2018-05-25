using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(nextButton.resetaura =="y"){
			GetComponent<ParticleSystem>().Stop();
		}
		if(nextButton.resetaura == "n"){
			GetComponent<ParticleSystem>().Play();
		}
	}
}
