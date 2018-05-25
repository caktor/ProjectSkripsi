using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour {

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
	public static int questionNumber =0;
	public int klik;
	public Transform resultObj;
	public Transform auraobj;
	public static string selectedAnswer ;
	public static string choiceSelected = "n";
	public static int randQuestion=-1;
	public float totalBenar=0;
	public float totalPertanyaan=20;
	public TextMesh scoreQuizLabel;
	public static float scoreQuiz;
	public float ScoreQuiz
	{
		set
		{
			scoreQuiz = value;

			scoreQuizLabel.text = ScoreQuiz.ToString();
		}
		get
		{
			return scoreQuiz;
		}
	}
	void Start()
	{
		scoreQuiz=0;
		GetComponent<TextMesh>().text = question[0];
	}
	void Update()
	{
		
		float akumulasi =(totalBenar/totalPertanyaan)*100;
		scoreQuizLabel.GetComponent<TextMesh>().text = "Score :"+ akumulasi;
		scoreQuiz=akumulasi;
		if(randQuestion ==-1){
			randQuestion = UnityEngine.Random.Range(0,19);
			for(int i=0;i<20;i++){
				if(randQuestion!=previousQuestion[i]){
					
				}else{
					randQuestion=-1;
				}
			}
		}
		if(randQuestion>-1){
			GetComponent<TextMesh>().text = question[randQuestion];
			previousQuestion [questionNumber]= randQuestion;
		}
		if(questionNumber==19){
			questionNumber=0;
			resultObj.GetComponent<TextMesh>().text = "Hebat !,Kamu telah\n menyelesaikan 20 pertanyaan";
			Application.LoadLevel("Chap1 MainMenu");
		}

		if(choiceSelected =="y" ){
			choiceSelected = "n";
			klik+=1;
			questionNumber+=1;
			if(correctAnswer[randQuestion]==selectedAnswer){
				resultObj.GetComponent<TextMesh>().text = "Benar!";
					totalBenar+=1;
					TextControl.randQuestion=-1;
			}else{
				nextButton.resetaura ="n";
				resultObj.GetComponent<TextMesh>().text = "Salah!";
				TextControl.randQuestion=-1;
				// if(correctAnswer[randQuestion]=="1"){
				// 	auraobj.GetComponent<Transform>().position = new Vector3(-5.66f,-1f,10f);
				// }
				// if(correctAnswer[randQuestion]=="2"){
				// 	auraobj.GetComponent<Transform>().position = new Vector3(-5.66f,-2.14f,10f);
				// }
				// if(correctAnswer[randQuestion]=="3"){
				// 	auraobj.GetComponent<Transform>().position = new Vector3(1f,-1f,10f);
				// }
				// if(correctAnswer[randQuestion]=="4"){
				// 	auraobj.GetComponent<Transform>().position = new Vector3(1f,-2.14f,10f);
				// }
			}
		
		}
		
	}
}


