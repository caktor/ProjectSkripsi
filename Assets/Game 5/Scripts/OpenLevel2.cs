using UnityEngine;
using System.Collections;

public class OpenLevel2 : MonoBehaviour 
{
	public string levelName;

	void OnMouseDown()
	{
		transform.localScale = new Vector3(0.9f,0.9f,1);
	}
	
	void OnMouseUp()
	{
		transform.localScale = new Vector3(1,1,1);

		Application.LoadLevel(levelName);
	}

	public void backtomenu(){
		Application.LoadLevel(levelName);
	}

	
}
