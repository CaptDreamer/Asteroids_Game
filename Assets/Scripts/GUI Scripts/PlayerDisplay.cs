using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class PlayerDisplay : MonoBehaviour 
	{
		GameObject ship;

		void Start()
		{
		}

		public void Player_Display (string status)
		{
			switch (status)
			{
			case "On":
				Debug.Log("On");
				PlayerToggle(true);
				break;
				
			case "Off":
				Debug.Log ("Off");
				PlayerToggle(false);
				break;
				
			case "Blink":
				Debug.Log("Blink");
				StartCoroutine (Blink ());
				break;
				
			default:
				Debug.LogError("Something went wrong, couldn't figure out what to do with the player display");
				break;
			}
		}

		IEnumerator Blink()
		{
			for(int i = 0; i < 5; i++)
			{
				if( this.renderer.enabled == true) { this.renderer.enabled = false; }
				else { this.renderer.enabled = true; }
				yield return new WaitForSeconds(.2f);
			}
			yield return null;
		}

		public void PlayerToggle(bool b)
		{
			this.renderer.enabled = b;
			this.collider2D.enabled = b;
		}
	}
}
