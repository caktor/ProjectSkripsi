using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterDialog : MonoBehaviour
{

    public GameObject CharacterNameText;

    // Use this for initialization
    void Start()
    {
        //m_achievementPhoto = gameObject.GetComponentInChildren<Image>();
        //m_achievementDescription = gameObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetContent( string CharacterName)
    {
        
        CharacterNameText.GetComponent<Text>().text = CharacterName;

    }
}
