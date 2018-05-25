using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextButton1 : MonoBehaviour {

	public TextMesh result;
	public static string resetaura1 ="n";
	void OnMouseDown()
	{ 
		resetaura1 ="y";
		result.GetComponent<TextMesh>().text ="";
		GetComponent<TextMesh>().color = new Color(0,1,0);
	//	TextControl1.randQuestionSlash=-1;
		
	}

	void OnMouseUp()
	{
		GetComponent<TextMesh>().color = new Color(1,1,1);
	}
}
