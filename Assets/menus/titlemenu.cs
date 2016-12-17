using UnityEngine;
using System.Collections;

public class titlemenu : MonoBehaviour {
	
	public Texture titleTexture;
	public Material titleMaterial;
	public GameObject rememberer;
	public GUISkin skin;
	public bool switching = false;
	public GameObject optionsMenu;
	public GameObject levelMenu;
	public GameObject memoriesMenu;
	public float speed = 5;
	public float speed2;
	bool lMenu = false;
	bool oMenu = false;
	bool mMenu = false;
	float alphaFadeInValue = 1;
	public Texture whiteTexture;
	public Texture colorCorrection;
	
	float screenArea;
	float fontSizeOne;
	
	public GameObject main;
	
	AudioSource click1;
	AudioSource click2;
	// Use this for initialization
	void Start () {
		switching = false;
		Screen.showCursor = true;
		Time.timeScale = 1;
		

		
	if (GameObject.FindGameObjectWithTag("rememberer") == null) {
		Instantiate (rememberer, transform.position, transform.rotation);
		}
		
		rememberer = GameObject.FindGameObjectWithTag("rememberer");
		AudioListener.volume = rememberer.GetComponent<rememberer>().volume;
		
	if (rememberer.GetComponent<rememberer>().loadedFromLevel) {
			StartCoroutine(wait("level menu"));
			rememberer.GetComponent<rememberer>().loadedFromLevel = false;
		}
		
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
		
		if (mMenu) {
			speed = 35;
			speed2 = .25f;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, memoriesMenu.transform.rotation, speed2);
			transform.position = Vector3.MoveTowards( transform.position, memoriesMenu.transform.position, step);
		}
		else if (oMenu) {
			speed = 22;
			speed2 = .8f;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, optionsMenu.transform.rotation, speed2);
			transform.position = Vector3.MoveTowards( transform.position,optionsMenu.transform.position, step);
		}
		else if (lMenu) {
			speed = 45;
			speed2 = 1.7f;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, levelMenu.transform.rotation, speed2);
			transform.position = Vector3.MoveTowards( transform.position, levelMenu.transform.position, step);
		}
	}
	
	IEnumerator wait(string menu) {
		switching = true;
		
		switch (menu) {
		case "level menu":
			lMenu = true;
			yield return new WaitForSeconds(1.8f);
			main.GetComponent<master>().turnOnScript("level");
			lMenu = false;
			break;
		case "memories menu":
			mMenu = true;
			yield return new WaitForSeconds(1.8f);
			main.GetComponent<master>().turnOnScript("memories");
			mMenu = false;
			break;
		case "options scene":
			oMenu = true;
			yield return new WaitForSeconds(1.8f);
			main.GetComponent<master>().turnOnScript("options");
			oMenu = false;
			break;
		case "credits":
			Application.LoadLevel("credits");
			break;
		}
			//main.GetComponent<master>().turnOnScript("title");
			//Application.LoadLevel(menu);
			
		
	}
	
	void Awake () {
		Screen.showCursor = true;
		switching = false;
		
				//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);

	}
	
	void OnGUI(){
		
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
		Graphics.DrawTexture(new Rect(Screen.width / 40, Screen.height / 3000, Screen.width / 2.1f, Screen.height / 3), titleTexture, titleMaterial);
		
		GUI.color = new Color(1,1,1,0.8f); 
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 4.5f, Screen.width / 7, Screen.height / 10), "Select Level")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			StartCoroutine(wait("level menu"));
		}
		
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 3f, Screen.width / 7, Screen.height / 10), "Memories")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			StartCoroutine(wait("memories menu"));
		}
		
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 2.25f, Screen.width / 7, Screen.height / 10), "Options")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			StartCoroutine(wait("options scene"));
		}
		
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 1.8f, Screen.width / 7, Screen.height / 10), "Credits")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			StartCoroutine(wait("credits"));
		}
		
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "Quit")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
			Application.Quit();
		}
		}
		
		if ((alphaFadeInValue <= 1) || (alphaFadeInValue >= 0)) {
	
			alphaFadeInValue -= Mathf.Clamp01(Time.deltaTime / 4);
 
		GUI.color = new Color(0, 0, 0, alphaFadeInValue);
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
			
		}
		
		
	}
}
