using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour {
    public GameObject BladeTrail;
    GameObject currentBlade;
    Vector2 previousPosition;
    CircleCollider2D circleCollider;
    public float minSlicesVelocity =.0001f;
    bool isCutting = false;
    Rigidbody2D rb2d;
    Camera cam;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if (isCutting)
        {
            StartCut();
        }
        
	}

    void StartCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb2d.position = newPosition;
        float velocity = (newPosition - previousPosition).magnitude*Time.deltaTime;
        if (velocity > minSlicesVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }
        previousPosition = newPosition;
    }
     void StartCutting()
    {
        isCutting = true;
        currentBlade = Instantiate(BladeTrail, transform);
        circleCollider.enabled = false;
    }

     void StopCutting()
    {  
        isCutting = false;
        currentBlade.transform.SetParent(null);
        Destroy(currentBlade, 2f);
        circleCollider.enabled = false;
    }
}
