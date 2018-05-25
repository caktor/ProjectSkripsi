using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabA : MonoBehaviour {

	private List<string> pilihanA = new List<string>(){
		"KF","HF","NaOH","CuSO<size=30>4</size>","H<size=30>3</size>PO<size=30>4</size>",
		"O<size=30>2</size>","CH<size=30>3</size>COOH", "AgOH","Al(OH)<size=30>3</size>",
		"Mg(OH)<size=30>2</size>","KF","KI","Ca(OH)<size=30>2</size>","BaF<size=30>2</size>",
		"CaBr<size=30>2</size>","AgNO<size=30>3</size>", "Ca3(PO4)2","K2SO4","Mg(OH)<size=30>2</size>","HCN"
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

    void Update()
	{
		if(TextControl.randQuestion>-1){
			GetComponent<TextMesh>().text = PilihanA[TextControl.randQuestion];
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
