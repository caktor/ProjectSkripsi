using UnityEngine;
using System.Collections;

public class SelectSubLevel : MonoBehaviour
{

    public GameObject[] SubLevelItems;
    public Sprite StarSprite;
    public Sprite OffStarSprite;

    // Use this for initialization
    private void OnEnable()
    {
        Debug.Log("SelectSubLevel");
        Store.Stage stage = Store.GetUnlockNewStage(true);
        if (stage != null)
        {
            gameObject.GetComponentInParent<BookManager>().GetAnimator().SetBool("SelectLevel", true);
            SubLevelItems[stage.SubLevel - 1].GetComponent<SelectSubLevelItem>().Unlock();
        }
    }
    void Start()
    {

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
