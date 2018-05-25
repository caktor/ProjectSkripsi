using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabB1 : MonoBehaviour {

	private List<string> pilihanB = new List<string>(){
"b.	Reaksi yang terjadi antara suatu senyawa \ndan air dengan membentuk reaksi kesetimbangan"
,"b. Karena KCl jika direaksikan dengan air akan \nmembentuk KOH, ion H<size=20>+</size>, dan ion Cl<size=20>-</size>"
,"b. Karena NH<size=20>4</size>CN tidak akan terhidrolisis"
,"b. Karena CH<size=20>3</size>COONa jika direaksikan dengan air \nakan membentuk CH<size=20>3</size>COOH dan ion Na<size=20>+</size>, dan ion OH<size=20>+</size>"
,"b. (NH<size=20>4</size>)<size=20>2</size>S"
,"b. NaNO<size=20>3</size>"
,"b. NH<size=20>4</size>NO<size=20>3</size>"
,"b. (CH<size=20>3</size>COO)<size=20>2</size>Ca"
,"b. (NH<size=20>4</size>)<size=20>2</size>SO<size=20>4</size>"
,"b. CaBr<size=20>2</size>"
,"b. Termasuk garam yang mengalami hidrolisis sebagian"
,"b. Termasuk garam yang mengalami hidrolisis sebagian"
,"b. Termasuk garam yang mengalami hidrolisis sebagian"
,"b. HCN dan NH<size=20>4</size>OH"
,"b. HCN dan NH<size=20>4</size>OH"
,"b. HCN dan NaOH"
,"b. Akan menghasilkan garam yang terhidrolisis sempurna"
,"b. Akan menghasilkan garam yang terhidrolisis sempurna"
,"b. Akan menghasilkan garam yang terhidrolisis sempurna"
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
