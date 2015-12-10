using UnityEngine;
using System.Collections;

public class WarriorStats: MonoBehaviour {

	public int health = 5;

	void Update () {

		if (health == 0) {
			Destroy(this.gameObject);
		}
	}
	
}
