using UnityEngine;
using System.Collections;

namespace spacerocks
{
	public class RestartButton : MonoBehaviour 
	{
		GameObject button;
		Game gameController;

		// Use this for initialization
		void Start () {
			button = this.gameObject;
			gameController = GameObject.Find ("GameScripts").GetComponent<Game> ();

			RestartToggle (false);
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void RestartToggle(bool b)
		{
			button.renderer.enabled = b;
			foreach(Transform transform in this.transform)
			{
				transform.renderer.enabled = b;
			}
			button.collider.enabled = b;
		}

		void OnClick()
		{
			gameController.gameState = GameState.NewLevel;
			Application.LoadLevel ("Main");
		}

	}
}
