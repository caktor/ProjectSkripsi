﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabA1 : MonoBehaviour {

	
	private List<string> pilihanA = new List<string>(){
"a.	Reaksi antara air dengan ion-ion yang berasal \ndari asam lemah atau basa lemah suatu garam"
,"a. Karena KCl jika direaksikan dengan air akan \nmembentuk KOH dan HCl"
,"a. Karena NH<size=20>4</size>CN akan terdisosiasi menjadi ion-ion \ndan bereaksi dengan air membentuk NH<size=20>4</size>OH dan HCN kembali"
,"a. Karena CH<size=20>3</size>COONa akan terdisosiasi menjadi ion2\n dan bereaksi dengan air membentuk CH<size=20>3</size>COOH dan NaOH kembali"
,"a. NH<size=15>4</size>Cl"
,"a. KI"
,"a. CaSO<size=20>4</size>"
,"a. (NH<size=20>4</size>)<size=20>3</size>PO<size=20>4</size>"
,"a. Na<size=20>3</size>PO<size=20>4</size>"
,"a. K<size=20>2</size>SO<size=20>4</size>"
,"a. Termasuk garam tidak terhidrolisis"
,"a. Termasuk garam tidak terhidrolisis"
,"a. Termasuk garam tidak terhidrolisis"
,"a. HI dan Ca(OH)<size=20>2</size>"
,"a. HI dan Ca(OH)<size=20>2</size>"
,"a. HI dan Ca(OH)<size=20>2</size>"
,"a. Akan menghasilkan garam yang tidak terhidrolisis"
,"a. Akan menghasilkan garam yang tidak terhidrolisis"
,"a. Akan menghasilkan garam yang tidak terhidrolisis"
	};

    public List<string> PilihanA
    {
        get
        {
            return pilihanA;
        }

        set
        {
            pilihanA = value;
        }
    }
	void Start()
	{
	}
    void Update()
	{
		
		if(TextControl1.randQuestionSlash>-1){
			GetComponent<TextMesh>().text = PilihanA[TextControl1.randQuestionSlash];
		}
	}
	void OnMouseDown()
	{
		TextControl1.selectedAnswerSlash = gameObject.name;
		TextControl1.choiceSelectedSlash ="y";
		Debug.Log(gameObject.name);
		GetComponent<TextMesh>().color = new Color(0,1,0);
		
	}
	void OnMouseUp()
	{
		GetComponent<TextMesh>().color = new Color(1,1,1);
	}

	
}