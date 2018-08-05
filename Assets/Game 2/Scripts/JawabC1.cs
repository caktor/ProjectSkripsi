using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabC1 : MonoBehaviour {
	private List<string> pilihanC = new List<string>(){
"c.	NH<size=20>4</size>Br"
,"c. NH<size=20>4</size>CH<size=20>3</size>COO"
,"c. CH<size=20>3</size>COOK"
,"c. CH<size=20>3</size>COONH<size=20>4</size>"
,"c. KNO<size=20>3</size>"
,"c. NaSO<size=20>4</size>"
,"c. Memiliki pH netral"
,"c. Jika dilarutkan dalam air akan membentuk asam-basa \npembentuknya kembali"
,"c. Merupakan garam yang memiliki pH basa"
,"c. CH<size=20>3</size>COOH dan KOH"
,"c. HCl dan KOH"
,"c. H<size=20>2</size>SO<size=20>4</size> dan NH<size=20>3</size>"
,"c. Akan menghasilkan larutan garam dengan pH kurang dari 7"
,"c. Akan membentuk basa pembentuknya kembali"
,"c. Akan menghasilkan larutan garam dengan pH lebih dari 7"
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
