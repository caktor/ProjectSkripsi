using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabB : MonoBehaviour {

	private List<string> pilihanB = new List<string>(){
		"HF","KOH","NaCl","NH<size=30>4</size>OH", "H<size=30>2</size>O", 
		"H<size=30>2</size>","Zn(OH)<size=30>2</size>",
		"H<size=30>2</size>C<size=30>2</size>O<size=30>4</size>",
		"H<size=30>3</size>O<size=30>+</size>",
		"LiOH", "CaS", "KCl", "NaNO<size=30>3</size>" ,"AlCl<size=30>3</size>" ,"HCOOH",
		 "CH<size=30>3</size>COONH<size=30>4</size>",
		 "H<size=30>3</size>PO<size=30>4</size>", "Na<size=30>2</size>SO<size=30>4</size>",
		 "MgCO<size=30>3</size>","KCN"
	};
	void Update()
	{
		if(TextControl.randQuestion>-1){
			GetComponent<TextMesh>().text = pilihanB[TextControl.randQuestion];
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
