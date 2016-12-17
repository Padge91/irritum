using UnityEngine;
using System.Collections;
using System;

public class rememberer : MonoBehaviour {
	
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
	 public float xSensitivity = 5f;
	 public float ySensitivity = 5f;
	 public bool inverseY = false;
	public float volume;
	public bool vSyncOn = true;
	public string qualityString = "Best";
	public int lastLevel;
	public int[] memories1Array;
	public int[] memories2Array;

	public int[] levelsLocked;
	public bool oneLife = false;
	public bool loadedFromLevel = false;

	void Awake() {
		memories1Array = new int[41];
		memories2Array = new int[41];
		levelsLocked = new int[41];

		DontDestroyOnLoad(transform.gameObject);
		volume = PlayerPrefs.GetFloat("volume");  
		
		levelsLocked[1] = 1;
		levelsLocked[4] = 1;
		levelsLocked[8] = 1;
		levelsLocked[11] = 1;
		levelsLocked[15] = 1;
		levelsLocked[18] = 1;
		levelsLocked[22] = 1;
		levelsLocked[25] = 1;
		levelsLocked[29] = 1;
		levelsLocked[32] = 1;
		levelsLocked[36] = 1;
	}
	
	public int countMemory() {
		int count = 0;
		for (int i = 0; i < 41; i++) {
			count += memories1Array[i];
			count += memories2Array[i];
		}
		
		return count;
	}
	
	public void resetMemory() {
		for (int i = 0; i < 41; i++) {
			memories1Array[i] = 0;
			memories2Array[i] = 0;
		}
		Save();
	}
	
	public void reLock() {
		for (int i = 1; i < 41; i++) {
			levelsLocked[i] = 0;
		}
		
		levelsLocked[1] = 1;
		levelsLocked[4] = 1;
		levelsLocked[8] = 1;
		levelsLocked[11] = 1;
		levelsLocked[15] = 1;
		levelsLocked[18] = 1;
		levelsLocked[22] = 1;
		levelsLocked[25] = 1;
		levelsLocked[29] = 1;
		levelsLocked[32] = 1;
		levelsLocked[36] = 1;
		Save();
	}
	
	void OnGUI() {
	}
	
	public void collectable1() {
		memories1Array[Application.loadedLevel] = 1;
		Save();
	}
	
	public void collectable2() {
		memories2Array[Application.loadedLevel] = 1;
		Save();
	}

	// Use this for initialization
	void Start () {
		lastLevel = 1;
		Load();
		
		levelsLocked[1] = 1;
		levelsLocked[4] = 1;
		levelsLocked[8] = 1;
		levelsLocked[11] = 1;
		levelsLocked[15] = 1;
		levelsLocked[18] = 1;
		levelsLocked[22] = 1;
		levelsLocked[25] = 1;
		levelsLocked[29] = 1;
		levelsLocked[32] = 1;
		levelsLocked[36] = 1;

		
			//Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);

		
		if (qualityString.Equals("Best")) {
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
		QualitySettings.SetQualityLevel(6, true);
		QualitySettings.vSyncCount = 1;
		
		}
		else if (qualityString.Equals("Better")) {
			QualitySettings.SetQualityLevel(3, true);
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
			vSyncOn = false;
			
		}
		else if (qualityString.Equals("Good")){
			QualitySettings.SetQualityLevel(1, true);
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
			vSyncOn = false;
			
		}
		else {
		qualityString = "Best";
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
		QualitySettings.SetQualityLevel(6, true);
		QualitySettings.vSyncCount = 1;
		}
			
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Load() {
		moveForwards = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("moveForwards"));
		moveLeft = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("moveLeft"));
		moveRight = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("moveRight"));
		moveBackwards = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("moveBackwards"));
		change1 = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("change1"));
		change2 = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("change2"));
		change3 = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("change3"));
		escape = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("escape"));
		invert = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("invert"));
		createGhost = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("ghost"));
		jump = (KeyCode)Enum.Parse( typeof(KeyCode), PlayerPrefs.GetString("jump"));
		qualityString = PlayerPrefs.GetString("quality");
		xSensitivity = PlayerPrefs.GetFloat("xSensitivity");
		ySensitivity = PlayerPrefs.GetFloat("ySensitivity");
		volume = PlayerPrefs.GetFloat("volume"); 
		
		//Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);

		if (qualityString.Equals("Best")) {
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
		QualitySettings.SetQualityLevel(6, true);
		QualitySettings.vSyncCount = 1;
		
		}
		else if (qualityString.Equals("Better")) {
			QualitySettings.SetQualityLevel(3, true);
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
			vSyncOn = false;
			
		}
		else if (qualityString.Equals("Good")){
			QualitySettings.SetQualityLevel(1, true);
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
			vSyncOn = false;
			
		}
		else {
		qualityString = "Best";
		//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
		QualitySettings.SetQualityLevel(6, true);
		QualitySettings.vSyncCount = 1;
		}
		
		for (int i = 0; i < 41; i++) {
			string saved = "memoriesOne" + i.ToString();
			memories1Array[i] = PlayerPrefs.GetInt(saved);
		}
		
		for (int i = 0; i < 41; i++) {
			string saved = "memoriesTwo2" + i.ToString();
			memories2Array[i] = PlayerPrefs.GetInt(saved);
		}
		
		for (int i = 0; i < 41; i++) {
			string saved = "levelLocked" + i.ToString();
			levelsLocked[i] = PlayerPrefs.GetInt(saved);
		}
		
		if (PlayerPrefs.GetInt("inverseY") == 1) {
			inverseY = true;
		}
		else {
			inverseY = false;
		}
		
		if (PlayerPrefs.GetInt("vSyncOn") == 1) {
		vSyncOn = true;
		}
		else {
			vSyncOn = false;
		}
		
	}
	
	public void Save() {
		
		PlayerPrefs.SetString("moveForwards", moveForwards.ToString());
		PlayerPrefs.SetString("moveLeft", moveLeft.ToString());
		PlayerPrefs.SetString("moveRight", moveRight.ToString());
		PlayerPrefs.SetString("moveBackwards", moveBackwards.ToString());
		PlayerPrefs.SetString("change1", change1.ToString());
		PlayerPrefs.SetString("change2", change2.ToString());
		PlayerPrefs.SetString("change3", change3.ToString());
		PlayerPrefs.SetString("escape", escape.ToString());
		PlayerPrefs.SetString("invert", invert.ToString());
		PlayerPrefs.SetString("ghost", createGhost.ToString());
		PlayerPrefs.SetString("jump", jump.ToString());
		PlayerPrefs.SetFloat("xSensitivity", xSensitivity);
		PlayerPrefs.SetFloat("ySensitivity", ySensitivity);
		PlayerPrefs.SetFloat("volume", volume);
		PlayerPrefs.SetString("quality", qualityString);
		PlayerPrefs.SetInt("inverseY", Convert.ToInt32(inverseY));
		PlayerPrefs.SetInt("vSyncOn", Convert.ToInt32(vSyncOn));
		
		
		for (int i = 0; i < 41; i++) {
			String saved = "memoriesOne" + i.ToString();
			PlayerPrefs.SetInt(saved, memories1Array[i]);
		}
		
		for (int i = 0; i < 41; i++) {
			String saved = "memoriesTwo2" + i.ToString();
			PlayerPrefs.SetInt(saved, memories2Array[i]);
		}
		
		for (int i = 0; i < 41; i++) {
			String saved = "levelLocked" + i.ToString();
			PlayerPrefs.SetInt(saved, levelsLocked[i]);
		}
		
		PlayerPrefs.Save();
		
		
	}
	
}
