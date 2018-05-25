using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject[] objectsSliced;
	private float lastCreated;


	public TextMesh scoreSenyawaLabel;
	public static int scoreSenyawa;
	public int ScoreSenyawa
	{
		set
		{
			scoreSenyawa = value;

			scoreSenyawaLabel.text = "Score: "+ScoreSenyawa.ToString();
		}
		get
		{
			return scoreSenyawa;
		}
	}

	private float speed;

	void Start () 
	{
		scoreSenyawa = 0;
		lastCreated = 0;

		lastCreated = Time.time;

		speed =2.5f;

		Invoke("CreateObjects", 0.5f);
	}

	void CreateObjects()
	{
		Instantiate(objectsSliced[Random.Range(0,objectsSliced.Length)], 
        new Vector3(Random.Range(-5.5f, 5.6f), -8f, 0) ,Quaternion.identity);

		if (ScoreSenyawa % 5 == 0)
			speed -= 0.1f;
		Invoke("CreateObjects", speed);
	}
}
