using UnityEngine;
using System;
using System.Collections;
using HelperClasses;

public class GameController : MonoBehaviour {
	public GameObject playGround;
	public Position playGroundSpawn;

	public GameObject background;
	public Position backgroundSpawn;

	public GameObject enemies;
	public Position enemiesSpawn;

	public GameObject player;
	public int numberOfPlayersAllowed = 1;
	public Position playerSpawn;
	private int numberOfPlayersInGame;

	private float startTime;

	[HideInInspector]
	public PlayerController playerController;

	// Use this for initialization
	void Start () 
	{
		Instantiate(playGround, new Vector2(playGroundSpawn.x, playGroundSpawn.y), new Quaternion(0, 0, 0, 0));
		Instantiate(background, new Vector2(backgroundSpawn.x, backgroundSpawn.y), new Quaternion(0, 0, 0, 0));
		numberOfPlayersInGame = 0;
		startTime = Time.time;
		playerController = player.GetComponent<PlayerController>() ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(testPlayerSpawnable())
		{
			Instantiate(player, new Vector2(playerSpawn.x, playerSpawn.y), new Quaternion(0, 0, 0, 0));
			Instantiate(enemies, new Vector2(enemiesSpawn.x, enemiesSpawn.y), new Quaternion(0, 0, 0, 0));
			numberOfPlayersInGame++;
		}
		//playerController.
	}

	private bool testPlayerSpawnable()
	{
		if ((startTime < Time.time - 1.0f) && (numberOfPlayersInGame < numberOfPlayersAllowed))
			return true;
		else
			return false;
	}
}
