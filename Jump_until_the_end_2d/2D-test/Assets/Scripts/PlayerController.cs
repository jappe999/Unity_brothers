using UnityEngine;
using System;
using System.Collections;
using HelperClasses;

public class PlayerController: MonoBehaviour
{
	public float maxSpeed = 10f;
	public Boundary boundary;
	
	Animator anim;

	public float jumpForce = 700f;
	public float jumpDelay;
	protected float nextJump;
	public GameObject floor;

	[HideInInspector]
	public float timeLastPointObtained;
	[HideInInspector]
	public int score = 0;
	[HideInInspector]
	public bool dead = false;
	[HideInInspector]
	public bool grounded = true;

	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	void FixedUpdate ()
	{		
		if (Time.time >= nextJump)
		{
			anim.SetBool ("Ground", grounded);
		}
		
		float move = Input.GetAxis ("Horizontal");
		
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		rigidbody2D.position = new Vector2
		(
			Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax),
			rigidbody2D.position.y
		);
	}
	
	void Update ()
	{	
		if(Convert.ToBoolean(Input.GetAxis("Jump")) && Time.time >= nextJump && testGrounded())
		{
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			nextJump = Time.time + jumpDelay;
		}
		if(transform.position.y < -5)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "dead")
			anim.SetBool ("Die", true);
		else if(other.gameObject.tag == "point")
			timeLastPointObtained = Time.time;
	}

	private bool testGrounded()
	{
		float height = transform.position.y;
		float heightFloor = floor.transform.position.y;
		if(height <= heightFloor)
			return false;
		return true;
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "dead") 
		{
			anim.SetBool ("Die", true);
			Destroy (gameObject.GetComponent ("PolygonCollider2D"));
			gameObject.tag = "deadPlayer";
			dead = true;
		} else if (other.tag == "point")
			score++;
	}
}