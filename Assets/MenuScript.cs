using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	private Vector3 initial = new Vector3(0,0,-10);
	public Vector3[] posts;

	private AudioSource[] audios;
	public AudioSource[] songs;
	public AudioSource[] effects;

	public int number = 0;
	int limit = 4;
	float smooth = 2f;

	void Start(){
		audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		number = 0;
	}

	void stopall(){
		foreach (AudioSource aud in audios) {
			aud.Stop();
		}
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			number --;
			if(number < 0){
				number++;
			}
		}else if(Input.GetKeyDown(KeyCode.LeftArrow)){
			number ++;
			if(number == limit){
				number--;
			}
		}else if(Input.GetKeyDown(KeyCode.Return)){
			stopall();
			effects[1].Play();
			number = limit++;
		}
		//level selection
		if(number == 0){
			initial = posts[0];
			if(!songs[0].isPlaying){
				stopall();
				effects[0].Play();
				songs[0].Play();
			}
		}
		else if(number == 1){

			initial = posts[1];
			if(!songs[1].isPlaying){
				stopall ();
				effects[0].Play();
				songs[1].Play();
			}
		}
		else if(number == 2){
			
			initial = posts[2];
			if(!songs[2].isPlaying){
				stopall ();
				effects[0].Play();
				songs[2].Play();
			}
		}
		else if(number == 3){
			
			initial = posts[3];
			if(!songs[3].isPlaying){
				stopall ();
				effects[0].Play();
				songs[3].Play();
			}
		}
		transform.position = Vector3.Lerp(transform.position, initial, smooth*Time.deltaTime);
	}
}
