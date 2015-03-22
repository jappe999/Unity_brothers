using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour {
	public float maxSpeed = 2;

	void FixedUpdate () {
		float move = -1;
		rigidbody2D.velocity = new Vector2(move * maxSpeed, 0);
	}
}