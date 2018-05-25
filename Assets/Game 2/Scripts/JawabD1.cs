using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabD1 : MonoBehaviour {

	private List<string> pilihanD = new List<string>(){
"d. Reaksi antara air dengan ion-ion yang berasal dari\n senyawa kompleks"
,"d. Karena KCl jika direaksikan dengan air tidak akan \nbereaksi dan membentuk ion OH<size=20>-</size> dan H<size=20>+</size>"
,"d. Karena NH<size=20>4</size>CN berasal dari asam kuat – basa lemah"
,"d. Karena CH<size=20>3</size>COONa berasal dari asam kuat – basa lemah"
,"d. (NH<size=20>4</size>)<size=20>2</size>SO<size=20>2</size>"
,"d. KCN"
,"d. Ca(CN)<size=20>2</size>"
,"d. (NH<size=20>4</size>)<size=20>2</size>S"
,"d. Mg(CN)<size=20>2</size>"
,"d. Ca(CN)<size=20>2</size>"
,"d. Bukan termasuk garam"
,"d. Bukan termasuk garam"
,"d. Bukan termasuk garam"
,"d. H<size=20>2</size>S dan Al(OH)<size=20>3</size>"
,"d. H<size=20>2</size>S dan Al(OH)<size=20>3</size>"
,"d. H<size=20>2</size>S dan Al(OH)<size=20>3</size>"
,"d. Akan menghasilkan garam kompleks"
,"d. Akan menghasilkan garam kompleks"
,"d. Akan menghasilkan garam kompleks"
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
