using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Manages all map processes
 */
public class MapManager : MonoBehaviour {

	public Button[] levelButtons;                    // A list of buttons that link to scenes
	public float stepDelay;                          // A value that is used to delay 

	/**
	 * Every time the map is loaded, this method
	 * will generate all of the level tiles from
	 * the data in GameControl
	 * 
	 * NOTE: Will not work if players decide
	 * to select an old mission. Level will
	 * have updated to that level and all progress
	 * will have been lost
	 */
	private void Start() {
		int level = GameControl.control.GetLevel();
		for (int i = 0; i <= level; i++) {
			Delay(stepDelay);                        // Delays the show level command. NOTE: Not working
			ShowLevel(i);
		}
	}

	/**
	 * Takes an integer and displays the level
	 * corresponding to that integer.
	 */
	private void ShowLevel(int level) {
		levelButtons[level].gameObject.SetActive(true);
	}

	/**
	 * A simple delay method for stalling
	 * a method
	 */
	private IEnumerator Delay(float delay) {
		yield return new WaitForSeconds(delay);
	}
}
