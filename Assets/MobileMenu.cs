using UnityEngine;
using System.Collections;

public class MobileMenu : MonoBehaviour {

	private float minSwipeDistY = 100;
	private float minSwipeDistX = 100;

	private Vector2 startPos;
	private Vector3 initial = new Vector3(0,0,-10);
	public Vector3[] posts;
	
	private AudioSource[] audios;
	public AudioSource[] songs;
	public AudioSource[] effects;
	
	public int number = 0;
	int limit = 4;
	float smooth = 2f;

	void stopall(){
		foreach (AudioSource aud in audios) {
			aud.Stop();
		}
	}

	void Start(){
		audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		number = 0;
	}

	void Update()
	{
		//#if UNITY_ANDROID
		if (Input.touchCount > 0) 	
		{	
			Touch touch = Input.touches[0];			
			switch (touch.phase) 			
			{		
			case TouchPhase.Began:	
				startPos = touch.position;		
				break;	
			case TouchPhase.Ended:		
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;	
				if (swipeDistVertical > minSwipeDistY) 		
				{		
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);		
					if (swipeValue > 0)//up swipe
					{
						stopall();
						effects[1].Play();
						number = limit++;
					}
						//Jump ();
						else if (swipeValue < 0)//down swipe
					{

					}	
						//Shrink ();
				}
				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				if (swipeDistHorizontal > minSwipeDistX) 
				{
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					if (swipeValue > 0)//right swipe
					{//MoveRight ();
						number --;
						if(number < 0){
							number++;
						}

					}
					else if (swipeValue < 0)//left swipe
					{//MoveLeft ();
						number ++;
						if(number == limit){
							number--;
						}
					}		
							
				}
				break;
			}
		}
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
