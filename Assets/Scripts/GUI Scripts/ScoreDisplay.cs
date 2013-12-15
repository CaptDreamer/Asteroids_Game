using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	public tk2dTextMesh scoreText;

	int baseScore = 10;

	int score;

	// Use this for initialization
	void Start () {
		scoreText = this.GetComponent<tk2dTextMesh> ();
		Add_Score (0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Add_Score(int multi)
	{
		score += baseScore * multi;
		Update_Score ();
	}

	void Update_Score()
	{
		scoreText.text = string.Format ("SCORE: {0}", score);
	}


}
