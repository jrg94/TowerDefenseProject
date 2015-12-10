using UnityEngine;
using System.Collections;

public class MyBaseStatus : MonoBehaviour {

	public static int health = 5;

	/**
	 * Trying to test the map update methods
	 * The load level script works and
	 * buttons spawn. Having a bit of an issue with
	 * the buttons going 'missing' after a run.
	 * 
	 * This is how we should send data to game control.
	 * This script would be better attached to the enemy
	 * base, but you get the idea. You would probably
	 * want a gui to pop up on win instead of a direct
	 * jump to the map.
	 *
	private void Update() {
		if (health == 0) {
			Win();
		}
	}

	private void Win() {
		GameControl.control.SetLevel (5);
		Application.LoadLevel ("TestMapMenu");
	}
	*/


}
