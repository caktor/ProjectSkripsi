using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl1 : MonoBehaviour {

	private List<string> question = new List<string>(){
"Dibawah ini manakah garam yang pH nya ditentukan \n oleh Ka maupun Kb?"
,"Dibawah ini manakah garam yang pH nya lebih\n dari 7?"
,"Dibawah in manakah garam yang memiliki pH sama \ndengan 7?"
,"Berikut ini garam yang pH nya ditentukan oleh Ka \ndan Kb, kecuali ..."
,"Berikut ini garam yang akan menghasilkan asam \npembentuknya kembali jika dilarutkan dalam air, kecuali ..."
,"Berikut ini garam yang memiliki pH netral, kecuali ..."
,"Berikut ini pernyataan yang benar mengenai Na3PO4 \nadalah ..."
,"Berikut ini pernyataan yang benar mengenai (NH4)2S \nadalah ..."
,"Berikut ini pernyataan yang benar mengenai KNO3 \nadalah ..."
,"Manakah pasangan asam – basa yang akan menghasilkan \ngaram  dengan pH sama dengan 7?"
,"Manakah pasangan asam – basa yang akan menghasilkan \n garam dengan pH lebih dari 7?"
,"Pernyataan yang benar mengenai pasangan asam – basa  \nHI dan KOH adalah ..."
,"Pernyataan yang benar mengenai pasangan asam – basa \nH2CO3 dan NH3 jika dilarutkan dalam air adalah ..."
,"Pernyataan yang benar mengenai pasangan asam – basa \nKOH dan HCN adalah ..."
	};
	private List<string> correctAnswer = new List<string>(){
		"2","4","1","2","3","4","2","3","1","1","3","2","1","2","3"
	};
	private List<int> previousQuestion = new List<int>(){
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1
	};
	public static int questionNumberSlash =0;
	public int klik;
	public Transform resultObj;
	public Transform auraobj;
	public static string selectedAnswerSlash ;
	public static string choiceSelectedSlash = "n";
	public static int randQuestionSlash=-1;
	public float totalBenar=0;
	public float totalPertanyaan=15;
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
		scoreQuizSlashLabel.GetComponent<TextMesh>().text = "Score :"+ akumulasi.ToString("0");
		scoreQuizSlash=akumulasi;
		if(randQuestionSlash ==-1){
			randQuestionSlash = UnityEngine.Random.Range(0,14);
			for(int i=0;i<15;i++){
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
		if(questionNumberSlash==14){
			questionNumberSlash=0;
			resultObj.GetComponent<TextMesh>().text = "Hebat !,Kamu telah\n menyelesaikan 15 pertanyaan";
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


