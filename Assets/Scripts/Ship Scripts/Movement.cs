using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public int rotateSpeed;
	public int thrustSpeed;

	// bullet prefab
	public GameObject bullet;

	// turret location
	public Transform turret;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) 
		{
			//rotate the ship by rotateSpeed per second
			float amount = ((-Input.GetAxis ("Horizontal")) * rotateSpeed) * Time.deltaTime;
			this.transform.Rotate(0, 0, amount);
		}
		if (Input.GetAxis ("Vertical") != 0) 
		{
			//thrust by thrustSpeed per second
			float thrust = ((Input.GetAxis ("Vertical")) * thrustSpeed) * Time.deltaTime;

			//cap movement forward
			thrust = thrust < 0 ? 0 : thrust;

			//move the ship
			this.transform.Translate(Vector3.up * thrust, Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.Space))
		{
			GameObject bul = (GameObject)Instantiate(bullet, turret.position, turret.rotation);
		}
	}
}
