using UnityEngine;
using System.Collections;

public class TuneMePlayer : MonoBehaviour {

	public static float maxlife;
	public static float currlife;
	public AudioSource test;

	private CharacterController controller;
	public float movespeed = 3.0f;
	public float dirspeed = 5.0f;
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
		if(Input.GetKey(KeyCode.RightArrow)){
			controller.Move(rigidbody.rotation * Vector3.right * dirspeed * Time.deltaTime);
		}
		else if(Input.GetKey(KeyCode.LeftArrow)){
			controller.Move(rigidbody.rotation * Vector3.left * dirspeed * Time.deltaTime);
		}
		Debug.Log("" + test.transform.position);
		//var velocity = controller.velocity;
	}
}
