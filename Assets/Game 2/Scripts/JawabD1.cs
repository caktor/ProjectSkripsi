using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabD1 : MonoBehaviour {

	private List<string> pilihanD = new List<string>(){
"d.	(NH<size=20>4</size>)<size=20>2</size>SO<size=20>4</size>"
,"d. KCN"
,"d. Ca(CN)<size=20>2</size>"
,"d. (NH<size=20>4</size>)<size=20>2</size>S"
,"d. KCN"
,"d. NH<size=20>4</size>CH<size=20>3</size>COO"
,"d. Memiliki pH sedikit asam"
,"d. Jika dilarutkan dalam air tidak akan membentuk \nasam-basa pembentuknya "
,"d. Merupakan garam yang memiliki pH alkalin"
,"d. HBr dan NH<size=20>3</size>"
,"d. H<size=20>2</size>CO<size=20>3</size> dan NaOH"
,"d. HNO<size=20>3</size> dan NaOH"
,"d. Akan menghasilkan larutan garam dengan pH sama dengan 14"
,"d. Tidak  membentuk asam dan basa penyusunya kembali"
,"d. Akan menghasilkan larutan garam dengan pH sama dengan 3"
	};
	void Update()
	{
		if(TextControl1.randQuestionSlash>-1){
			GetComponent<TextMesh>().text = pilihanD[TextControl1.randQuestionSlash];
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
