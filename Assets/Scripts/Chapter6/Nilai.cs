using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nilai : MonoBehaviour {

	private Text teksNilai;
	private int nilai;

	// Use this for initialization
	void Start () {
		teksNilai = GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update () {
		teksNilai.text = "" + nilai;

	}
	public int TambahNilai(int nilai)
	{
		nilai += nilai;
		return nilai;

	}
}
