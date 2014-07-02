using UnityEngine;
using System.Collections;

public class Informations : MonoBehaviour {

	public GUIStyle labels;
	public GUIStyle scoring;

	float startx = Screen.width;
	float endx = (Screen.width/2)+180;
	float endx2 = 50;
	float duration = 1;
	float startTime;
	string title;
	string title2 = "Best Score";
	string easy = "Easy:";
	string normal = "Normal:";
	string hard = "Hard:";
	int easyScore = 0;
	int normalScore = 0;
	int hardScore = 0;
	public MobileMenu script;

	// Use this for initialization
	void Start () {
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if(script.number == 0){
			title = "One Direction \nBest Song Ever";
			easyScore = 6908798;
		}else if(script.number == 1){
			easyScore = 2509;
			title = "Katy Perry \nRoar";
		}else if(script.number == 2){
			easyScore = 100;
			title = "Taylor Swift \nRed";
		}else if(script.number == 3){
			easyScore = 6787;
			title = "Jason Derulo \nTalk Dirty";
		}
	}
	void OnGUI(){
		float fractime = (Time.time - startTime)/ duration;

			float xPos = Mathf.Lerp(startx,endx, fractime);
			GUI.Label(new Rect(xPos, 10, 200, 20), title, labels);
			float xPos2 = Mathf.Lerp(0,endx2, fractime);
			GUI.Label(new Rect(xPos2, (Screen.height / 2), 200, 20), title2 + "\n"  + easy + easyScore + "\n" + normal  + normalScore + "\n" + hard + hardScore, scoring);
	}
}
