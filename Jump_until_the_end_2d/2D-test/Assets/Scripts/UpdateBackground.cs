using UnityEngine;
using System.Collections;

public class UpdateBackground : MonoBehaviour {
	public GameObject background;
	public Transform spawnPosition;/*
	public float copyRate;
	private float time;*/

	void Start ()
	{
		print (transform.childCount);
	}

	void Update () {
		/*
		if(Time.time > time + copyRate && transform.childCount >= 1.0f)
		{
			time = Time.time + 1.0f;
			Instantiate(background, spawnPosition.position, spawnPosition.rotation);
			print (time);
			print (Time.time);
		}
		if (background.transform.position.x <= 14.5f)
			background.transform.position = Vector3 (45.0f, 0.0f, 0.0f);*/
		print (background.transform.position.x);
	}
}
