using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
	public float speed;

	void Start () {
		rigidbody2D.velocity = -(transform.right * speed);
	}
}
