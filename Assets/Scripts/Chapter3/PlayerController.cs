using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D myRigidbody;

	public bool grounded;
	public LayerMask whatIsGround;

	private Collider2D myCollider;

	public GameManager theGameManager;

	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D> ();

		myCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) 
		{
			if (grounded) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			}
		}
	
	}
	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "killbox")
		{
			theGameManager.RestartGame();
		}
	}
}
