﻿using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D col)
    {
        //destroyers are located in the borders of the screen
        //if something collides with them, the'll destroy it
        string tag = col.gameObject.tag;
        if(tag == "AsamProjectile" || tag == "BasaProjectile" || tag == "NetralProjectile"
        ||tag == "balonasam" || tag == "balonbasa" || tag == "balonnetral")
        {
            Destroy(col.gameObject);
        }
    }
}
