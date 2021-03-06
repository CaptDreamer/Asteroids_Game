﻿using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class MainMenuDisplay : MonoBehaviour {

		Game gameController;

		// Use this for initialization
		void Start () {
			gameController = GameObject.Find ("GameScripts").GetComponent<Game> ();
		
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown(KeyCode.Space))
			{
				OnClick ();
			}
		}

		void OnClick()
		{
			//Debug.Log ("Start!");
			gameController.gameState = GameState.NewLevel;
			Application.LoadLevel ("Main");
		}
	}
}
