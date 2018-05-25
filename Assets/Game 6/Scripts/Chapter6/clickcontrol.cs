using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class clickcontrol : MonoBehaviour {

	public static string nameofobject;
	public GameObject objectnametext;
	public Transform objectnametextPos;
	public Transform succesclick;

	public int randNumb = 0;

	// Use this for initialization
	void Start () {

	
	
	}
	
	// Update is called once per frame
	void Update () {

		if (hintmater.hintused == "y")
		{
			randNumb = Random.Range (1,25);

			if ((gameObject.name == "jam") && (randNumb == 1))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";

			}

			if ((gameObject.name == "trash") && (randNumb == 2))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";

			}

			if ((gameObject.name == "microscope") && (randNumb == 3))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "backpack") && (randNumb == 4))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "pipet_tetes") && (randNumb == 5))
			{
				Debug.Log ("kepenek");
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "tabung_reaksi") && (randNumb == 6))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "beaker_glass") && (randNumb == 7))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "kertas_indikator_universal") && (randNumb == 8))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "buret") && (randNumb == 9))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "gelas_ukur") && (randNumb == 10))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "erlenmeyer") && (randNumb == 11))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "pipet_volume") && (randNumb == 12))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "batang_pengaduk") && (randNumb == 13))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "bola_hisap") && (randNumb == 14))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "akuades") && (randNumb == 15))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "pipet_ukur") && (randNumb == 16))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "rak_tabungreaksi") && (randNumb == 17))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "corong") && (randNumb == 18))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "labu_ukur") && (randNumb == 19))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "kaca_arloji") && (randNumb == 20))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "termometer") && (randNumb == 21))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "stopwatch") && (randNumb == 22))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "penjepit_kayu") && (randNumb == 23))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}

			if ((gameObject.name == "bunsen") && (randNumb == 24))
			{
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0);
				hintmater.hintused = "n";
			}
		}
	}

	void OnMouseDown()
	{
		nameofobject = gameObject.name;
		//Debug.Log (nameofobject);

		Destroy (gameObject);
		Destroy (objectnametext);

		GameObject.FindObjectOfType<GameNilai> ().ScoreNilai+=10;	
		
		trackingclicks.totalclicks = 0;
		Instantiate (succesclick, objectnametextPos.position, succesclick.rotation);
	}
}
