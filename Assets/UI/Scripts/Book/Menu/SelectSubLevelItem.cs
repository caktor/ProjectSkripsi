using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using TMPro;
using UnityEngine.UI;

public class SelectSubLevelItem : MonoBehaviour
{

    private int m_level;
    private Animator m_animator;
    public int SubLevel;
    public GameObject Lock;
    public GameObject[] Stars;
    private Sprite m_starSprite;
    private Sprite m_offStarSprite;

    private void OnEnable()
    {
        m_level = Store.GetCurrentLevel();

        Debug.Log("SELECT SUB LEVEL ENABLE "+ m_level);
        
        m_animator = gameObject.GetComponent<Animator>();

        if (SubLevel != 1 && SubLevel != 8)
        {
            m_starSprite = gameObject.GetComponentInParent<SelectSubLevel>().StarSprite;
            m_offStarSprite = gameObject.GetComponentInParent<SelectSubLevel>().OffStarSprite;


            //gameObject.GetComponentInChildren<TextMeshPro>().text = m_level + "." + (SubLevel - 1);
            int Score = Store.GetScore(m_level, SubLevel);
            int Star = Store.GetStar(m_level, SubLevel);
            Debug.Log("SELECT SCORE " + Score + "STAR : "+ Star);
            TextMesh TextScore = gameObject.GetComponentInChildren<TextMesh>();
            if (Score != 0)
            {
                TextScore.text = Score.ToString();
            } else
            {
                TextScore.text = "____";
            }
            
            if (Star != 0)
            {
                for (int i = 0; i < Star; i++)
                {
                    Stars[i].GetComponent<SpriteRenderer>().sprite = m_starSprite;
                }
            } else
            {
                
                for (int i = 0; i < 3; i++)
                {
                    Stars[i].GetComponent<SpriteRenderer>().sprite = m_offStarSprite;
                }
            }

        }
        else
        {
            //gameObject.GetComponentInChildren<TextMeshPro>().text = Store.GetVideoText(m_level);
        }
        if (Store.isSubLevelUnlock(m_level, SubLevel) || SubLevel == 1)
        {
            Lock.SetActive(false);
        } else
        {
            Lock.SetActive(true);
        }
    }

    // Use this for initialization
    void Start()
    {
        

    }
    
    public void Unlock()
    {
        m_animator.SetBool("Unlock", true);
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("IS LOCK ?" + Store.isSubLevelUnlock(m_level, SubLevel));
        if (Store.isSubLevelUnlock(m_level, SubLevel) || SubLevel == 1) { 
            Store.SetCurrentSubLevel(m_level, SubLevel);
            if(SubLevel != 1 && SubLevel != 8)
            {
                SceneManager.LoadScene("GameTest");
            }
            else
            {
                SceneManager.LoadScene("Story");
            }
        }
    }
}
