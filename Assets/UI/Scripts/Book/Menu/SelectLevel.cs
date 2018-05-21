using UnityEngine;
using System.Collections;

public class SelectLevel : MonoBehaviour
{

    public GameObject[] LineFixed;
    public GameObject[] LineAnimation;
    public GameObject[] Lock;


    // Use this for initialization
    void Start()
    {
        Store.Stage stage = Store.GetUnlockNewStage(true);
        if (stage != null)
        {
            m_setLastLevel(stage.Level);
        }
        if(Store.IsLevelUnlock(2))
        {
            Lock[0].SetActive(false);
        }
        if (Store.IsLevelUnlock(3))
        {
            Lock[1].SetActive(false);
        }
    }

    private void m_setLastLevel(int Level)
    {
        //LineFixed[Level - 2].SetActive(true);
        //LineAnimation[Level - 2].SetActive(false);
        gameObject.GetComponentInParent<MenuManager>().AnimateLevel(Level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
