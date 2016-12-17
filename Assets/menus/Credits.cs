using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	
	public GUISkin skin;
	public GameObject remembererObject;
	
	float screenArea;
	float fontSizeOne;
	
	AudioSource click1;
	AudioSource click2;
	AudioSource song;
	public Texture colorCorrection;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
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
		
		song = gameObject.AddComponent<AudioSource>();
		song.clip = Resources.Load("Audio/Idea B-1 reversed") as AudioClip;
		song.loop = true;
		song.volume = .5f;
		song.Play();
	
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
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "Main Menu")) {
			click2.Play();
			Application.LoadLevel("title");
		}
		GUI.color = new Color(1,1,1,1f); 
		
		GUI.Label(new Rect(Screen.width / 3f, Screen.height / 200f, Screen.width / 1.5f, Screen.height / 10), "This game was created by Nick Padgett, with music by Matthew Norris.");
		
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 5f, Screen.width / 1.5f, Screen.height / 10), "Audio / Music - GarageBand from Apple");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Audio / Music - Audacity");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3.3f, Screen.width / 1.5f, Screen.height / 10), "Models / Animations - Blender");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 2.8f, Screen.width / 1.5f, Screen.height / 10), "Models - Sculptris from Pixologic");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 2.45f, Screen.width / 1.5f, Screen.height / 10), "Textures - GIMP");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 2.2f, Screen.width / 1.5f, Screen.height / 10), "Engine - Unity (Free)");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 1.98f, Screen.width / 1.5f, Screen.height / 10), "Fonts - 1001fonts.com");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 1.8f, Screen.width / 1.5f, Screen.height / 10), "Bloom / Sunshafts - Unity Community member PhantomKnight");
		
		if (remembererObject.GetComponent<rememberer>().levelsLocked[40] == 1) {
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 1.6f, Screen.width / 1.5f, Screen.height / 10), "Try to collect all the memories and experience the alternate ending!");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 1.51f, Screen.width / 1.5f, Screen.height / 10), "Play the one-life mode and simulate what would really happen!");

		}

		//resources I used
		//mention GarageBand, Blender, GIMP, PhantomKnight, Audacity, Unity, free font website
		
		
		GUI.Label(new Rect(Screen.width / 1.4f, Screen.height / 1.5f, Screen.width / 4f, Screen.height / 3), "If you wish to contact me or go behind the scenes of making the game, please visit one of these places.");
		GUI.Label(new Rect(Screen.width / 1.6f, Screen.height / 1.2f, Screen.width / 2f, Screen.height / 3), "Youtube: www.youtube.com/user/IrritumGame");
		GUI.Label(new Rect(Screen.width / 1.6f, Screen.height / 1.15f, Screen.width / 2f, Screen.height / 3), "Blogger: http://irritumgame.blogspot.com");
		GUI.Label(new Rect(Screen.width / 1.6f, Screen.height / 1.1f, Screen.width / 2f, Screen.height / 3), "Contact Me: nick@irritumgame.com");
		GUI.Label(new Rect(Screen.width / 1.6f, Screen.height / 1.052f, Screen.width / 2f, Screen.height / 3), "Website: www.irritumgame.com");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
