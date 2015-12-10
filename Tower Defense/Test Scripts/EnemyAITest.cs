using UnityEngine;
using System.Collections;

public class EnemyAITest : MonoBehaviour {

	public Vector3 velocity;
	private bool abletoattack = true;
	private bool timer = false;
	private float cooldowntime = 5.0f;
	public float xdir;				

	// Use this for initialization
	void Start () {
		velocity = new Vector3(0.0f, 0.0f, 0.0f);
		SetVelocity (-1.0f);
		Debug.Log ("Character initial xvelocity: " + velocity.x);
	}
	
	// Update is called once per frame
	void Update () {
		if (timer == true) {
			cooldowntime -= Time.deltaTime;
			if(cooldowntime <= 0){
				abletoattack = true;
				cooldowntime = 5.0f;
				timer = false;
			}
		}
	}

	void FixedUpdate(){
		if (Mathf.Abs(velocity.x) > 0) {
			MoveCharacter ();
		}
	}
	
	void MoveCharacter(){
		rigidbody.transform.Translate (velocity * Time.deltaTime);
	}

	void SetVelocity(float speed){
		velocity.x = speed;
		Debug.Log ("Character xvelocity: " + velocity.x);
	}

	void OnTriggerStay(Collider obj){
		if (obj.gameObject.name == "MyBase") {
			SetVelocity(0.0f);
			if(abletoattack){
				EnemyAttack(obj);
			}
		}
	}

	void EnemyAttack(Collider obj){
		obj.transform.Translate(0.0f, -1.0f, 0.0f);
		abletoattack = false;
		timer = true;
		obj.SendMessage ("Damage", 5);
	}

	public void OnGUI(){
		
		Debug.Log (this.rigidbody.position.x);
		GUI.TextArea (new Rect (10, 10, 200, 200), "X Velocity: " + velocity.ToString("G4") + "\n" + "X position: " + 
		              transform.position.ToString ("G4") + "\n" + "CooldownTime: " + 
		              cooldowntime.ToString ("G4") + "\n" + "AbleToAttack: " + 
		              abletoattack.ToString ()
		              + "\nTimer: " + timer.ToString());
	}
}
