using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl1 : MonoBehaviour {

	private List<string> question = new List<string>(){
"Pernyataan yang salah mengenai\n hidrolisis garam adalah ..."
,"Mengapa KCl merupakah garam \ntidak terhidrolisis ?"
,"Mengapa NH4CN merupakan garam \nyang mengalami hidrolisis secara sempurna?"
,"Mengapa CH3COONa merupakan garam\n yang mengalami hidrolisis sebagian?"
,"Dibawah ini manakah garam yang mengalami\n hidrolisis secara sempurna?"
,"Dibawah ini manakah garam yang mengalami\n hidrolisis sebagian?"
,"Dibawah in manakah garam yang tidak\n terhidrolisis?"
,"Berikut ini garam yang mengalami \nhidrolisis sempurna, kecuali ..."
,"Berikut ini garam yang mengalami \nhidrolisis sebagian, kecuali ..."
,"Berikut ini garam yang tidak terhidrolisis,\nkecuali ..."
,"Berikut ini pernyataan yang benar \nmengenai Na3PO4 adalah ..."
,"Berikut ini pernyataan yang benar \nmengenai (NH4)2S adalah ..."
,"Berikut ini pernyataan yang benar \nmengenai KNO3 adalah ..."
,"Manakah pasangan asam – basa yang akan \nmenghasilkan garam tidak terhidrolisis?"
,"Manakah pasangan asam – basa yang akan \nmenghasilkan garam terhidrolisis "
,"Manakah pasangan asam – basa yang akan \nmenghasilkan garam terhidrolisis sebagian?"
,"Pernyataan yang benar mengenai pasangan \nasam – basa  HI dan KOH adalah ..."
,"Pernyataan yang benar mengenai pasangan \nasam – basa H2CO3 dan NH4OH adalah ..."
,"Pernyataan yang benar mengenai pasangan \nasam – basa Ca(OH)2 dan CH3COOH adalah ..."
	};
	private List<string> correctAnswer = new List<string>(){
		"4","3","1","2","2","4","1","2","3","4","2","3","1","1","3","2","1","2","3"
	};
	private List<int> previousQuestion = new List<int>(){
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,-1,-1
	};
	public static int questionNumberSlash =0;
	public int klik;
	public Transform resultObj;
	public Transform auraobj;
	public static string selectedAnswerSlash ;
	public static string choiceSelectedSlash = "n";
	public static int randQuestionSlash=-1;
	public float totalBenar=0;
	public float totalPertanyaan=20;
	public TextMesh scoreQuizSlashLabel;
	public static float scoreQuizSlash;
	public float ScoreQuizSlash
	{
		set
		{
			scoreQuizSlash = value;

			scoreQuizSlashLabel.text = "Score"+ Mathf.Round(ScoreQuizSlash);
		}
		get
		{
			return scoreQuizSlash;
		}
	}
	void Start()
	{
		
		scoreQuizSlash=0;
		GetComponent<TextMesh>().text = question[0];
	}
	void Update()
	{
		
		float akumulasi =(totalBenar/totalPertanyaan)*100;
		scoreQuizSlashLabel.GetComponent<TextMesh>().text = "Score :"+ akumulasi;
		scoreQuizSlash=akumulasi;
		if(randQuestionSlash ==-1){
			randQuestionSlash = UnityEngine.Random.Range(0,18);
			for(int i=0;i<19;i++){
				if(randQuestionSlash!=previousQuestion[i]){
					
				}else{
					randQuestionSlash=-1;
				}
			}
		}

		if(randQuestionSlash>-1){
			GetComponent<TextMesh>().text = question[randQuestionSlash];
			previousQuestion [questionNumberSlash]= randQuestionSlash;
		}
		if(questionNumberSlash==18){
			questionNumberSlash=0;
			resultObj.GetComponent<TextMesh>().text = "Hebat !,Kamu telah\n menyelesaikan 20 pertanyaan";
			Application.LoadLevel("Chap2 MainMenu");
		}

		if(choiceSelectedSlash =="y" ){
			choiceSelectedSlash = "n";
			klik+=1;
			questionNumberSlash+=1;
			if(correctAnswer[randQuestionSlash]==selectedAnswerSlash){
				resultObj.GetComponent<TextMesh>().text = "Benar";
				totalBenar+=1;
				randQuestionSlash=-1;
			}else{
				randQuestionSlash=-1;
				nextButton1.resetaura1 ="n";
				resultObj.GetComponent<TextMesh>().text = "Salah";
				// if(correctAnswer[randQuestionSlash]=="1"){
				// 	auraobj.GetComponent<Transform>().position = new Vector3(-5.66f,-1f,10f);
				// }
				// if(correctAnswer[randQuestionSlash]=="2"){
				// 	auraobj.GetComponent<Transform>().position = new Vector3(-5.66f,-2.14f,10f);
				// }
				// if(correctAnswer[randQuestionSlash]=="3"){
				// 	auraobj.GetComponent<Transform>().position = new Vector3(1f,-1f,10f);
				// }
				// if(correctAnswer[randQuestionSlash]=="4"){
				// 	auraobj.GetComponent<Transform>().position = new Vector3(1f,-2.14f,10f);
				// }
			}
		}
		
	}
}


