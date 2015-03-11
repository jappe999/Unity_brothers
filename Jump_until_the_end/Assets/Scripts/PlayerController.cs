using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpSpeed = .25f;
	public float gravity = 2.0f;
	private Vector3 moveDirection = Vector3.zero;

	void Update ()
	{
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded)
		{
			//Geeft aan dat het personage alleen horizontaal kan lopen.
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, 0.0f);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			//Als de jump-toets wordt ingedrukt, springt het personage omhoog.
			if(Convert.ToBoolean(Input.GetAxis ("Jump")))
			   moveDirection.y = jumpSpeed;
		}
		moveDirection.x = Input.GetAxis ("Horizontal") * speed;
		//Door de zwaartekracht wordt het personage weer naar beneden gehaald.
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
  	}
}
