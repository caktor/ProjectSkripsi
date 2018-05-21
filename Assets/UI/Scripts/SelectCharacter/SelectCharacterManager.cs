using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCharacterManager : MonoBehaviour {

    public GameObject Container;
    public GameObject[] Characters;
    public GameObject CharacterText;
    public GameObject LockSprite;
    public GameObject CheckSprite;
    private int m_spacing = -5;
    private float m_position ;
    private int m_selector = 0;
    private GameObject m_check;
    public GameObject Left;
    public GameObject Right;
    
    // Use this for initialization

    void Start () {
        int i = 0;
        foreach (GameObject character in Characters)
        {
            GameObject tmp = Instantiate(character, new Vector3( (-i * m_spacing), 0.52f, -6.59f), Quaternion.identity, Container.transform);
            if(i > 0)
            {
                if (!Store.IsCharacterUnlock(i)){
                    Instantiate(LockSprite, new Vector3( (-i * m_spacing), 1.0f, -7.0f), Quaternion.identity, Container.transform);
                }
            }
            LeanTween.rotateAround(tmp, Vector3.up, 360, 5.0f).setLoopClamp();
            i++;
        }
        CharacterText.GetComponent<Text>().text = Characters[0].name;
       
        m_selector = Store.GetCharacter();
        
        Container.transform.position += new Vector3(m_spacing * m_selector,0, 0);
        m_position = Container.transform.position.x;

        m_check = Instantiate(CheckSprite, new Vector3( 0, 1.8f, -7.0f), Quaternion.identity, Container.transform);
    }
    public string CharacterIndexToName(int index)
    {
        return Characters[index].name;
    }


    public void PrevCharacter()
    {
        if(m_selector > 0)
        {
            if (m_selector == 1)
            {
                Left.SetActive(false);
            }
            Right.SetActive(true);
            m_position -= m_spacing;
            LeanTween.moveX(Container, m_position, 1.0f)
                .setEase(LeanTweenType.easeOutBack);
            m_selector--;
            CharacterText.GetComponent<Text>().text = Characters[m_selector].name;

            
        } 


    }
    public void NextCharacter()
    {
        if(m_selector < Characters.Length - 1)
        {
            if (m_selector == Characters.Length - 2)
            {
                Right.SetActive(false);
            }
            Left.SetActive(true);
            m_position += m_spacing;
            LeanTween.moveX(Container, m_position, 1.0f)
                .setEase(LeanTweenType.easeOutBack);
            m_selector++;
            CharacterText.GetComponent<Text>().text = Characters[m_selector].name;
          
        } 
    }
    public void SelectCharacter()
    {
        if(Store.IsCharacterUnlock(m_selector) || m_selector == 0){
            m_check.transform.position = new Vector3(0, 1.8f, -7.0f);
            Store.SetCharacter(m_selector, Characters[m_selector].name);
        }
    }
    public void BackClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ScanCard()
    {
        SceneManager.LoadScene("ScanAR");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
