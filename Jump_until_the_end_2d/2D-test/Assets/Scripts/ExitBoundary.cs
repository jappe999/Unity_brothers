using UnityEngine;
using System.Collections;

public class ExitBoundary : MonoBehaviour {

	void OnTriggerExit2D (Collider2D background)
	{
		Destroy (background.gameObject);
		print ("Background destroyed");
	}
}
