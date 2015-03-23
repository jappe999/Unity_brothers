using UnityEngine;
using System.Collections;

public class BackgroundRepeater : MonoBehaviour {
	public GameObject background;
	public Transform backgroundSpawn;
	public float rate;
	
	private float nextBackground;

	void Start ()
	{
		nextBackground = Time.time + rate;
	}
	
	void Update ()
	{
		if (Time.time > nextBackground)
		{
			nextBackground = Time.time + rate;
			Instantiate(background, backgroundSpawn.position, backgroundSpawn.rotation);
		}
	}
}
