using UnityEngine;
using System.Collections;

public class Rock_Movement : MonoBehaviour {

	//variables
	int rotationSpeed;
	int movementSpeed;
	Vector3 direction;

	// Use this for initialization
	void Start () 
	{
		// initialize random direction, speed and rotation
		rotationSpeed = Random.Range (800, 1000);
		movementSpeed = Random.Range (30, 80);
		direction = new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
		Debug.Log ("rotationSpeed: " + rotationSpeed);
		Debug.Log ("movementSpeed: " + movementSpeed);
		Debug.Log ("direction: " + direction);

		//set the velocity
		this.rigidbody2D.velocity = ((direction*movementSpeed) * Time.deltaTime);

		//set the rotation
		this.rigidbody2D.AddTorque(rotationSpeed * Time.deltaTime);

		Debug.Log ("Velocity and Direction should be: " + ((direction * movementSpeed) * Time.deltaTime));
		Debug.Log ("Velocity and Direction is actually: " + this.rigidbody2D.velocity);
		Debug.Log ("Rotation: " + this.transform.rotation);
	}

	// Update is called once per frame
	void Update () {	
	}

	//check for collision
	void OnTriggerEnter2D(Collider2D coll) {
		string colName = coll.name;

		// check for world collision
		if (coll.tag == "World")
		{
			if(colName == "Top" || colName == "Bottom")
			{
				Debug.Log("Hit top or bottom");
				Vector3 vel = this.rigidbody2D.velocity;
				vel.y *= -1;
				this.rigidbody2D.velocity = vel;
			}
			if(colName == "Right" || colName == "Left")
			{
				Debug.Log("Hit right or left");
				Vector3 vel = this.rigidbody2D.velocity;
				vel.x *= -1;
				this.rigidbody2D.velocity = vel;
			}
		}

		// check for asteroid collision
		if (coll.tag == "Asteroid")
		{
			Destroy(this.gameObject);
		}

		// check for ship collision
		if (coll.tag == "Ship")
		{
			Debug.Log("Boom");
		}

		if (coll.tag == "Bullet")
		{
			Destroy(this.gameObject);
		}
	}
}
