using UnityEngine;
using System.Collections;

namespace spacerocks

{

	public class LifeDisplay : MonoBehaviour {

		public GameObject life1;
		public GameObject life2;
		public GameObject life3;

		int currentLife;

		// Use this for initialization
		void Start () {
			Lives.lives = 3;
		
		}
		
		// Update is called once per frame
		void Update () {
			if (currentLife != Lives.lives)
			{
				currentLife = Lives.lives;
				Update_Lives(currentLife);
			}
		}

		void Update_Lives(int life)
		{
			switch(life)
			{
			case 0:
				life1.SetActive(false);
				break;

			case 1:
				life2.SetActive(false);
				break;

			case 2:
				life3.SetActive(false);
				break;

			case 3:
				life1.SetActive(true);
				life2.SetActive(true);
				life3.SetActive(true);
				break;

			default:
				Debug.LogError("Too many or too little lives, what did you do???");
				break;
			}
		}

	}
}
