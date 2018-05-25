using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auraControl1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(nextButton1.resetaura1 =="y"){
			GetComponent<ParticleSystem>().gameObject.SetActive(true);
		}
		if(nextButton1.resetaura1 == "n"){
			GetComponent<ParticleSystem>().gameObject.SetActive(false);
		}
	}
}
