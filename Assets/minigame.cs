using UnityEngine;
using System.Collections;

public class minigame : MonoBehaviour {
	
	string color;
	public string colorActivated = "white";
	GameObject[] colorArray;
	GameObject[] whiteArray;
	bool paused = false;
	bool levelFinished = false;
	public GUISkin skin;
	
	AudioSource audioSource1;
	AudioSource audioSource2;
	AudioSource audioSource3;
	
	float screenArea;
	float fontSizeOne;
	
	bool ableToPause = true;
	
	public KeyCode moveForwards = KeyCode.W;
	public KeyCode moveLeft = KeyCode.A;
	public KeyCode moveRight = KeyCode.D;
	public KeyCode moveBackwards = KeyCode.S;
	public KeyCode change1 = KeyCode.Mouse0;
	public KeyCode change2 = KeyCode.Mouse2;
	public KeyCode change3 = KeyCode.Mouse1;
	public KeyCode escape = KeyCode.Escape;
	public KeyCode invert = KeyCode.LeftControl;
	public KeyCode createGhost = KeyCode.Q;
	public KeyCode jump = KeyCode.Space;
	bool optionsMenu = false;
	
	bool inversedHere;
	public string rekeyString = "";
	float volume = 1.0f;
	
	public Material redIcon;
	public Texture redIconT;
	public Material blueIcon;
	public Texture blueIconT;
	public Material yellowIcon;
	public Texture yellowIconT;
	
	
	public Material LIcon;
	public Texture LIconT;
	public Material MIcon;
	public Texture MIconT;
	public Material RIcon;
	public Texture RIconT;

	
	GameObject remembererObject;
	GameObject goal;
	
	float alphaFadeOutValue = 0;
	float alphaFadeInValue = 1;
	
	AudioSource click1;
	AudioSource click2;
	
	public Texture whiteTexture;
	public Texture colorCorrection;
	
	void checkInput() {
		
		remembererObject = GameObject.FindGameObjectWithTag("rememberer");
		moveLeft = remembererObject.GetComponent<rememberer>().moveLeft;
		moveRight = remembererObject.GetComponent<rememberer>().moveRight;
		change1 = remembererObject.GetComponent<rememberer>().change1;
		change2 = remembererObject.GetComponent<rememberer>().change2;
		change3 = remembererObject.GetComponent<rememberer>().change3;
		escape = remembererObject.GetComponent<rememberer>().escape;
		AudioListener.volume = remembererObject.GetComponent<rememberer>().volume;
	}
	
