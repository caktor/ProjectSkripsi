using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public GameObject[] LineLevel;
    public GameObject[] LineLevelFixed;
    public GameObject SelectLevelObject;

    // Use this for initialization
    void Start()
    {
        if (Store.IsLevelUnlock(2))
            LineLevelFixed[0].SetActive(true);

        if (Store.IsLevelUnlock(3))
            LineLevelFixed[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimateLevel(int Level)
    {
        LineLevelFixed[Level - 2].SetActive(false);
        LineLevel[Level-2].SetActive(true);
        StartCoroutine(SequenceAnimation(Level, 1));
    }
    private IEnumerator SequenceAnimation(int Level, float waitTime)
    {
        LineLevel[Level-2].GetComponent<Animator>().SetBool("Transition", true);
        yield return new WaitForSeconds(waitTime);
        SelectLevelObject.GetComponent<Animator>().SetInteger("Level", 2);
        

    }


}
