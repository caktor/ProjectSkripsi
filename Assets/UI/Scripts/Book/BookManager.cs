using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookManager : MonoBehaviour {

    private Animator m_animator;
    //public GameObject PopupConfig;
    //public GameObject SelectSubLevel;
    
    
	// Use this for initialization
	void Start () {
        m_animator = gameObject.GetComponent<Animator>();
        string GotoPage = Store.GetGotoPage();
        if (GotoPage != null)
        {
            m_animator.SetBool("Open",true);
            m_animator.SetBool(GotoPage,true);
        }

        
    }

   
	
    public Animator GetAnimator()
    {
        return m_animator;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.name)
                {
                    case "BtnMulai":  
					m_animator.SetBool("Open", true);
                        m_animator.SetBool("SelectLevel", true);
                        break;

				case "mulai":
					SceneManager.LoadScene ("Select_Chapter");
					Debug.Log ("iso");	
					break;

				case "materi":
					SceneManager.LoadScene ("Materi");
					Debug.Log ("materi");	
					break;

				case "KD":
					SceneManager.LoadScene ("KD");
					Debug.Log ("kompetensi dasar");
					break;
                    /*case "chap1":
                        Store.SetCurrentLevel(1);
                        m_animator.SetBool("SelectSubLevel", true);

                        break;
                    case "chap2":
                        Store.SetCurrentLevel(2);
                        m_animator.SetBool("SelectSubLevel2", true);
                        break;
					case "chap3":
						Store.SetCurrentLevel(3);
						m_animator.SetBool("SelectSubLevel3", true);
						break;
					case "chap4":
						Store.SetCurrentLevel(4);
						m_animator.SetBool("SelectSubLevel4", true);
						break;
					case "chap5":
						Store.SetCurrentLevel(5);
						m_animator.SetBool("SelectSubLevel5", true);
						break;
					case "chap6":
						Store.SetCurrentLevel(6);
						m_animator.SetBool("SelectSubLevel6", true);
						break;*/
                    
                    
                    case "BtnAchievement":
                        m_animator.SetBool("Open", true);
                        m_animator.SetBool("Achievement", true);
                        break;
				case "ExitGame":
					Application.Quit ();
					Debug.Log ("Keluar");
					break;
						
                    case "Back":
                        m_animator.SetBool("Open", false);
                        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("FadeInAchievment"))
                        {
                            m_animator.SetBool("Achievement", false);
                        } else if(m_animator.GetCurrentAnimatorStateInfo(0).IsName("FadeInSelectLevel")){
                            m_animator.SetBool("SelectLevel", false);

                        } else if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("FadeInSelectSubLevel"))
                        {
                            Debug.Log("DISBALE SELECTSUBLEVEL");
                            m_animator.SetBool("SelectSubLevel", false);
                            //SelectSubLevel.SetActive(false);

                        }
                        break;
				
                    
                    case "BtnTest":
                        PlayerPrefs.DeleteAll();
                        break;
                   // case "SelectCharacter":
                        //SceneManager.LoadScene("SelectCharacter");
                        //break;

                }
            } 
        }
    }
  
}
