using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	public int health;

	void Update() {
		if (health == 0) {
			//SendMessage("Win");
			Destroy(gameObject);
		}
	}

	void Damage(int damage) {
		health = health - damage;
	}
}
