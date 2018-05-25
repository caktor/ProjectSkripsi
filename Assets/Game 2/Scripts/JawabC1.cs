using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabC1 : MonoBehaviour {
	private List<string> pilihanC = new List<string>(){
"c.  Reaksi yang menyebabkan garam terdisosiasi \nmenjadi ion-ionnya"
,"c. Karena KCl jika direaksikan dengan air tidak \nakan bereaksi membentuk KOH maupun HCl kembali, melainkan terdisosiasi membenuk ion K<size=20>+</size> dan Cl<size=20>-</size>."
,"c. Karena NH<size=20>4</size>CN berasal dari asam lemah – basa kuat"
,"c. Karena CH<size=20>3</size>COONa berasal dari asam lemah – basa kuat"
,"c. NH<size=20>4</size>Br"
,"c. NH<size=20>4</size>CH<size=20>3</size>COO"
,"c. CH<size=20>3</size>COOK"
,"c. CH<size=20>3</size>COONH<size=20>4</size>"
,"c. NH<size=20>4</size>F"
,"c. CaSO<size=20>4</size>"
,"c. Termasuk garam yang mengalami hidrolisis sempurna"
,"c. Termasuk garam yang mengalami hidrolisis sempurna"
,"c. Termasuk garam yang mengalami hidrolisis sempurna"
,"c. CH<size=20>3</size>COOH dan Mg(OH)<size=20>2</size>"
,"c. H<size=20>2</size>SO<size=20>4</size> dan Mg(OH)<size=20>2</size>"
,"c. H<size=20>2</size>SO<size=20>4</size> dan Mg(OH)<size=20>2</size>"
,"c. Akan menghasilkan garam yang terhidrolisis sebagian"
,"c. Akan menghasilkan garam yang terhidrolisis sebagian"
,"c. Akan menghasilkan garam yang terhidrolisis sebagian"
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
