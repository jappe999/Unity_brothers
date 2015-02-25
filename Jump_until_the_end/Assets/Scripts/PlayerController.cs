using UnityEngine;
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
			//Geeft aan dat de personage alleen horizontaal en in de diepte kan lopen.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			//Als de spatie wordt ingedrukt, springt de personage omhoog.
			if(Input.GetKey(KeyCode.Space))
			   moveDirection.y = jumpSpeed;
		}
		//Door de zwaartekracht wordt de personage weer naar beneden gehaald.
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
  	}
}
