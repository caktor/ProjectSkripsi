using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabC1 : MonoBehaviour {
	private List<string> pilihanC = new List<string>(){
		"H<size=30>2</size>S","Ca(OH)<size=30>2</size>","HCCOH", "HCN","KBr",
		"MgCO<size=30>3</size>","NH<size=30>3</size>", "NaI",
		"K<size=30>2</size>CO<size=30>3</size>","CH<size=30>3</size>COOK",
		"H<size=30>3</size>PO<size=30>4</size>",
		"KBr","CaCl<size=30>2</size>","HF", "K<size=30>2</size>CO<size=30>3</size>",
		"CaCO<size=30>3</size>","AlPO<size=30>4</size>", "H<size=30>2</size>SO<size=30>4</size>", 
		"MgCl<size=30>2</size>", "NH<size=30>4</size>CN"
	};
	void Update()
	{
		if(TextControl1.randQuestionSlash>-1){
			GetComponent<TextMesh>().text = pilihanC[TextControl1.randQuestionSlash];
		}
	}
	void OnMouseDown()
	{
		Debug.Log(gameObject.name);
		GetComponent<TextMesh>().color = new Color(0,1,0);
		TextControl1.selectedAnswerSlash = gameObject.name;
		TextControl1.choiceSelectedSlash ="y";
	}
	void OnMouseUp()
	{
		GetComponent<TextMesh>().color = new Color(1,1,1);
	}
}
