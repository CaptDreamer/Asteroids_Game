using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class Game : MonoBehaviour {

		static int level;
		public static GameState gameState;

		// Asteroids
		public static int asteroids;

		// Ship

		// Use this for initialization
		void Start () 
		{
			level = 1;
			gameState = GameState.NewLevel;
		}
		
		// Update is called once per frame
		void Update () 
		{
			if (gameState == GameState.NewLevel)
			{
				StartCoroutine(LevelDisplay.Level(level));
				gameState = GameState.Play;
			}
			if (gameState == GameState.Play && Lives.lives == 0)
			{
				gameState = GameState.GameOver;
			}
			if (gameState == GameState.GameOver)
			{
				LevelDisplay.GameOver();
			}
			if (gameState == GameState.Play && asteroids == 0)
			{
				gameState = GameState.NewLevel;
				Next_Level();
			}
		}

		void Next_Level()
		{
			level++;
			StartCoroutine (LevelDisplay.Level (level));
			asteroids = 10;

			// Do something to reset the level
		}
	}
}
