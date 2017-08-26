using UnityEngine;
using System.Collections;

public class oneLifeMenu : MonoBehaviour {
	
	public GameObject remembererObject;
	public GUISkin skin;
	float screenArea;
	float fontSizeOne;
	
	AudioSource click1;
	AudioSource click2;
	public Texture colorCorrection;

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Screen.lockCursor = false;
		remembererObject = GameObject.FindGameObjectWithTag("rememberer");
		
		click1 = gameObject.AddComponent<AudioSource>();
		click1.clip = Resources.Load("Audio/click 1") as AudioClip;
		click1.volume = .3f;
		click1.loop = false;
		click1.playOnAwake = false;
		
		click2 = gameObject.AddComponent<AudioSource>();
		click2.clip = Resources.Load("Audio/click 2") as AudioClip;
		click2.volume = .4f;
		click2.loop = false;
		click2.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		GUI.skin = skin;
		
		GUI.skin.button.fontSize = (int)fontSizeOne;
		GUI.skin.label.fontSize = (int)fontSizeOne;
		GUI.skin.toggle.fontSize = (int)fontSizeOne;
		
		screenArea = (Screen.width * Screen.height);
		fontSizeOne = ((screenArea * .00001107496f) + 14f);
		
		GUI.color = new Color(0,.22f,.42f,.16f);
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), colorCorrection);
		GUI.color = new Color(1,1,1,1);
		
		GUI.color = new Color(1,1,1,0.8f); 
		
		if (GUI.Button(new Rect(Screen.width / 2.3f, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "Play")) {
			if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
				remembererObject.GetComponent<rememberer>().oneLife = true;
				Application.LoadLevel(1);
			}

		
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "Main Menu")) {
			if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
			
			Application.LoadLevel("title");
		}
		
		GUI.color = new Color(1,1,1,1f); 
		
		GUI.Label(new Rect(Screen.width / 4f, Screen.height / 10f, Screen.width / 2f, Screen.height / 2), "    This is the one-life game mode. In this mode, you only get one chance to complete all the levels and finish the game. If you die, you will return to this menu. In addition, this can only be accomplished in one constant play through. You can not save the game and return to any level. If you accept this challenge, click \"Play\" below. Otherwise, you can return to the main menu. \n \n    Could you return to life if you were stuck in Irritum? Its time to find out. Good luck.");

		
		
	}
}