	void OnGUI () {
		GUI.skin = skin;
		
		GUI.skin.button.fontSize = (int)fontSizeOne;
		GUI.skin.label.fontSize = (int)fontSizeOne;
		GUI.skin.toggle.fontSize = (int)fontSizeOne;
		
		screenArea = (Screen.width * Screen.height);
		fontSizeOne = ((screenArea * .00001107496f) + 14f);
		
		GUI.color = new Color(0,.22f,.42f,.17f);
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), colorCorrection);
		GUI.color = new Color(1,1,1,1);
		
		
		if (Application.loadedLevel == 43) {
		GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 4f, Screen.height / 1), "Press " + moveLeft + " and " + moveRight + " to rotate platforms.");
			}
		
		if (Application.loadedLevel == 44) {
		GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 4f, Screen.height / 1), "Change the activated planes to rotate colored platforms.");
			}	
		
		if (Application.loadedLevel != 43) {
		Graphics.DrawTexture(new Rect(Screen.width / 2.315f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), LIconT, LIcon);	
		Graphics.DrawTexture(new Rect(Screen.width / 2.095f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), MIconT, MIcon);
		Graphics.DrawTexture(new Rect(Screen.width / 1.926f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), RIconT, RIcon);
			
			
		if (change1 == KeyCode.Mouse0) {
			Graphics.DrawTexture(new Rect(Screen.width / 2.3f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), redIconT, redIcon);	
		}
		else if (change1 == KeyCode.Mouse2) {
			Graphics.DrawTexture(new Rect(Screen.width / 2.1f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), redIconT, redIcon);
		}
		else if (change1 == KeyCode.Mouse1) {
			Graphics.DrawTexture(new Rect(Screen.width / 1.93f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), redIconT, redIcon);
		}
		
		if (change2 == KeyCode.Mouse0) {
			Graphics.DrawTexture(new Rect(Screen.width / 2.3f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), blueIconT, blueIcon);	
		}
		else if (change2 == KeyCode.Mouse2) {
			Graphics.DrawTexture(new Rect(Screen.width / 2.1f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), blueIconT, blueIcon);
		}
		else if (change2 == KeyCode.Mouse1) {
			Graphics.DrawTexture(new Rect(Screen.width / 1.93f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), blueIconT, blueIcon);
		}
		
		if (change3 == KeyCode.Mouse0) {
			Graphics.DrawTexture(new Rect(Screen.width / 2.3f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), yellowIconT, yellowIcon);	
		}
		else if (change3 == KeyCode.Mouse2) {
			Graphics.DrawTexture(new Rect(Screen.width / 2.1f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), yellowIconT, yellowIcon);
		}
		else if (change3 == KeyCode.Mouse1) {
			Graphics.DrawTexture(new Rect(Screen.width / 1.93f, Screen.height / 1.1f, Screen.width / 25, Screen.width / 25), yellowIconT, yellowIcon);
		}
		}
		
		
		if (paused && !optionsMenu) {
			GUI.color = new Color(1,1,1,0.8f);
			
			if (GUI.Button(new Rect(Screen.width / 7, Screen.height / 1.5f, Screen.width / 7, Screen.height / 10), "Main Menu")){
				if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
				Application.LoadLevel("title");
			}
			
			if (GUI.Button (new Rect(Screen.width / 7, Screen.height / 3f, Screen.width / 7, Screen.height / 10), "Resume")){
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
				unPause();
				paused = false;
				Cursor.visible = false;
			}
			
			if (GUI.Button (new Rect(Screen.width / 7, Screen.height / 2.25f, Screen.width / 7, Screen.height / 10), "Skip")){
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
				levelFinished = true;
				unPause();
				ableToPause = false;
				paused = false;
				Cursor.visible = false;
			}
				
			GUI.color = new Color(1,1,1,1f); 
			
		}
		
	if (levelFinished) {		
				
			alphaFadeOutValue += Mathf.Clamp01(Time.deltaTime / 5);

 
		GUI.color = new Color(1, 1, 1, alphaFadeOutValue);
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
			}
		
		
		if (alphaFadeOutValue >= 1) {
			switch (Application.loadedLevel) {
			case 43:
				Application.LoadLevel(4);
				break;
			case 44:
				Application.LoadLevel(8);
				break;
			case 45:
				Application.LoadLevel(15);
				break;
			case 46:
				Application.LoadLevel(22);
				break;
			case 47:
				Application.LoadLevel(29);
				break;
			case 48:
				Application.LoadLevel(36);
				break;
			case 49:
				Application.LoadLevel(40);
				break;
			}
		}
	
		
		if ((alphaFadeInValue <= 1) || (alphaFadeInValue >= 0)) {
	
			alphaFadeInValue -= Mathf.Clamp01(Time.deltaTime / 5);
 
		GUI.color = new Color(1, 1, 1, alphaFadeInValue);
			if (!Application.isLoadingLevel) {
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
			}
			
		}
	}

	
	void Start () {
		
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
		
		Physics.IgnoreLayerCollision(8, 11, false);
		Physics.IgnoreLayerCollision(19, 11, false);
		Physics.IgnoreLayerCollision(8, 20, false);
		Physics.IgnoreLayerCollision(19, 20, false);
		
				Physics.IgnoreLayerCollision(8, 12, true);
				Physics.IgnoreLayerCollision(19, 12, true);
				
				Physics.IgnoreLayerCollision(8, 13, true);
				Physics.IgnoreLayerCollision(8, 14, true);
				Physics.IgnoreLayerCollision(8, 15, true);
				Physics.IgnoreLayerCollision(8, 16, true);
				Physics.IgnoreLayerCollision(8, 17, true);
				
				Physics.IgnoreLayerCollision(19, 13, true);
				Physics.IgnoreLayerCollision(19, 14, true);
				Physics.IgnoreLayerCollision(19, 15, true);
				Physics.IgnoreLayerCollision(19, 16, true);
				Physics.IgnoreLayerCollision(19, 17, true);
				
		audioSource1 = gameObject.AddComponent<AudioSource>();
		audioSource1.clip = Resources.Load("Audio/ambience izmir") as AudioClip;
		audioSource1.loop = true;
		audioSource1.minDistance = 3000000f;
		audioSource1.volume = .08f;
		audioSource1.Play();
		
		
		Time.timeScale = 1;	
		remembererObject = GameObject.FindGameObjectWithTag("rememberer");
		goal = GameObject.FindGameObjectWithTag("goal2");
		Screen.lockCursor = true;
		
		AudioListener.volume = remembererObject.GetComponent<rememberer>().volume;
	
		
		volume =  remembererObject.GetComponent<rememberer>().volume;
		
		deActivateOtherColors("all");
		checkInput();	
		
		 audioSource1 = gameObject.AddComponent<AudioSource>();
		audioSource1.clip = Resources.Load("Audio/switchcolor1") as AudioClip;
		audioSource1.volume = .3f;
		audioSource1.playOnAwake = false;
		
		 audioSource2 = gameObject.AddComponent<AudioSource>();
		audioSource2.clip = Resources.Load("Audio/switchcolor2") as AudioClip;
		audioSource2.volume = .3f;
		audioSource2.playOnAwake = false;
		
		 audioSource3 = gameObject.AddComponent<AudioSource>();
		audioSource3.clip = Resources.Load("Audio/switchcolor3") as AudioClip;
		audioSource3.volume = .3f;
		audioSource3.playOnAwake = false;

		
	}

	
	void finishLevel() {
			levelFinished = true;
			Time.timeScale = 0;
			Cursor.visible = true;
			Screen.lockCursor = false;
	}
	
	void pause() {
		RenderSettings.fogDensity = .08f;
			RenderSettings.fogStartDistance = 0;
			RenderSettings.fogColor = Color.black;
			RenderSettings.fog = true;
			Time.timeScale = 0;
	}
	
	void unPause() {
		RenderSettings.fog = false;
			Time.timeScale = 1;
	}
	

	
	void Update () {
		
		if (goal.GetComponent<minigamegoal>().completed) {
			levelFinished = true;
		}
		
		
		AudioListener.volume = volume;
		
		if (Input.GetKeyDown(escape)) {
			if (ableToPause) {
			if (paused) {
				unPause();
				optionsMenu = false;
				paused = false;
				Cursor.visible = false;
				Screen.lockCursor = true;
			}
			else if (!paused) {
				pause();
				paused = true;
				Cursor.visible = true;
				Screen.lockCursor = false;
			}
			}
			
		} 
			
		/************************************/
		if (Input.GetKeyDown(moveRight)){
			rotateObjectRight(colorActivated);
		}
		
		
		/************************************/
		if (Input.GetKeyDown(moveLeft)){
			rotateObjectLeft(colorActivated);
		}
		
		 if (Input.GetKeyUp(moveLeft)){

		}



		
		if (!levelFinished) {
			
		if (!paused ) {
		if (Application.loadedLevel != 43) {
		if (Input.GetKeyDown(change1)) {
					if (!colorActivated.Equals("red")) {
						audioSource1.Stop();
				audioSource1.Play();
			changeColor("red");
					}
		}
		else if (Input.GetKeyDown(change2)) {
					if (!colorActivated.Equals("blue")) {
					audioSource2.Stop();
				audioSource2.Play();
			changeColor("blue");
					}
		}
		else if (Input.GetKeyDown(change3)) {
					if (!colorActivated.Equals("yellow")) {
						audioSource3.Stop();
					audioSource3.Play();
			changeColor("yellow");
					}
		}
			}
			}
	}
	}
	
	void rotateObjectRight(string s) {
		switch (s) {
			
		case "red" :
			colorArray = GameObject.FindGameObjectsWithTag("Red");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.gameObject.transform.Rotate(0, 0, -90);
				}
			break;
		case "blue" :
			colorArray = GameObject.FindGameObjectsWithTag("Blue");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.gameObject.transform.Rotate(0, 0, -90);
				}
			break;
		case "yellow" :
			colorArray = GameObject.FindGameObjectsWithTag("Yellow");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.gameObject.transform.Rotate(0, 0, -90);
				}
			break;
		}
		
		colorArray = GameObject.FindGameObjectsWithTag("White");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.gameObject.transform.Rotate(0, 0, -90);
				}
	}
	
	void rotateObjectLeft(string s) {
		switch (s) {
			
		case "red" :
			colorArray = GameObject.FindGameObjectsWithTag("Red");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.gameObject.transform.Rotate(0, 0, 90);
				}
			break;
		case "blue" :
			colorArray = GameObject.FindGameObjectsWithTag("Blue");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.gameObject.transform.Rotate(0, 0, 90);
				}
			break;
		case "yellow" :
			colorArray = GameObject.FindGameObjectsWithTag("Yellow");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.gameObject.transform.Rotate(0, 0, 90);
				}
			break;
		}
		
		colorArray = GameObject.FindGameObjectsWithTag("White");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.gameObject.transform.Rotate(0, 0, 90);
				}
		
	}
	
	void deActivateOtherColors(string keepColor) {
		if (keepColor.Equals("all")) {
			
			colorArray = GameObject.FindGameObjectsWithTag("Red");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("deActivate");
				}
			
			colorArray = GameObject.FindGameObjectsWithTag("Blue");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("deActivate");
				}
			
			colorArray = GameObject.FindGameObjectsWithTag("Yellow");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("deActivate");
				}
			
		}
		
		if (keepColor.Equals("Red")) {
			
		colorArray = GameObject.FindGameObjectsWithTag("Blue");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("deActivate");
				}
			
			colorArray = GameObject.FindGameObjectsWithTag("Yellow");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("deActivate");
				}
			
		}
		
		if (keepColor.Equals("Blue")) {
			
		colorArray = GameObject.FindGameObjectsWithTag("Red");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("deActivate");
				}
			
			colorArray = GameObject.FindGameObjectsWithTag("Yellow");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("deActivate");
				}
			
			
		}
		
		
		if (keepColor.Equals("Yellow")) {
			
		colorArray = GameObject.FindGameObjectsWithTag("Blue");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("deActivate");
				}
			
			colorArray = GameObject.FindGameObjectsWithTag("Red");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("deActivate");
				}
			
		}
		
	}
	
	void changeColor(string colorString) {
		
	
				switch (colorString) {
			
		case "red" :
			if (!colorActivated.Equals("red")) {	
				Physics.IgnoreLayerCollision(8, 12, false);
				Physics.IgnoreLayerCollision(19, 12, false);
				colorActivated = "red";
				Physics.IgnoreLayerCollision(8, 13, true);
				Physics.IgnoreLayerCollision(8, 14, true);
				Physics.IgnoreLayerCollision(8, 15, true);
				Physics.IgnoreLayerCollision(8, 16, true);
				Physics.IgnoreLayerCollision(8, 17, true);
				
				Physics.IgnoreLayerCollision(19, 13, true);
				Physics.IgnoreLayerCollision(19, 14, true);
				Physics.IgnoreLayerCollision(19, 15, true);
				Physics.IgnoreLayerCollision(19, 16, true);
				Physics.IgnoreLayerCollision(19, 17, true);
				
				
				
				
				colorArray = GameObject.FindGameObjectsWithTag("Red");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("Activate");
				}
				
				deActivateOtherColors("Red");
				
				
	
			}
			
			break;
			
		case "blue" :
			if (!colorActivated.Equals("blue")){
				Physics.IgnoreLayerCollision(8, 13, false);
				Physics.IgnoreLayerCollision(19, 13, false);
				colorActivated = "blue";
				Physics.IgnoreLayerCollision(8, 12, true);
				Physics.IgnoreLayerCollision(8, 14, true);
				Physics.IgnoreLayerCollision(8, 15, true);
				Physics.IgnoreLayerCollision(8, 16, true);
				Physics.IgnoreLayerCollision(8, 17, true);
				
				Physics.IgnoreLayerCollision(19, 12, true);
				Physics.IgnoreLayerCollision(19, 14, true);
				Physics.IgnoreLayerCollision(19, 15, true);
				Physics.IgnoreLayerCollision(19, 16, true);
				Physics.IgnoreLayerCollision(19, 17, true);
				
				
				colorArray = GameObject.FindGameObjectsWithTag("Blue");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("Activate");
				}
				
				deActivateOtherColors("Blue");
	
			}
			
				
			break;
			
		case "yellow" :
			if (!colorActivated.Equals("yellow")){
				Physics.IgnoreLayerCollision(8, 14, false);
				Physics.IgnoreLayerCollision(19, 14, false);
				colorActivated = "yellow";
				Physics.IgnoreLayerCollision(8, 13, true);
				Physics.IgnoreLayerCollision(8, 12, true);
				Physics.IgnoreLayerCollision(8, 15, true);
				Physics.IgnoreLayerCollision(8, 16, true);
				Physics.IgnoreLayerCollision(8, 17, true);
				
				Physics.IgnoreLayerCollision(19, 13, true);
				Physics.IgnoreLayerCollision(19, 12, true);
				Physics.IgnoreLayerCollision(19, 15, true);
				Physics.IgnoreLayerCollision(19, 16, true);
				Physics.IgnoreLayerCollision(19, 17, true);
				
				
				colorArray = GameObject.FindGameObjectsWithTag("Yellow");
				
				for (int i = 0; i < colorArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)colorArray[i];
					coloredObject.BroadcastMessage("Activate");
				}
				
				deActivateOtherColors("Yellow");
			}
			break;
			
			
			
		}
	}
}
