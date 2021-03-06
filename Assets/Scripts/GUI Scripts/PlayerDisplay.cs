﻿using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class PlayerDisplay : MonoBehaviour 
	{
		GameObject ship;

		string state;

		void Start()
		{
		}

		public void Player_Display (string status)
		{
			switch (status)
			{
			case "On":
				Debug.Log("On");
				state = "On";
				PlayerToggle(true);
				break;
				
			case "Off":
				Debug.Log ("Off");
				state = "Off";
				PlayerToggle(false);
				break;
				
			case "Blink":
				Debug.Log("Blink");
				state = "Blink";
				StartCoroutine (Blink ());
				break;
				
			default:
				Debug.LogError("Something went wrong, couldn't figure out what to do with the player display");
				break;
			}
		}

		IEnumerator Blink()
		{
			while(state == "Blink")
			{
				if( this.renderer.enabled == true) { this.renderer.enabled = false; }
				else { this.renderer.enabled = true; }
				yield return new WaitForSeconds(.2f);
			}
		}

		public void PlayerToggle(bool b)
		{
			this.renderer.enabled = b;
			this.collider2D.enabled = b;
		}
	}
}
