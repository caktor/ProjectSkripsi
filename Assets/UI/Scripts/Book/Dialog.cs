using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Background;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        Background.SetActive(true);
        Panel.SetActive(true);
        LeanTween.moveLocalY(Panel, 0, 1f).setEase(LeanTweenType.easeOutBack);
    }
    public void Close()
    {
        Background.SetActive(false);

        LeanTween.moveLocalY(Panel, 700, 0.5f).setEase(LeanTweenType.linear).setOnComplete(() => {
            Panel.SetActive(false);
        });
       
    }
}
