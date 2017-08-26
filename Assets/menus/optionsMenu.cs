using UnityEngine;
using System.Collections;

public class optionsMenu : MonoBehaviour {
	
	// copy and paste most of this in to the game vode when the player chooses the options
	// option when they pause the game. Can reuse most of the GUI code
	bool inversedHere;
	bool vSyncOn;
    float xSensitivity = 5.0f;
	float ySensitivity = 5.0f;
	public KeyCode moveForwards;
	 public KeyCode moveLeft;
	 public KeyCode moveRight;
	 public KeyCode moveBackwards;
	 public KeyCode change1;
	 public KeyCode change2;
	 public KeyCode change3;
	 public KeyCode escape;
	 public KeyCode invert;
	 public KeyCode createGhost;
	 public KeyCode jump;
	public string rekeyString = "";
	bool ableToClick = true;
	public string qualityString;
	
	public GameObject remembererObject;
	public GUISkin skin;
	float volume = 1.0f;
	
	public bool switching;
	bool going = false;
	public GameObject menu;
	float speed;
	float speed2;
	
	public GameObject main;
	
	float screenArea;
	float fontSizeOne;
	
	public Texture colorCorrection;
	
	AudioSource click1;
	AudioSource click2;
	
	
	string whichKey = "none";
	// Use this for initialization
	
	void Awake () {
		switching = false;
		
		
	}
	
	void Start () {
		
		remembererObject = GameObject.FindGameObjectWithTag("rememberer");
		AudioListener.volume = remembererObject.GetComponent<rememberer>().volume;

		Cursor.visible = true;
		Time.timeScale = 1;
	
		remembererObject = GameObject.FindGameObjectWithTag("rememberer");
		
		
		moveForwards = remembererObject.GetComponent<rememberer>().moveForwards;
		moveLeft = remembererObject.GetComponent<rememberer>().moveLeft;
		moveRight = remembererObject.GetComponent<rememberer>().moveRight;
		moveBackwards = remembererObject.GetComponent<rememberer>().moveBackwards;
	 change1 = remembererObject.GetComponent<rememberer>().change1;
	  change2 = remembererObject.GetComponent<rememberer>().change2;
	  change3 = remembererObject.GetComponent<rememberer>().change3;
	  escape = remembererObject.GetComponent<rememberer>().escape;
	  invert = remembererObject.GetComponent<rememberer>().invert;
	 createGhost = remembererObject.GetComponent<rememberer>().createGhost;
	  jump = remembererObject.GetComponent<rememberer>().jump;
		
	inversedHere =  remembererObject.GetComponent<rememberer>().inverseY;
     xSensitivity = remembererObject.GetComponent<rememberer>().xSensitivity;
	ySensitivity = remembererObject.GetComponent<rememberer>().ySensitivity;
		volume =  remembererObject.GetComponent<rememberer>().volume;
		vSyncOn = remembererObject.GetComponent<rememberer>().vSyncOn;
		
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
	
	IEnumerator moveBack() {
		switching = true;
		going = true;
		yield return new WaitForSeconds(1.8f);
		going = false;
		main.GetComponent<master>().turnOnScript("title");
		//Application.LoadLevel("title");
		
	}
	
	
	void Update () {
		float step = speed * Time.deltaTime;
		
		if (going) {
			speed = 22;
			speed2 = .8f;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, menu.transform.rotation, speed2);
			transform.position = Vector3.MoveTowards( transform.position, menu.transform.position, step);
		}
		
		if (vSyncOn) {
			QualitySettings.vSyncCount = 1;
		}
		else  {
			QualitySettings.vSyncCount = 0;
		}
		
		
		
		AudioListener.volume = volume;
	
	}
	
