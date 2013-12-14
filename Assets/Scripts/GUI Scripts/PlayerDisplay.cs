using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class PlayerDisplay : MonoBehaviour {

		public IEnumerator Player_Display (string status)
		{
			switch (status)
			{
			case "On":
				this.collider2D.enabled = true;
				this.renderer.enabled = true;
				break;
				
			case "Off":
				this.collider2D.enabled = false;
				this.renderer.enabled = false;
				break;
				
			case "Blink":
				for(int i = 0; i < 5; i++)
				{
					if( this.renderer.enabled == true) { this.renderer.enabled = false; }
					else { this.renderer.enabled = true; }
					yield return new WaitForSeconds(1);
				}
				break;
				
			default:
				Debug.LogError("Something went wrong, couldn't figure out what to do with the player display");
				break;
			}
		}
	}
}
