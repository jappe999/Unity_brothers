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
