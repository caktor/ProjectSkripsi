using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabA1 : MonoBehaviour {

	
	private List<string> pilihanA = new List<string>(){
"a.	NH<size=20>4</size>Cl"
,"a. Kl"
,"a. Na<size=20>2</size>SO<size=20>4</size>"
,"a. (NH<size=20>4</size>)<size=20>3</size>PO<size=20>4</size>"
,"a. Na<size=20>3</size>PO<size=20>4</size>"
,"a. K<size=20>2</size>SO<size=20>4</size>"
,"a. Memiliki pH asam"
,"a. Jika dilarutkan dalam air akan membentuk basa \npembentuknya kembali"
,"a. Merupakan garam yang memiliki pH netral"
,"a. HBr dan Mg(OH)<size=20>2</size>"
,"a. HCl dan KOH"
,"a. HI dan KOH"
,"a. Akan menghasilkan larutan garam dengan pH sama dengan 7"
,"a. Akan membentuk asam pembentuknya kembali"
,"a. Akan menghasilkan larutan garam dengan pH sama dengan 7"

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
