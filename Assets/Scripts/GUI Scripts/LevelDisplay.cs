using UnityEngine;
using System.Collections;

public class LevelDisplay : MonoBehaviour {

	static tk2dTextMesh levelText;
	static MeshRenderer levelEnabled;

	// Use this for initialization
	void Start () {
		LevelDisplay.levelText = this.GetComponent<tk2dTextMesh> ();
		LevelDisplay.levelEnabled = this.GetComponent<MeshRenderer> ();
		levelEnabled.enabled = false;	
	}
	
	// Update is called once per frame
	void Update () {

	}

	static public void GameOver()
	{
		levelEnabled.enabled = true;
		levelText.text = "GAME OVER";
	}

	static public IEnumerator Level(int lev)
	{
		levelEnabled.enabled = true;
		levelText.text = string.Format ("LEVEL {0}", lev);
		yield return new WaitForSeconds(5);
		levelEnabled.enabled = false;
	}
}
