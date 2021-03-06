﻿using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class Rock_Movement : MonoBehaviour {

		//variables
		int rotationSpeed;
		int movementSpeed;
		public Vector3 direction;

		//Rocks
		public GameObject rockMedium;
		public GameObject rockSmall;
		public GameObject rockTiny;
		string rockType;

		// scoring
		public int largeScore;

		//Gui
		GuiController guiController;
		Game gameController;

		// Use this for initialization
		void Start () 
		{	
			//Set the Gui
			guiController = GameObject.Find ("GameScripts").GetComponent<GuiController> ();
			gameController = GameObject.Find ("GameScripts").GetComponent<Game> ();

			//check the type
			Type_Check ();

			//if its not a large, register it
			if (rockType != "L")
			{
				if (Application.loadedLevel == 1)
				gameController.asteroids++;
			}
			
			// initialize random direction, speed and rotation
			rotationSpeed = Random.Range (30, 80);
			movementSpeed = Random.Range (30, 80);

			// set the direction based on the type of rock
			if(rockType == "L")
			{
				direction = new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
			}

			//set the velocity
			this.rigidbody2D.velocity = ((direction*movementSpeed) * Time.deltaTime);

			//set the rotation
			this.rigidbody2D.AddTorque(rotationSpeed * Time.deltaTime);
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
					//mDebug.Log("Hit top or bottom");
					Vector3 vel = this.rigidbody2D.velocity;
					vel.y *= -1;
					this.rigidbody2D.velocity = vel;
				}
				if(colName == "Right" || colName == "Left")
				{
					// Debug.Log("Hit right or left");
					Vector3 vel = this.rigidbody2D.velocity;
					vel.x *= -1;
					this.rigidbody2D.velocity = vel;
				}
			}

			// check for asteroid collision
			if (coll.tag == "Asteroid")
			{
	//			Debug.Log("Crashed");
	//			Vector3 vel = this.rigidbody2D.velocity;
	//			vel.y *= -1;
	//			vel.x *= -1;
	//			this.rigidbody2D.velocity = vel;
			}

			// check for ship collision
			if (coll.tag == "Ship")
			{
				Lives.Life_Down();
			}

			if (coll.tag == "Bullet")
			{
				gameController.asteroids--;
				Process_Bullet();
			}
		}

		void Process_Bullet()
		{
			switch(rockType)
			{
			case "L":
				GameObject oneM = (GameObject)Instantiate(rockMedium, this.transform.position + new Vector3(.2f,.2f,0), Quaternion.identity);
				GameObject twoM = (GameObject)Instantiate(rockMedium, this.transform.position + new Vector3(-.2f,-.2f,0), Quaternion.identity);
				oneM.GetComponent<Rock_Movement>().direction = this.transform.right;
				twoM.GetComponent<Rock_Movement>().direction = -this.transform.right;
				guiController.scoreDisplay.Add_Score(1);
				Destroy(this.gameObject);
				break;

			case "M":
				GameObject oneS = (GameObject)Instantiate(rockSmall, this.transform.position + new Vector3(.1f,.1f,0), Quaternion.identity);
				GameObject twoS = (GameObject)Instantiate(rockSmall, this.transform.position + new Vector3(-.1f,-.1f,0), Quaternion.identity);
				oneS.GetComponent<Rock_Movement>().direction = this.transform.right;
				twoS.GetComponent<Rock_Movement>().direction = -this.transform.right;
				guiController.scoreDisplay.Add_Score(2);
				Destroy(this.gameObject);
				break;

			case "S":
				GameObject oneT = (GameObject)Instantiate(rockTiny, this.transform.position + new Vector3(.1f,.1f,0), Quaternion.identity);
				GameObject twoT = (GameObject)Instantiate(rockTiny, this.transform.position + new Vector3(-.1f,-.1f,0), Quaternion.identity);
				oneT.GetComponent<Rock_Movement>().direction = this.transform.right;
				twoT.GetComponent<Rock_Movement>().direction = -this.transform.right;
				guiController.scoreDisplay.Add_Score(3);
				Destroy(this.gameObject);
				break;

			case "T":
				guiController.scoreDisplay.Add_Score(4);
				Destroy(this.gameObject);
				break;

			default:
				Debug.LogError("Something went wrong, could not identify rock type");
				break;
			}
		}

		void Type_Check()
		{
			rockType = this.transform.name.Substring(9,1);
			//Debug.Log (rockType);
		}
	}
}