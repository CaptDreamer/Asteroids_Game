using UnityEngine;
using System.Collections;

namespace spacerocks
{

	public class Lives : MonoBehaviour
	{
		static public int lives;

		static public Movement ship;

		static Lives()
		{
		}

		public Lives()
		{
		}

		static public void Life_Down()
		{
			lives--;
			ship.Destroy_Ship ();
		}
	}
}
