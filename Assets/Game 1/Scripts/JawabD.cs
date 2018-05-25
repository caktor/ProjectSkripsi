using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabD : MonoBehaviour {

	private List<string> pilihanD = new List<string>(){
		"KOH","CaS","HBr", "HI", "HCI", "HNO<size=30>3</size>","CaI<size=30>2</size>",
		"C<size=30>2</size>H<size=30>4</size>",
		"OH<size=30>-</size>","HI","NaCl","HBr","KCl","CH<size=30>3</size>COOK",
		"NH<size=30>4</size>CN","NH<size=30>3</size>COOH", "Na<size=30>3</size>PO<size=30>4</size>",
		"MgSO<size=30>4</size>",
		"Mg(NO<size=30>3</size>)<size=30>2</size>","Ca(CN)<size=30>2</size>"
	};
	void Update()
	{
		if(TextControl.randQuestion>-1){
			GetComponent<TextMesh>().text = pilihanD[TextControl.randQuestion];
		}
	}
	void OnMouseDown()
	{
		Debug.Log(gameObject.name);
		GetComponent<TextMesh>().color = new Color(0,1,0);
		TextControl.selectedAnswer = gameObject.name;
		TextControl.choiceSelected ="y";
	}
	void OnMouseUp()
	{
		GetComponent<TextMesh>().color = new Color(1,1,1);
	}
}
