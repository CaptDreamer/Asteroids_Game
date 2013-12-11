using UnityEngine;
using System.Collections;

public class LevelDisplay : MonoBehaviour {

	static tk2dTextMesh levelText;
	static MeshRenderer enabled;

	// Use this for initialization
	void Start () {
		LevelDisplay.levelText = this.GetComponent<tk2dTextMesh> ();
		LevelDisplay.enabled = this.GetComponent<MeshRenderer> ();
		enabled.enabled = false;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public void GameOver()
	{
		enabled.enabled = true;
		levelText.text = "GAME OVER";
	}

	static public IEnumerator Level(int lev)
	{
		enabled.enabled = true;
		levelText.text = string.Format ("LEVEL {0}", lev);
		yield return new WaitForSeconds(5);
		enabled.enabled = false;
	}
}
