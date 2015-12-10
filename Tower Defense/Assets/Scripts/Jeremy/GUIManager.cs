using UnityEngine;
using System.Collections;

/**
 * Handles mid-scene GUI interaction
 * Currently unused! However, may be useful
 * for in game menus
 */
public class GUIManager : MonoBehaviour {
		
	public static GUIManager guiManager;

	/**
	 * Produces a singleton on awake
	 */
	private void Awake() {
		if (guiManager == null) {
			DontDestroyOnLoad(gameObject);
			guiManager = this;
		} else if (guiManager != this) {
			Destroy(gameObject);
		}
	}
		
	/**
	 * Initializes the GUI when it is opened
	 */
	private void Open () {
	}

	/**
	 * Hide the GUI when it is closed
	 */
	private void Close () {
	}


}
