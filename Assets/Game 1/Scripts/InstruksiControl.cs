using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstruksiControl : MonoBehaviour {
	[SerializeField]
	private CanvasRenderer instruksi;
	[SerializeField]
	public GameObject play;
	public string nextScene;
	void Start()
	{
		play.SetActive(true);
		instruksi.gameObject.SetActive(false);
	}
	public void setActiveInstruksi(){
		Debug.Log("BIsa");
		instruksi.gameObject.SetActive(true);
		Time.timeScale =0;
		play.gameObject.SetActive(false);
	}
		public void deActiveInstruksi(){
		instruksi.gameObject.SetActive(false);
		Time.timeScale =1;
		play.gameObject.SetActive(true);
	}

	public void sceneQuiz(){
		Application.LoadLevel(nextScene);
	}

	void OnMouseDown()
	{
		Debug.Log("Cliked");
		if(this.tag=="openIntruksi")
		setActiveInstruksi();
		if(this.tag =="Quiz"){
			sceneQuiz();
		}
	}
	
}
