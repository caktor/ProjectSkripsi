using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextButton : MonoBehaviour {

	public TextMesh result;
	public static string resetaura ="n";
	void OnMouseDown()
	{ 
		resetaura ="y";
		result.GetComponent<TextMesh>().text ="";
		GetComponent<TextMesh>().color = new Color(0,1,0);
		TextControl.randQuestion=-1;
		TextControl.questionNumber+=1;
	}

	void OnMouseUp()
	{
		GetComponent<TextMesh>().color = new Color(1,1,1);
	}
}
