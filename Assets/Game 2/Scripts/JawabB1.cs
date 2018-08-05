using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabB1 : MonoBehaviour {

	private List<string> pilihanB = new List<string>(){
"b.	(NH<size=20>4</size>)<size=20>2</size>S"
,"b. NaNO<size=20>3</size>"
,"b. NH<size=20>4</size>NO<size=20>3</size>"
,"b. (CH<size=20>3</size>COO)<size=20>2</size>Ca"
,"b. HCOOK"
,"b. MgBr<size=20>2</size>"
,"b. Memiliki pH alkalin"
,"b. Jika dilarutkan dalam air akan membentuk asam \npembentuknya kembali"
,"b. Merupakan garam yang memiliki pH asam"
,"b. HCN dan NH<size=20>3</size>"
,"b. HCN dan NH<size=20>4</size>OH"
,"b. HCN dan NaOH"
,"b. Akan menghasilkan larutan garam dengan pH lebih dari 7"
,"b. Akan membentuk asam dan basa pembentuknya kembali"
,"b. Akan menghasilkan larutan garam dengan pH kurang dari 7"
	};
	void Update()
	{
		if(TextControl1.randQuestionSlash>-1){
			GetComponent<TextMesh>().text = pilihanB[TextControl1.randQuestionSlash];
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
