using UnityEngine;
using System;
using System.Threading;
using System.Collections;
using HelperClasses;

public class GameController : MonoBehaviour {
	public GameObject playGround;
	public Position playGroundSpawn;
	private GameObject activePlayGround;

	public GameObject background;
	public Position backgroundSpawn;

	public GameObject enemies;
	public Position enemiesSpawn;

	public GameObject player;
	public int numberOfPlayersAllowed = 1;
	public Position playerSpawn;
	private int numberOfPlayersInGame;
	private GameObject activePlayer;

	private float enemyTime;
	private float startTime;

	public GameObject GUICanvas;

	[HideInInspector]
	public PlayerController playerController;

	private int score = 0;
	private int highScore = 0;

	private bool initialiseNeeded = true;
	private float removeTime;
	private bool deathFase = false;
	private GameObject[] obstacleArray;
	private int obstacleArrayIterator = 0;

	public GameObject scoreText;

	void Initialise () 
	{
		activePlayGround = Instantiate(playGround, new Vector2(playGroundSpawn.x, playGroundSpawn.y), new Quaternion(0, 0, 0, 0)) as GameObject;
		Instantiate(background, new Vector2(backgroundSpawn.x, backgroundSpawn.y), new Quaternion(0, 0, 0, 0));
		numberOfPlayersInGame = 0;
		startTime = Time.time;
		enemyTime = Time.time;
		playerController = player.GetComponent<PlayerController>() ;
		initialiseNeeded = false;
		removeTime = 3.0f;
		deathFase = false;
		obstacleArray = new GameObject[10];
		obstacleArrayIterator = 0;
		scoreText.guiText.text = "Score: 0";
	}

	void Update () 
	{
		if(initialiseNeeded)
			Initialise();			
		else
		{
			score = playerController.score;
			scoreText.guiText.text = "Score: " + score;

			if(playerController.dead)
				deathFase = true;

			if(deathFase)
			{
				if(score > highScore)
					highScore = score;

				Destroy (activePlayGround);
				score = 0;
				numberOfPlayersInGame--;
				if(removeTime < 0)
				{
					foreach(GameObject remove in obstacleArray)
					{
						Destroy(remove);
					}
					GUICanvas.SetActive(true);
					deathFase = false;
					gameObject.SetActive(false);
					BackgroundMover background = (BackgroundMover) FindObjectOfType(typeof(BackgroundMover));
					background.remove = true;
					initialiseNeeded = true;
					scoreText.guiText.text = "Highscore: " + highScore;
				}
				else
					removeTime -= Time.deltaTime;
			} else
			{
				if(testPlayerSpawnable())
				{
					activePlayer = Instantiate(player, new Vector2(playerSpawn.x, playerSpawn.y), new Quaternion(0, 0, 0, 0)) as GameObject;
					numberOfPlayersInGame++;
					playerController = activePlayer.GetComponent<PlayerController>();
				}
				if(enemyTime < Time.time) {
					obstacleArray[obstacleArrayIterator] = Instantiate (enemies, new Vector2 (enemiesSpawn.x, enemiesSpawn.y), new Quaternion (0, 0, 0, 0)) as GameObject;
					if(obstacleArrayIterator < 9)
						obstacleArrayIterator++;
					else
						obstacleArrayIterator = 0;
					//Instantiate (enemies, new Vector2 (enemiesSpawn.x, enemiesSpawn.y), new Quaternion (0, 0, 0, 0));
					System.Random random = new System.Random();
					float randomTime = ((float) random.Next(0, 1000)) /500 + 1;
					enemyTime = Time.time + randomTime;
				}
			}
		}
	}

	private bool testPlayerSpawnable()
	{
		if ((startTime < Time.time - 1.0f) && (numberOfPlayersInGame < numberOfPlayersAllowed))
			return true;
		else
			return false;
	}
}
