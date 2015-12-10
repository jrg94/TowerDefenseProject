using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/**
 * This script allows you to store any variables you want
 * and have those variables persist over scenes.
 * You could make several of these scripts to
 * hold specific data (Player, Enemy, etc.).
 */
public class GameControl : MonoBehaviour {

	public static GameControl control;

	/**
	 * Put variables that you would want to persist 
	 * through scenes here: experience, health,
	 * money, items, armor, etc.
	 * Make sure to provide getter setter methods
	 * for every variable.
	 */

	private int level;
	private int currentFileIndex;

	/**
	 * Method will be called from any level upon
	 * completion. Method sets the private
	 * level variable
	 */
	public void SetLevel(int level) {
		this.level = level;
	}

	/**
	 * Method allows access of level variable
	 */
	public int GetLevel() {
		return this.level;
	}

	/**
	 * Method will set what file index we currently want to save to
	 */
	public void SetFile(int file) {
		this.currentFileIndex = file;
	}

	/**
	 * Method will retrieve the current file index
	 */
	public int GetFile() {
		return currentFileIndex;
	}

	/**
	 * Produces a singleton on awake
	 */
	private void Awake() {
		if (control == null) {
			DontDestroyOnLoad(gameObject);
			control = this;
		} else if (control != this) {
			Destroy(gameObject);
		} 
	}

	/**
	 * Saves all relevant data to a file based on the
	 * integer input
	 * NOTE: This does not perform a write back but
	 * rather creates a fresh file every time.
	 */
	public void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerinfo" + GetFile() + ".dat");

		PlayerData data = new PlayerData();
		// Insert data from contoller to data object
		// ie: data.setExp(this.getExp());
		data.SetLevel(this.GetLevel());

		bf.Serialize(file, data);
		file.Close();
	}

	/**
	 * Loads all relevant data from a file based
	 * on some integer input
	 */
	public void Load(int index) {
		this.SetFile(index);
		if (File.Exists (Application.persistentDataPath + "/playerinfo" + index + ".dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerinfo" + index + ".dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close ();

			// Reassign all variables here
			// ie: this.setHealth(data.getHealth());
			this.SetLevel(data.GetLevel());
		}
	}

	/**
	 * Quick method for calling the next level
	 */
	public void LoadNextScreen(string level) {
		Application.LoadLevel(level);
	}

}

[Serializable]
class PlayerData {

	/**
	 * Place the variables you want to save in this section
	 * Also be sure to write getter/setter methods
	 */

	private int level;

	public void SetLevel(int level) {
		this.level = level;
	}

	public int GetLevel() {
			return level;
	}

}
