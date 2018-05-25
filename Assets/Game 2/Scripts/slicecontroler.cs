using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slicecontroler : MonoBehaviour {
	void Update () {
		GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
		Destroy(gameObject,3f);
	}
}
