using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class Game : MonoBehaviour  {

		int level;
		public GameState gameState;

		// Next level counter
		bool nextLevBool = false;

		// Asteroids
		public int asteroids;
		public GameObject asteroidPrefab;

		// Ship
		public GameObject ship;

		// Gui
		public GuiController guiController;

		// Use this for initialization
		void Start () 
		{
			DontDestroyOnLoad (this);
			level = 0;
			gameState = GameState.Menu;
			StartCoroutine (Starter ());
		}

		IEnumerator Starter()
		{
			yield return 0;
			while(true)
			{
				yield return StartCoroutine(GameEngine());
			}
		}
		
		// Update is called once per frame
		IEnumerator GameEngine () 
		{
			//Debug.Log (level);
			if (gameState == GameState.NewLevel)
			{
				yield return StartCoroutine( Next_Level());
				Debug.Log ("Ended Level Create");
				gameState = GameState.Play;
			}
			if (gameState == GameState.Play && Lives.lives == 0)
			{
				Clear_Board();
				level = 0;
				asteroids = 0;
				gameState = GameState.GameOver;
			}
			if (gameState == GameState.GameOver)
			{
				guiController.levelDisplay.GameOver();
				guiController.restartButton.RestartToggle(true);
			}
			if (gameState == GameState.Play && asteroids == 0 && gameState != GameState.NewLevel)
			{
				gameState = GameState.NewLevel;
			}
			yield return null;
		}

		IEnumerator Next_Level()
		{
			//Yield for a sec
			yield return 0;

			//Increment the level count
			level ++;

			//disable the player
			Debug.Log ("Trying to turn player off");
			guiController.playerDisplay.Player_Display ("Off");

			//display the level number
			yield return StartCoroutine( guiController.levelDisplay.level (level) );

			//Generate the asteroids
			yield return StartCoroutine( Generate_Level () );

			//blink the player
			guiController.playerDisplay.Player_Display ("Blink");

			//enable the player's controls if its safe
			guiController.playerDisplay.Player_Display ("On");

			yield return null;
		}

	    void Clear_Board()
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
			while(asteroids<4)
			{
				float rockX = Random.Range(-3,3);
				float rockY = Random.Range(-2,2);
				Instantiate(asteroidPrefab,new Vector3(rockX, rockY, 0), Quaternion.identity);
				Debug.Log("Generating asteroid number: " + asteroids);
				asteroids++;
			}
			yield break;
		}
	}
}
