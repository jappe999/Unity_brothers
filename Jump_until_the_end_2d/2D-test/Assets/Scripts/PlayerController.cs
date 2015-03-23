﻿using UnityEngine;
using System;
using System.Collections;
using HelperClasses;

public class PlayerController: MonoBehaviour
{
	public float maxSpeed = 10f;
	public Boundary boundary;
	
	Animator anim;
	
	bool grounded = true;
	public float jumpForce = 700f;
	public float jumpDelay;
	protected float nextJump;
	public bool dead;
	
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
		if(Convert.ToBoolean(Input.GetAxis("Jump")) && Time.time >= nextJump)
		{
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			nextJump = Time.time + jumpDelay;
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "DeathZone" || other.tag == "Enemy") {
			anim.SetBool ("Die", true);
			Destroy(gameObject.GetComponent("CircleCollider2D"));
			Destroy(gameObject.GetComponent("BoxCollider2D"));
			Destroy(gameObject.GetComponent("PolygonCollider2D"));
			gameObject.tag = "DeadPlayer";
			print ("You just died...");
		}
	}
}
/*
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpSpeed = .25f, gravity = 2.0f, mass;
    private float heigthEnergy, verticalKineticEnergy;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //animation.Play("Run");
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            //Tells the character that it can only walk on the vertical axis
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            //If the jump-button is pressed, the character will jump
            if (Convert.ToBoolean(Input.GetAxis("Jump")))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.x = Input.GetAxis("Horizontal") * speed;
        //Door de zwaartekracht wordt het personage weer naar beneden gehaald.
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private float calculateNewPositionOnYAsix()
    {
        if (controller.isGrounded)
            verticalKineticEnergy = 0;

        float speed = (float) Math.Sqrt(Convert.ToDouble( 2 * verticalKineticEnergy / mass));
        float deltaDistance = speed * Time.deltaTime;

        return deltaDistance;
    }
}
*/