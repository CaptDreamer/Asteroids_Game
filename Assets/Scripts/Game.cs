using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class Game : MonoBehaviour  {

		static int level;
		public static GameState gameState;

		// Asteroids
		public static int asteroids;
		public static GameObject asteroidPrefab;

		// Ship
		public static GameObject ship;

		// restart button
		static GameObject restartButton;

		static void OnLevelWasLoaded(int l)
		{
			if (l == 1)
			{
				restartButton = GameObject.Find("Restart_Button");
				restartButton.SetActive(false);
			}
		}

		// Use this for initialization
		static void Start () 
		{
			level = 0;
			gameState = GameState.NewLevel;
		}
		
		// Update is called once per frame
		static void Update () 
		{
			//Debug.Log (level);
			if (gameState == GameState.NewLevel)
			{
				StartCoroutine( Game.Generate_Level () );
				Game.Next_Level();
				if (Game.asteroids != 0)
				{
					gameState = GameState.Play;
				}
			}
			if (gameState == GameState.Play && Lives.lives == 0)
			{
				Clear_Board();
				gameState = GameState.GameOver;
			}
			if (gameState == GameState.GameOver)
			{
				LevelDisplay.GameOver();
				restartButton.SetActive(true);
			}
			if (gameState == GameState.Play && asteroids == 0 && gameState != GameState.NewLevel)
			{
				gameState = GameState.NewLevel;
			}
		}

		static void Next_Level()
		{
			//Increment the level count
			level ++;

			//disable the player
			StartCoroutine (ship.GetComponent<PlayerDisplay>().Player_Display ("Off"));

			//display the level number
			StartCoroutine (LevelDisplay.Level (level));

			//Generate the asteroids
			Generate_Level ();

			//blink the player
			StartCoroutine (ship.GetComponent<PlayerDisplay>().Player_Display ("Blink"));

			//enable the player's controls if its safe
			StartCoroutine (ship.GetComponent<PlayerDisplay>().Player_Display ("On"));
		}

		static void Clear_Board()
		{
			GameObject[] rocks = GameObject.FindGameObjectsWithTag ("Asteroid");
			//Debug.Log (rocks);
			foreach(GameObject rock in rocks)
			{
				Destroy(rock);
			}
		}

		IEnumerator Generate_Level()
		{
			while(Game.asteroids<4)
			{
				float rockX = Random.Range(-3,3);
				float rockY = Random.Range(-2,2);
				Instantiate(asteroidPrefab,new Vector3(rockX, rockY, 0), Quaternion.identity);
				Game.asteroids++;
			}
			yield return null;
		}
	}
}
