using UnityEngine;
using System.Collections;

public class TuneMePlayerMobile : MonoBehaviour {

	public static float maxlife;
	public static float currlife;
	public AudioSource test;
	
	private CharacterController controller;
	public float movespeed = 3.0f;
	public float dirspeed = 5.0f;

	bool steady = false;
	//Vector3 dir = Vector3.zero;
	// Use this for initialization
	void Start () {
		controller = (CharacterController)GetComponent("CharacterController");
		currlife = 0.0f;
		maxlife = 250.0f;
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Cube"){
			currlife +=30;
		}
	}
	// Update is called once per frame
	void Update () {
		controller.Move(rigidbody.rotation * Vector3.forward * movespeed * Time.deltaTime);
		/*
		dir.x = Input.acceleration.y * moveSpeed;
		transform.Translate(dir.x,0,0);
		*/
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Stationary){
				transform.position = new Vector3 (0, transform.position.y , transform.position.z);
				steady = true;
			}
			else if(touch.phase == TouchPhase.Ended){
				steady = false;
			}
			
		}
		if(steady == false){
			if(Input.acceleration.x > 0.05){
				controller.Move(rigidbody.rotation * Vector3.right * dirspeed * Time.deltaTime);
			}
			else if(Input.acceleration.x < -0.05){
				controller.Move(rigidbody.rotation * Vector3.left * dirspeed * Time.deltaTime);
			}
		}

		Debug.Log("" + Input.acceleration.x);
	}
}
