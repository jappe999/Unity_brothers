using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour 
{
	public float maxSpeed = 2;

	//void FixedUpdate () 
	void Update()
	{
		float xPosition = transform.position.x - maxSpeed* Time.deltaTime;
		Vector2 newPosition = new Vector2(xPosition, transform.position.y);
		transform.position = newPosition;
	}
}