using UnityEngine;
using System.Collections;

public class MoveObstacles : MonoBehaviour {
	
	void onTriggerEnter (Collider other) {
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
