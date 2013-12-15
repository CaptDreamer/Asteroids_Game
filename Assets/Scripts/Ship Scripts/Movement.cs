using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class Movement : MonoBehaviour {

		public int rotateSpeed;
		public int thrustSpeed;

		// colliding
		bool colliding = true;

		//Game Controller
		Game gameController;

		// bullet prefab
		public GameObject bullet;

		// turret location
		public Transform turret;

		// set values for damage processing
		PolygonCollider2D col;
		MeshRenderer mesh;
		bool alive = true;

		// Use this for initialization
		void Start () {
			gameController = GameObject.Find ("GameScripts").GetComponent<Game> ();
			Lives.ship = this;
			col = this.GetComponent<PolygonCollider2D> ();
			mesh = this.GetComponent<MeshRenderer> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetAxis ("Horizontal") != 0 && alive) 
			{
				//rotate the ship by rotateSpeed per second
				float amount = ((-Input.GetAxis ("Horizontal")) * rotateSpeed) * Time.deltaTime;
				this.transform.Rotate(0, 0, amount);
			}
			if (Input.GetAxis ("Vertical") != 0 && alive) 
			{
				//thrust by thrustSpeed per second
				float thrust = ((Input.GetAxis ("Vertical")) * thrustSpeed) * Time.deltaTime;

				//cap movement forward
				thrust = thrust < 0 ? 0 : thrust;

				//move the ship
				this.transform.Translate(Vector3.up * thrust, Space.Self);
			}
			if (Input.GetKeyDown (KeyCode.Space) && alive)
			{
				Instantiate(bullet, turret.position, turret.rotation);
			}
		}

		public void Destroy_Ship()
		{
			StartCoroutine (Ship_Respawn());
		}

		IEnumerator Ship_Respawn()
		{
			// Turn off the collision and the mesh
			gameController.guiController.playerDisplay.Player_Display ("Off");

			// Return Ship to center
			this.transform.rotation = new Quaternion (0, 0, 0, 0);
			this.transform.position = new Vector3 (0, 0, 0);

			//wait for gamestate to update 1 frame
			yield return 0;

			// Resume Play if there are more lives
			if(gameController.gameState == GameState.Play)
			{
				// Blink
				gameController.guiController.playerDisplay.Player_Display ("Blink");
				
				// Wait
				yield return new WaitForSeconds (3);

				//enable the player's controls if its safe
				while(colliding)
				{
					foreach(GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid"))
					{
						if(this.renderer.bounds.Intersects(asteroid.renderer.bounds))
						{
							Debug.Log("Not Safe to Spawn");
							colliding = true;
						}
						else
						{
							colliding = false;
						}
					}
				}

				gameController.guiController.playerDisplay.Player_Display ("On");
			}
		}
	}
}
