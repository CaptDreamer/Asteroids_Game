using UnityEngine;
using System.Collections;

public class Bullet_Movement : MonoBehaviour {

	//bullet speed
	public int bulletSpeed;

	// Use this for initialization
	void Start () {
		this.rigidbody2D.AddForce (this.transform.up * bulletSpeed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		Destroy (this.gameObject);
	}
}
