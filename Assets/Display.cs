using UnityEngine;
using System.Collections;

public class Display : MonoBehaviour {

	public Texture lifebg;
	public Texture life;
	public float lifepercent;

	public float left;
	public float top;
	public float lifebgWIDTH;
	public float lifeWIDTH;
	public float HEIGHT;

	void OnGUI(){
		if(TuneMePlayerMobile.currlife > 250.0){
			TuneMePlayerMobile.currlife = TuneMePlayerMobile.maxlife;
		}
		lifepercent = TuneMePlayerMobile.currlife / TuneMePlayerMobile.maxlife;

		left = Screen.width/4;
		top = Screen.height/2;
		lifebgWIDTH = Screen.width / 2.0f;
		lifeWIDTH = lifepercent * lifebgWIDTH;
		HEIGHT = 50.0f;

		GUI.DrawTexture(new Rect(left, top, lifebgWIDTH, HEIGHT), lifebg, ScaleMode.StretchToFill, true, 1.0f);
		GUI.DrawTexture(new Rect(left, top, lifeWIDTH,   HEIGHT), life,   ScaleMode.StretchToFill, true, 1.0f);
	}


}
