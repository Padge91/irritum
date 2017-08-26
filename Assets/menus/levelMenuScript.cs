using UnityEngine;
using System.Collections;

public class levelMenuScript : MonoBehaviour {
	
	int levelChosen;
	public Texture2D texture;
	string textureString;
	string memories;
	public GUISkin skin;
	public GameObject rememberer;
	public bool switching;
	bool going = false;
	public GameObject menu;
	float speed;
	float speed2;
	public GameObject main;
	bool go = false;
	public Texture whiteTexture;
	int level;
	public Texture tBorder;
	public Material mBorder;
	bool demo = false;
	
	float screenArea;
	float fontSizeOne;
	
	float alphaFadeOutValue = 0;
	
	AudioSource click1;
	AudioSource click2;
	public Texture colorCorrection;

	// Use this for initialization
	void Start () {

		switching = false;
		Cursor.visible = true;
		Time.timeScale = 1;
		
		rememberer = GameObject.FindGameObjectWithTag("rememberer");
		
		levelChosen = rememberer.GetComponent<rememberer>().lastLevel;
		
		AudioListener.volume = rememberer.GetComponent<rememberer>().volume;
	
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
		float step = speed * Time.deltaTime;
		
		memories = "Memories: " + (rememberer.GetComponent<rememberer>().memories1Array[levelChosen] + rememberer.GetComponent<rememberer>().memories2Array[levelChosen] + "/2");
		textureString = "level" + (levelChosen).ToString();
		texture = Resources.Load("menuTextures/" + textureString) as Texture2D;
		
		if (going) {
			speed = 45;
			speed2 = 1.7f;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, menu.transform.rotation, speed2);
			transform.position = Vector3.MoveTowards( transform.position, menu.transform.position, step);
		}
		
	
		if (alphaFadeOutValue >= 1) {
			Application.LoadLevel(level);
		}
	}
	
	void Awake () {
		Cursor.visible = true;
		switching = false;
	}
	
	IEnumerator moveBack() {
		switching = true;
		going = true;
		yield return new WaitForSeconds(1.8f);
		going = false;
		main.GetComponent<master>().turnOnScript("title");
		//Application.LoadLevel("title");
		
	}
	
	void OnGUI() {
		
		GUI.skin = skin;
		
		GUI.skin.button.fontSize = (int)fontSizeOne;
		GUI.skin.label.fontSize = (int)fontSizeOne;
		GUI.skin.toggle.fontSize = (int)fontSizeOne;
		
		screenArea = (Screen.width * Screen.height);
		fontSizeOne = ((screenArea * .00001107496f) + 14f);
		
		GUI.color = new Color(0,.22f,.42f,.17f);
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), colorCorrection);
		GUI.color = new Color(1,1,1,1);
		
		if (!switching) {
			if (!Application.isLoadingLevel) {
		GUI.DrawTexture(new Rect(Screen.width / 4.1f, Screen.height / 3.9f, Screen.width / 2, Screen.height / 2), texture);
		Graphics.DrawTexture(new Rect(Screen.width / 4.1f, Screen.height / 3.9f, Screen.width / 2, Screen.height / 2), tBorder, mBorder);
			}
		
		GUI.color = new Color(1,1,1,0.8f); 
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "Main Menu")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
			StartCoroutine(moveBack());
		}
			
			
		
		if (GUI.Button(new Rect(Screen.width / 30, Screen.height / 2, Screen.width / 7, Screen.height / 10), "Previous Level")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
				
			if (levelChosen != 1){
			levelChosen--;
			}
			else {
					if (!demo) {
				levelChosen = 40;
					}
					else {
						levelChosen = 10;
					}
			}
		}
		
		if (GUI.Button(new Rect(Screen.width / 1.22f, Screen.height / 2, Screen.width / 7, Screen.height / 10), "Next Level")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
					if (!demo) {
			if (levelChosen != 40){
				levelChosen++;
						}
					else {
						levelChosen = 1;
					}
				}
						else {
							if (levelChosen != 10){
								levelChosen++;
							}
					else {
						levelChosen = 1;
					}
						}
			}
		
			
		if (GUI.Button(new Rect(Screen.width / 1.22f, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "One-Life Mode")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
				
				Application.LoadLevel("one-life menu");
			}
		
		if (rememberer.GetComponent<rememberer>().levelsLocked[levelChosen] == 1) {
			if (GUI.Button(new Rect(Screen.width / 2.3f, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "Play")) {
					if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
					
				rememberer.GetComponent<rememberer>().oneLife = false;
					level = levelChosen;
				Cursor.visible = false;
				go = true;
			}
		
		GUI.color = new Color(1,1,1,1f); 
		}
	else {
			if (!Application.isLoadingLevel) {
		switch (levelChosen) {
			case 2:
			case 3:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
			 	GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 1 to play this level.");
				break;
			case 5:
			case 6:
			case 7:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 4 to play this level.");
				break;
			case 9:
			case 10:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 8 to play this level.");
				break;
			case 12:
			case 13:
			case 14:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 11 to play this level.");
				break;
			case 16:
			case 17:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 15 to play this level.");
				break;
			case 19:
			case 20:
			case 21:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 18 to play this level.");
				break;
			case 23:
			case 24:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 22 to play this level.");
				break;
			case 26:
			case 27:
			case 28:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 25 to play this level.");
				break;
			case 30:
			case 31:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 29 to play this level.");
				break;
			case 33:
			case 34:
			case 35:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 32 to play this level.");
				break;
			case 37:
			case 38:
			case 39:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 36 to play this level.");
				break;
			case 40:
				Graphics.DrawTexture(new Rect(Screen.width / 3.9f, Screen.height / 4.5f, Screen.width / 2f, Screen.height / 2f), Resources.Load("menuTextures/lockT") as Texture, Resources.Load("menuTextures/lockM") as Material);
				GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 1.3f, Screen.width / 1, Screen.height / 10), "You must complete level 39 to play this level.");
				break;
			}
				}
		}
		
		if (!Application.isLoadingLevel) {
		 GUI.Label(new Rect(Screen.width / 2.05f, Screen.height / 4.7f, Screen.width / 7, Screen.height / 10), ("Level " + (levelChosen.ToString())));
			}
		
		GUI.Label(new Rect(Screen.width / 3.8f, Screen.height / 6f, Screen.width / 2, Screen.height / 10), ("Levels 11 through 40 are locked in the demo. Please purchase the game."));

				
		if ((levelChosen != 1) && (levelChosen != 40)) {
				if (!Application.isLoadingLevel) {
			GUI.Label(new Rect(Screen.width / 1.7f, Screen.height / 4.7f, Screen.width / 3, Screen.height / 10), (memories));
				}
		}
		if (go) {
			alphaFadeOutValue += Mathf.Clamp01(Time.deltaTime / 2);

 
		GUI.color = new Color(1, 1, 1, alphaFadeOutValue);
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
		}
		}
	}
}
