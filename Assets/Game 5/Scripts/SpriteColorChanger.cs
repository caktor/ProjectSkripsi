using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorChanger : MonoBehaviour {
	[Range(0,1f)]
	public float m_h, m_s, m_v;
	[Range(0,1f)]
	public float m_Red, m_Green, m_Blue,m_Alpha;
	private SpriteRenderer mySprite;
	Color myColor;
	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		myColor = new Color(m_Red, m_Green, m_Blue,m_Alpha);
		mySprite.color= myColor;
		Color.RGBToHSV(mySprite.color,out m_h,out m_s, out m_v);
		
	}
}
