using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {


    public GameObject fruitSlicePrefab;
    public float startForce = 15f;
    Rigidbody2D rb;
   // private statsScore myScore;
   // private int scoreValue =5;
  //  public float penguranganWaktu = 5f;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
      //  myScore = GameObject.Find("Score").GetComponent<statsScore>();
        if (col.tag == "Blade" && this.tag =="garamhidrolisis" )
        {
            Debug.Log("Hit Garam Hidrolisis");
            GameObject.FindObjectOfType<ObjectSpawner>().ScoreSenyawa+=2*10;
            Vector3 direction = (col.transform.position - transform.position).normalized;
            GetComponent<AudioSource>().Play();
            Quaternion rotation = Quaternion.LookRotation(direction);
            Destroy(this.gameObject); 
            Instantiate(fruitSlicePrefab, transform.position, transform.rotation);
           // myScore.AddScore(scoreValue);
        }
        if (col.tag == "Blade" && this.tag =="garamtakhidrolisis" )
        {
            Debug.Log("Hit Garam Tak Hidrolisis");
            GameObject.FindObjectOfType<ObjectSpawner>().ScoreSenyawa-=1*10;
            Vector3 direction = (col.transform.position - transform.position).normalized;
            GetComponent<AudioSource>().Play();
            Quaternion rotation = Quaternion.LookRotation(direction);
            Destroy(this.gameObject); 
            Instantiate(fruitSlicePrefab, transform.position, transform.rotation);
           // myScore.AddScore(scoreValue);
        }
    }
}
