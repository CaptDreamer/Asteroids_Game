using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class Game : MonoBehaviour {

		static int level;
		public static GameState gameState;

		// Asteroids
		public static int asteroids;
		public GameObject asteroidPrefab;

		// Ship
		public GameObject ship;

		// Use this for initialization
		void Start () 
		{
			level = 0;
			gameState = GameState.NewLevel;
		}
		
		// Update is called once per frame
		void Update () 
		{
			Debug.Log (level);
			if (gameState == GameState.NewLevel)
			{
				StartCoroutine( Generate_Level () );
				Next_Level();
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
			}
			if (gameState == GameState.Play && asteroids == 0 && gameState != GameState.NewLevel)
			{
				gameState = GameState.NewLevel;
			}
		}

		void Next_Level()
		{
			level ++;
			StartCoroutine (LevelDisplay.Level (level));

			Generate_Level ();
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
