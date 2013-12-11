using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	static public tk2dTextMesh scoreText;

	static int baseScore = 10;

	static int score;

	// Use this for initialization
	void Start () {
		ScoreDisplay.scoreText = this.GetComponent<tk2dTextMesh> ();
		ScoreDisplay.Add_Score (0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public void Add_Score(int multi)
	{
		ScoreDisplay.score += ScoreDisplay.baseScore * multi;
		Update_Score ();
	}

	static void Update_Score()
	{
		ScoreDisplay.scoreText.text = string.Format ("SCORE: {0}", ScoreDisplay.score);
	}


}
