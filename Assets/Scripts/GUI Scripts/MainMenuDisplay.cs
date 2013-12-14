using UnityEngine;
using System.Collections;

public class MainMenuDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
		Debug.Log ("Start!");
		Application.LoadLevel ("Main");
	}
}
