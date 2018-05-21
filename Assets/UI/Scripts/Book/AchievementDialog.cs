using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementDialog : MonoBehaviour
{

    public GameObject AchievementPhoto;
    public GameObject AchievementDescription;

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

    public void SetContent(Sprite Photo,string Description)
    {
        AchievementPhoto.GetComponent<Image>().sprite = Photo;
        AchievementDescription.GetComponent<Text>().text = Description;

    }
}