	void updateRememberer() {
		
		remembererObject.GetComponent<rememberer>().volume = volume;
		remembererObject.GetComponent<rememberer>().inverseY = inversedHere;
		remembererObject.GetComponent<rememberer>().xSensitivity = xSensitivity;
		remembererObject.GetComponent<rememberer>().ySensitivity = ySensitivity;
		remembererObject.GetComponent<rememberer>().moveForwards = moveForwards;
		remembererObject.GetComponent<rememberer>().moveLeft = moveLeft;
		remembererObject.GetComponent<rememberer>().moveRight = moveRight;
		remembererObject.GetComponent<rememberer>().moveBackwards = moveBackwards;
		remembererObject.GetComponent<rememberer>().change1 = change1;
		remembererObject.GetComponent<rememberer>().change2 = change2;
		remembererObject.GetComponent<rememberer>().change3 = change3;
		remembererObject.GetComponent<rememberer>().escape = escape;
		remembererObject.GetComponent<rememberer>().invert = invert;
		remembererObject.GetComponent<rememberer>().createGhost = createGhost;
		remembererObject.GetComponent<rememberer>().jump = jump;
		remembererObject.GetComponent<rememberer>().vSyncOn = vSyncOn;
		remembererObject.GetComponent<rememberer>().qualityString = qualityString;
		remembererObject.GetComponent<rememberer>().Save();
		
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
		
		if (!switching) {
		if (!whichKey.Equals("none")) {
			GUI.Label(new Rect(Screen.width / 7, Screen.height / 6f, Screen.width / 2, Screen.height / 10), rekeyString);
		}
		
		
		
		Event e = Event.current;
		
        if (e.isKey) {
           if (whichKey == "moveForwards") {
				moveForwards = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
			else if (whichKey == "moveBackwards") {
				moveBackwards = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
			else if (whichKey == "moveLeft") {
				moveLeft = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
			else if (whichKey == "moveRight") {
				moveRight = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
			else if (whichKey == "jump") {
				jump = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
			else if (whichKey == "toggleRed") {
				change1 = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
			else if (whichKey == "toggleBlue") {
				change2 = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
			else if (whichKey == "toggleYellow") {
				change3 = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
			else if (whichKey == "Escape") {
				escape = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
			else if (whichKey == "reverseGravity") {
				invert = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
			else if (whichKey == "createGhost") {
				createGhost = e.keyCode;
				whichKey = "none";
				ableToClick = true;
				updateRememberer();
			}
		}
		
		if (e.isMouse && (e.type.Equals(EventType.MouseUp))) {
			
			KeyCode mouseButton = KeyCode.Mouse0;
			
			if (e.button == 0) {
				mouseButton = KeyCode.Mouse0;
			}
			else if (e.button == 1) {
				mouseButton = KeyCode.Mouse1;
			}
			else if (e.button == 2) {
				mouseButton = KeyCode.Mouse2;
			}
			else if (e.button == 3) {
				mouseButton = KeyCode.Mouse3;
			}
			else if (e.button == 4) {
				mouseButton = KeyCode.Mouse4;
			}
			else if (e.button == 5) {
				mouseButton = KeyCode.Mouse5;
			}
			
			
            if (whichKey == "moveForwards") {
				moveForwards = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			}
			else if (whichKey == "moveBackwards") {
				moveBackwards = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			}
			else if (whichKey == "moveLeft") {
				moveLeft = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			}
			else if (whichKey == "moveRight") {
				moveRight = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			}
			else if (whichKey == "jump") {
				jump = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			}
			else if (whichKey == "toggleRed") {
				change1 = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			}
			else if (whichKey == "toggleBlue") {
				change2 = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			}
			else if (whichKey == "toggleYellow") {
				change3 = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			}
			else if (whichKey == "Escape") {
				escape = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			}
			else if (whichKey == "reverseGravity") {
				invert = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			}
			else if (whichKey == "createGhost") {
				createGhost = mouseButton;
				whichKey = "none";
				updateRememberer();
				
			} 
			ableToClick = true;
		
		}
		
		xSensitivity = GUI.HorizontalSlider (new Rect(Screen.width / 1.63f, Screen.height / 4.4f, Screen.width / 7, Screen.height / 35), xSensitivity, 0.0f, 10.0f);
		ySensitivity = GUI.HorizontalSlider (new Rect(Screen.width / 1.63f, Screen.height / 3.8f, Screen.width / 7, Screen.height / 35), ySensitivity, 0.0f, 10.0f);
		volume = GUI.HorizontalSlider (new Rect(Screen.width / 1.63f, Screen.height / 2.29f, Screen.width / 7, Screen.height / 35), volume, 0.0f, 1f);
		
		GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 4.8f, Screen.width / 7, Screen.height / 10), xSensitivity.ToString("f1"));
		GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 4.1f, Screen.width / 7, Screen.height / 10), ySensitivity.ToString("f1"));
		GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 2.4f, Screen.width / 7, Screen.height / 10), volume.ToString("f1"));
		
		GUI.Label(new Rect(Screen.width / 2, Screen.height / 4.8f, Screen.width / 7, Screen.height / 10), "X Sensitivity");
		GUI.Label(new Rect(Screen.width / 2, Screen.height / 4.1f, Screen.width / 7, Screen.height / 10), "Y Sensitivity");
		GUI.Label(new Rect(Screen.width / 2, Screen.height / 2.4f, Screen.width / 9, Screen.height / 10), "Volume");
		
		GUI.Label(new Rect(Screen.width / 1.76f, Screen.height / 2f, Screen.width / 3, Screen.height / 10), "Quality Settings*");
			
		GUI.Label(new Rect(Screen.width / 1.4f, Screen.height / 1.8f, Screen.width / 5, Screen.height / 4), "*Change Game Resolution by using StartUp Configurator (Hold Alt/Option while starting the game to force it to appear) Please change controls from this menu.");

		
		inversedHere = GUI.Toggle(new Rect(Screen.width / 2, Screen.height / 3.3f, Screen.width / 6, Screen.height / 20), inversedHere, "Inverted Y Axis");
		vSyncOn = GUI.Toggle(new Rect(Screen.width / 1.63f, Screen.height / 1.27f, Screen.width / 9, Screen.height / 20), vSyncOn, "Vsync");
		
		GUI.Label(new Rect(Screen.width / 5, Screen.height / 5.1f, Screen.width / 7, Screen.height / 10), "Move Forwards");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4.1f, Screen.width / 7, Screen.height / 10), "Move Backwards");
		GUI.Label(new Rect(Screen.width /5f, Screen.height / 3.52f, Screen.width / 7, Screen.height / 10), "Move Left");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3.03f, Screen.width / 7, Screen.height / 10), "Move Right");
		GUI.Label(new Rect(Screen.width /5f, Screen.height / 2.7f, Screen.width / 7, Screen.height / 10), "Jump");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 2.39f, Screen.width / 7, Screen.height / 10), "Toggle Red");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 2.16f, Screen.width / 7, Screen.height / 10), "Toggle Blue");
		GUI.Label(new Rect(Screen.width / 5f, Screen.height / 1.97f, Screen.width / 7, Screen.height / 10), "Toggle Yellow");
		GUI.Label(new Rect(Screen.width / 5, Screen.height / 1.62f, Screen.width / 7, Screen.height / 10), "Escape / Pause");
		GUI.Label(new Rect(Screen.width / 5, Screen.height / 1.50f, Screen.width / 7, Screen.height / 10), "Reverse Gravity");
		GUI.Label(new Rect(Screen.width / 5, Screen.height / 1.41f, Screen.width / 7, Screen.height / 10), "Create Ghost");
		
		
		GUI.color = new Color(1,1,1,0.8f); 
		if (ableToClick) {
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 5f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().moveForwards.ToString())) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
						
			ableToClick = false;
			whichKey = "moveForwards";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
		
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 4.1f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().moveBackwards.ToString())) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			ableToClick = false;
			whichKey = "moveBackwards";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 3.475f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().moveLeft.ToString())) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			ableToClick = false;
				whichKey = "moveLeft";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 3.02f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().moveRight.ToString())) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			ableToClick = false;
			whichKey = "moveRight";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
			
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 2.67f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().jump.ToString())) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			ableToClick = false;
			whichKey = "jump";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
			
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 2.39f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().change1.ToString())) {
			if (ableToClick) {if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			ableToClick = false;
			whichKey = "toggleRed";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 2.16f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().change2.ToString())) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			ableToClick = false;
			whichKey = "toggleBlue";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 1.97f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().change3.ToString())) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			ableToClick = false;
			whichKey = "toggleYellow";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 1.61f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().escape.ToString())) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			ableToClick = false;
			whichKey = "Escape";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height /1.5f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().invert.ToString())) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			ableToClick = false;
			whichKey = "reverseGravity";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 1.41f, Screen.width / 7, Screen.height / 25), remembererObject.GetComponent<rememberer>().createGhost.ToString())) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			ableToClick = false;
			whichKey = "createGhost";
			rekeyString = "Press Key or Click to remap " + whichKey;
			}
		}
		
		
		if (GUI.Button(new Rect(Screen.width / 1.77f, Screen.height / 1.8f, Screen.width / 7, Screen.height / 15), "Best")) {
			
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
					qualityString = "Best";
			QualitySettings.SetQualityLevel(6, true);
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
			vSyncOn = true;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width / 1.77f, Screen.height / 1.583f, Screen.width / 7, Screen.height / 15), "Better")) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
					qualityString = "Better";
			QualitySettings.SetQualityLevel(3, true);
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
			vSyncOn = false;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width / 1.77f, Screen.height / 1.41f, Screen.width / 7, Screen.height / 15), "Good")) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
					qualityString = "Good";
			QualitySettings.SetQualityLevel(1, true);
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
			vSyncOn = false;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width / 1.3f, Screen.height / 1.2f, Screen.width / 6.89f, Screen.height / 10), "Defaults")) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
						
	inversedHere = false;
	vSyncOn = true;
   xSensitivity = 5.0f;
	ySensitivity = 5.0f;
	moveForwards = KeyCode.W;
	 moveLeft = KeyCode.A;
	 moveRight = KeyCode.D;
	 moveBackwards = KeyCode.S;
	 change1 = KeyCode.Mouse0;
	 change2 = KeyCode.Mouse2;
	 change3 = KeyCode.Mouse1;
	 escape = KeyCode.Escape;
	 invert = KeyCode.LeftControl;
	 createGhost = KeyCode.Q;
	 jump = KeyCode.Space;
	 volume = 1.0f;
					
			qualityString = "Best";
			vSyncOn = true;
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
		QualitySettings.SetQualityLevel(6, true);
					
					
			remembererObject.GetComponent<rememberer>().moveForwards = KeyCode.W;
		remembererObject.GetComponent<rememberer>().moveLeft = KeyCode.A;
		remembererObject.GetComponent<rememberer>().moveRight = KeyCode.D;
		remembererObject.GetComponent<rememberer>().moveBackwards = KeyCode.S;
	 remembererObject.GetComponent<rememberer>().change1 = KeyCode.Mouse0;
	  remembererObject.GetComponent<rememberer>().change2 = KeyCode.Mouse2;
	   remembererObject.GetComponent<rememberer>().change3 = KeyCode.Mouse1;
	  remembererObject.GetComponent<rememberer>().escape = KeyCode.Escape;
	  remembererObject.GetComponent<rememberer>().invert = KeyCode.LeftControl;
	  remembererObject.GetComponent<rememberer>().createGhost = KeyCode.Q;
	  remembererObject.GetComponent<rememberer>().jump = KeyCode.Space;
					
					
	remembererObject.GetComponent<rememberer>().inverseY = inversedHere;
     remembererObject.GetComponent<rememberer>().xSensitivity = xSensitivity;
	 remembererObject.GetComponent<rememberer>().ySensitivity = ySensitivity;
	 remembererObject.GetComponent<rememberer>().volume = volume;
	 remembererObject.GetComponent<rememberer>().vSyncOn = vSyncOn;
			}
			}
		
		
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "Main Menu")) {
					if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
					
			if (ableToClick) {
			updateRememberer();
			StartCoroutine(moveBack());
			}
		}
		}
		}
	}
}
