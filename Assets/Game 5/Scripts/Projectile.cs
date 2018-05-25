using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{

    public enum JenisProjectile{
        Asam, Basa, Netral
    }
    public JenisProjectile jenisProjectile;


    // Use this for initialization
    void Start()
    {
        //trailrenderer is not visible until we throw the bird
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<TrailRenderer>().sortingLayerName = "Foreground";
        //no gravity at first
        GetComponent<Rigidbody2D>().isKinematic = true;
        //make the collider bigger to allow for easy touching
        GetComponent<CircleCollider2D>().radius = Constants.BirdColliderRadiusBig;
        State = BirdState.BeforeThrown;
    }

    void FixedUpdate()
    {
        //if we've thrown the bird
        //and its speed is very small
        if (State == BirdState.Thrown &&
            GetComponent<Rigidbody2D>().velocity.sqrMagnitude <= Constants.MinVelocity)
        {
            //destroy the bird after 2 seconds
            StartCoroutine(DestroyAfter(2));
        }
    }

    public void OnThrow()
    {
        //play the sound
        GetComponent<AudioSource>().Play();
        //show the trail renderer
        GetComponent<TrailRenderer>().enabled = true;
        //allow for gravity forces
        GetComponent<Rigidbody2D>().isKinematic = false;
        //make the collider normal size
        GetComponent<CircleCollider2D>().radius = Constants.BirdColliderRadiusNormal;
        State = BirdState.Thrown;
    }

    IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    public BirdState State
    {
        get;
        private set;
    }
    void Move(float posX)
	{
		if (transform.position.x > posX)
		{
			transform.position = new Vector3(transform.position.x - 0.1f, -3, 0);
		}
		else if (transform.position.x < posX)
		{
			transform.position = new Vector3(transform.position.x + 0.1f, -3, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D col) 
	{   
        if((int) jenisProjectile == (int) col.GetComponent<balonController>().jenisBalon){
            // sama
            Destroy(col.gameObject);
            Debug.Log("Object Match  And You Get Score");
            GameObject.FindObjectOfType<GameManager2>().Score+=10;
        }else{
            //beda
            Destroy(col.gameObject);
            Debug.Log("Object Not Match  And You Min Score");
            GameObject.FindObjectOfType<GameManager2>().Score-=5;
        }
       
    }
}
