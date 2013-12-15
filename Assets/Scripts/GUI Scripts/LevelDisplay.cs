using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class LevelDisplay : MonoBehaviour {

		tk2dTextMesh levelText;
		Renderer levelEnabled;

		// Use this for initialization
		void Start () {
			levelText = this.GetComponent<tk2dTextMesh> ();
			levelEnabled = this.renderer;
			// levelEnabled.enabled = false;	
		}
		
		// Update is called once per frame
		void Update () {

		}

		public void GameOver()
		{
			levelEnabled.enabled = true;
			levelText.text = "GAME OVER";
		}

		public IEnumerator level(int lev)
		{
			Debug.Log (levelEnabled.enabled);
			levelEnabled.enabled = true;
			levelText.text = string.Format ("LEVEL {0}", lev);
			yield return new WaitForSeconds(5);
			levelEnabled.enabled = false;
		}
	}
}
