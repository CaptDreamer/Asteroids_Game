using UnityEngine;
using System.Collections;

public class MainMenuDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		Debug.Log ("Start!");
		Application.LoadLevel ("Main");
	}
}
