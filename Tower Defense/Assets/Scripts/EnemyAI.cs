using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	//velocity on the x axis
	public Vector3 velocity;
	public float xdir;				
	public bool infront = false;
	private float cooldowntime = 5.0f;
	private bool timer = false;
	private bool abletoattack = true;
	
	//Set initial values when object is created	
	void Start () {

		velocity = new Vector3(0.0f, 0.0f, 0.0f);
		SetVelocity (-1.0f);
		Debug.Log ("Character initial xvelocity: " + velocity.x);
	}

	//Used for updating every tick
	void Update () {
	
		//If timer is activated, update it
		if (timer == true) {

			//Subtract the time from last tick
			cooldowntime -= Time.deltaTime;

			if(cooldowntime <= 0){

				abletoattack = true;
				cooldowntime = 5.0f;

				timer = false;
			}
		}

		//Add function to destroy self if health is 0
	}

	//Used for updating at an even interval
	void FixedUpdate(){
	
		//Check if the velocity vector is set to zero to save a little time, might not be necessary
		if (Mathf.Abs(velocity.x) > 0) {

			MoveCharacter ();
		}
	}
	
	//Move the rigid body that is attached to this script
	void MoveCharacter(){

		rigidbody.transform.Translate (velocity * Time.deltaTime);
	}

	//Trigger event:
	//see what object this object collided with
	void OnTriggerStay(Collider obj){

		if(abletoattack){
				
			SetVelocity (0.0f);
			EnemyAttack(obj);
			Debug.Log ("Attack");
		}

		//Used for testing
		if (obj.GetComponent<WarriorStats> ().health <= 0.0f) {

			timer = false;
			SetVelocity (-1.0f);
			abletoattack = true;
			//Break out of function
			return;
		}
	}

	//This object uses the collider information to attack object collided with
	void EnemyAttack(Collider obj){

		//this will be where the attack variables will go
		obj.GetComponent<WarriorStats>().health -= 1;
		abletoattack = false;

		Debug.Log (obj + " health: " + obj.GetComponent<WarriorStats> ().health);

		//Start cooldown timer
		timer = true;
	}

	void SetVelocity(float speed){

		velocity.x = speed;
		//Debug.Log ("Character xvelocity: " + velocity.x);
	}

	bool ObjectInFrontOf(Collider component){

		//Debug.Log ("Theres something in front of " + component);
		return false;
	}

	//Display information in real-time
	public void OnGUI(){

		//Debug.Log (this.rigidbody.position.x);
		GUI.TextArea (new Rect (10, 10, 200, 200), "X Velocity: " + velocity.ToString("G4") + "\n" + 
		              "X position: " + transform.position.ToString ("G4") + "\n" + 
		              "CooldownTime: " + cooldowntime.ToString ("G4") + "\n" + 
		              "AbleToAttack: " + abletoattack.ToString () + "\n" + 
		              "Basehealth: " + MyBaseStatus.health.ToString ());
	}
	
}
