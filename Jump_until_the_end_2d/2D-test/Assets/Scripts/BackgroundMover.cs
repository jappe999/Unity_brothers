﻿using UnityEngine;
using System;
using System.Collections;

public class BackgroundMover : MonoBehaviour 
{
	public float maxSpeed = 2.0f;
	public float deleteXValue = 0.0f;
	public bool forwardMoving = false;

	[HideInInspector]
	public bool remove;

	void Update()
	{
		float xPosition = transform.position.x - (forwardMoving? + maxSpeed * Time.deltaTime: -maxSpeed * Time.deltaTime);
		if ((xPosition > deleteXValue) && (!forwardMoving) || (xPosition < deleteXValue) && forwardMoving)
			GameObject.Destroy (gameObject);

		Vector2 newPosition = new Vector2(xPosition, transform.position.y);
		transform.position = newPosition;
		if(remove)
			Destroy(gameObject);
	}
}