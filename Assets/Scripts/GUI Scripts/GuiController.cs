using UnityEngine;
using System.Collections;

namespace spacerocks
{
	public class GuiController : MonoBehaviour
	{
		public LevelDisplay levelDisplay;
		public LifeDisplay lifeDisplay;
		public PlayerDisplay playerDisplay;
		public ScoreDisplay scoreDisplay;
		public RestartButton restartButton;

		Game gameController;

		void OnLevelWasLoaded(int level) 
		{
			if (level == 1)
				AddObjects();
			
		}

		void Start()
		{
			gameController = GameObject.Find ("GameScripts").GetComponent<Game> ();
			gameController.guiController = this;
		}

		public void AddObjects()
		{
			levelDisplay = GameObject.Find ("Level").GetComponent<LevelDisplay> ();
			lifeDisplay = GameObject.Find ("Life_Bar").GetComponent<LifeDisplay> ();
			playerDisplay = GameObject.Find ("Ship").GetComponent<PlayerDisplay> ();
			scoreDisplay = GameObject.Find ("Score").GetComponent<ScoreDisplay> ();
			restartButton = GameObject.Find ("Restart_Button").GetComponent<RestartButton> ();
		}
	}
}

