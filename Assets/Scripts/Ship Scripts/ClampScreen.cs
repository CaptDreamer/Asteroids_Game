using UnityEngine;
using System.Collections;

public class ClampScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ClampCheck (this.transform.position);
	}

	void ClampCheck(Vector3 loc)
	{
		Vector3 position = loc;
		if (position.y > 3 || position.y < -3)
		{
			position.y *= -1;
			Debug.Log (position);
			this.transform.position = position;
		}
		if (position.x > 4 || position.x < -4)
		{
			position.x *= -1;
			//Debug.Log (position);
			this.transform.position = position;
		}
	}
}
