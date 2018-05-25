using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balonController : MonoBehaviour {

	public enum JenisBalon{
		BalonAsam, BalonBasa, BalonNetral
	}
	public JenisBalon jenisBalon;

	void FixedUpdate () 
	{
		transform.position = new Vector3(transform.position.x , transform.position.y - 0.01f, 0);

		if (transform.position.y <= -4.5f)
		{
			Destroy(gameObject);
		}
	}

	
}
