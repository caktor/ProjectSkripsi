using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl1 : MonoBehaviour {

	private List<string> question = new List<string>(){
		"Manakah yang termasuk <b>senyawa garam</b>...?",
		"Manakah yang termasuk <b>senyawa garam</b>...?",
		"Manakah yang termasuk <b>senyawa garam</b>...?",
		"Manakah yang termasuk <b>senyawa garam</b>...?",
		"Manakah yang termasuk <b>senyawa garam</b>...?",
		"Manakah yang termasuk <b>senyawa garam</b>...?",
		"Manakah yang termasuk <b>senyawa garam</b>...?",
		"Manakah yang termasuk <b>senyawa garam</b>...?",
		"Manakah yang termasuk <b>senyawa garam</b>...?",
		"Manakah yang termasuk <b>senyawa garam</b>...?",
		"Manakah yang termasuk <b>senyawa \nbukan garam</b>...?",
		"Manakah yang termasuk <b>senyawa \nbukan garam</b>...?",
		"Manakah yang termasuk <b>senyawa \nbukan garam</b>...?",
		"Manakah yang termasuk <b>senyawa \nbukan garam</b>...?",
		"Manakah yang termasuk <b>senyawa \nbukan garam</b>...?",
		"Manakah yang termasuk <b>senyawa \nbukan garam</b>...?",
		"Manakah yang termasuk <b>senyawa \nbukan garam</b>...?",
		"Manakah yang termasuk <b>senyawa \nbukan garam</b>...?",
		"Manakah yang termasuk <b>senyawa \nbukan garam</b>...?",
		"Manakah yang termasuk <b>senyawa \nbukan garam</b>...?",
	};
	private List<string> correctAnswer = new List<string>(){
		"1","4","2","1","3","3","4","3","3","3","3","4","1","3","2","4","2","3","1","1"
	};
	private List<int> previousQuestion = new List<int>(){
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,-1,-1,-1
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

			scoreQuizSlashLabel.text = ScoreQuizSlash.ToString();
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
			randQuestionSlash = UnityEngine.Random.Range(0,19);
			for(int i=0;i<20;i++){
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
		if(questionNumberSlash==19){
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


