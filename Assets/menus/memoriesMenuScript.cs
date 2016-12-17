using UnityEngine;
using System.Collections;

public class memoriesMenuScript : MonoBehaviour {
	
	public GUISkin skin;
	public GameObject rememberer;
	bool wantToForget = false;
	public bool switching;
	bool going = false;
	public GameObject menu;
	float speed;
	float speed2;
	public GameObject main;
	int page = 1;
	string memories;
	
	float screenArea;
	float fontSizeOne;
	
	AudioSource click1;
	AudioSource click2;
	public Texture colorCorrection;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
		Time.timeScale = 1;
		
		rememberer = GameObject.FindGameObjectWithTag("rememberer");
		
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
	
	IEnumerator moveBack() {
		switching = true;
		going = true;
		yield return new WaitForSeconds(1.8f);
		going = false;
		main.GetComponent<master>().turnOnScript("title");
		//Application.LoadLevel("title");
		
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		memories = "Memories: " + (rememberer.GetComponent<rememberer>().memories1Array[page + 1] + rememberer.GetComponent<rememberer>().memories2Array[page + 1] + "/2");
		
		if (going) {
			speed = 35;
			speed2 = .25f;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, menu.transform.rotation, speed2);
			transform.position = Vector3.MoveTowards( transform.position, menu.transform.position, step);
		}
	
	}
	
	void Awake () {
		switching = false;
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
		GUI.Label(new Rect(Screen.width / 100f, Screen.height / 80f, Screen.width / 2, Screen.height / 10), "Total Memories ( " + rememberer.GetComponent<rememberer>().countMemory() + "/76)");
		
			
		switch (page) {	
			case (1) :
		if (rememberer.GetComponent<rememberer>().memories1Array[2] == 1) {
			GUI.Label(new Rect(Screen.width / 4f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "I'm going out with some friends tonight. Ill be out late so don't stay up.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[2] == 1) {
			GUI.Label(new Rect(Screen.width / 3.5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Body over here! Purple plus, plus. Poor son of a bitch. ");
		}
				break;
			case (2):
		
		if (rememberer.GetComponent<rememberer>().memories1Array[3] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Don't tell me he's nobody! I saw you with him! I saw you two together!");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[3] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Recall, victim is breathing! Get the stretcher now!");
		}
				break;
			case(3):
		if (rememberer.GetComponent<rememberer>().memories1Array[4] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Put down the gun. We can talk about this calmly together.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[4] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Victim appears to have suffered intense head trauma. Possible bullet wound.");
		}
				break;
			case(4):
		if (rememberer.GetComponent<rememberer>().memories1Array[5] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "I love you. I love you too.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[5] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Confirm control, gunshot wound to the head. Possible self inflicted.");
		}
				break;
			case(5):
		if (rememberer.GetComponent<rememberer>().memories1Array[6] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "He is just so clingy.  I don't have any free time anymore.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[6] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Get an ECG on him. We need to know how his heart's doing.");
		}
				break;
			case(6):
		if (rememberer.GetComponent<rememberer>().memories1Array[7] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "So do you want to do something this Friday? Yeah, that sounds fun.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[7] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Victim is losing too much blood. Control, it's gonna be a blue call!");
		}
				break;
			case(7):
		if (rememberer.GetComponent<rememberer>().memories1Array[8] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Nice to meet you. Where did you move here from?");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[8] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Get an ID and notify his family. I don't know if he will make it.");
		}
				break;
			case(8):
		if (rememberer.GetComponent<rememberer>().memories1Array[9] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Where were you? We had plans for our anniversary tonight.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[9] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "GCS is below 5. Victim may be in comatose state.");
		}
				break;
			case(9):
		if (rememberer.GetComponent<rememberer>().memories1Array[10] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "What is your problem? You are fucking psycho.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[10] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Breathing has stopped. Using BVM.");
		}
				break;
			case(10):
		if (rememberer.GetComponent<rememberer>().memories1Array[11] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Thanks but no thanks. You're not my kind of guy.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[11] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Heart rate stabilizing. Patient's breathing has returned to normal.");
		}
				break;
			case(11):
		if (rememberer.GetComponent<rememberer>().memories1Array[12] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "He's just a friend, I promise. You have nothing to worry about.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[12] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Hold him down! Control patient is having muscle spasms.");
		}
				break;
			case(12):
		if (rememberer.GetComponent<rememberer>().memories1Array[13] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Please, my boyfriend is such an idiot. He has no clue about us.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[13] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "He's flailing around! Take him to ED!");
		}
				break;
			case(13):
		if (rememberer.GetComponent<rememberer>().memories1Array[14] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Baby, I love you and I would never do that.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[14] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "His vitals have stabilized but he's still lost too much blood.");
		}
				break;
			case(14):
		if (rememberer.GetComponent<rememberer>().memories1Array[15] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "You stupid cunt. You stupid fucking lying cunt.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[15] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Prep for immediate surgery. We need to remove all the shrapnel we can.");
		}
				break;
			case(15):
		if (rememberer.GetComponent<rememberer>().memories1Array[16] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Don't ignore me. Please answer me. I'm sorry for hitting you.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[16] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Pupils seem to be dilating correctly. No muscle reflexors for pain or heat though.");
		}
				break;
			case(16):
		if (rememberer.GetComponent<rememberer>().memories1Array[17] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Hang in there. I'm sure theres a simple explanation. Don't get too worked up.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[17] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Get a transfusion going! Blood type O negative.");
		}
				break;
			case(17):
		if (rememberer.GetComponent<rememberer>().memories1Array[18] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "She's crazy about you man. Go for it. Trust me, she likes you.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[18] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Notify his next of kin.");
		}
				break;
			case(18):
		if (rememberer.GetComponent<rememberer>().memories1Array[19] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "You are so perfect. I'm glad we're together.");
		}
				
		if (rememberer.GetComponent<rememberer>().memories2Array[19] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Muscle spasms seem to have stopped, no need for anisthetic.");
		}
				break;
			case(19):
		if (rememberer.GetComponent<rememberer>().memories1Array[20] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "I can't stand you sometimes. Just leave me alone.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[20] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Keep his family outside, I'll meet his family shortly.");
		}
				break;
			case(20):
		if (rememberer.GetComponent<rememberer>().memories1Array[21] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Go then! If you don't feel right living in our home!");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[21] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Massive brain hemorrhaging. Patient still alive though. He's fighting hard to stay alive.");
		}
				break;
			case(21):
		if (rememberer.GetComponent<rememberer>().memories1Array[22] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "I have a new partner now. Don't be jealous, he's not that good looking.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[22] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Bullet entrance right lateral side of head in front of ear. Bullet exit on back of head.");
		}
				break;
			case(22):
		if (rememberer.GetComponent<rememberer>().memories1Array[23] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "You are worthless compared to him! I don't even know why I'm with you!");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[23] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Patient seems to now be responding to stimuli. Dope him down now!");
		}
				break;
			case(23):
		if (rememberer.GetComponent<rememberer>().memories1Array[24] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "I don't need anger management. You need to stop pushing my buttons!");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[24] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Patient also showing reaction to heat. No positional awareness.");
		}
				break;
			case(24):
		if (rememberer.GetComponent<rememberer>().memories1Array[25] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "But she's my best friend. We've been friends since we were kids.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[25] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Keep him hands down. He's trying to reach his face.");
		}
				break;
			case(25):
		if (rememberer.GetComponent<rememberer>().memories1Array[26] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "You're hardly a man. Look at you. Pathetic.");
		}
					if (rememberer.GetComponent<rememberer>().memories2Array[26] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "If you can hear me, keep your hands down! Stop moving!");
		}
				break;
			case(26):
		if (rememberer.GetComponent<rememberer>().memories1Array[27] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1, Screen.height / 4), "I have no one to go now. You were suppose to be there for me.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[27] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1, Screen.height / 4), "Move him out of OR and into critical. I will address the family.");
		}
				break;
			case(27):
		if (rememberer.GetComponent<rememberer>().memories1Array[28] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "I can't deal with this anymore. You make me want to kill myself!");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[28] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Little brain activity. I see no sign of intellectual awareness.");
		}
				break;
			case(28):
		if (rememberer.GetComponent<rememberer>().memories1Array[29] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Good! No one will miss you! You are worthless! I'd better do it myself!");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[29] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Vital signs have returned to nominal. No longer in critical condition. Move him down the hall.");
		}
				break;
			case(29):
		if (rememberer.GetComponent<rememberer>().memories1Array[30] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "You took away all my friends and now you're leaving too?");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[30] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "The family can come in and see him now. He seems to be stable.");
		}
				break;
			case(30):
		if (rememberer.GetComponent<rememberer>().memories1Array[31] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "You two are the perfect couple. You look so good together.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[31] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Your son has suffered a gunshot wound to the head. The police are conducting an investigation.");
		}
				break;
			case(31):
		if (rememberer.GetComponent<rememberer>().memories1Array[32] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1, Screen.height / 10), "I need the gun to protect our family. I will never get it out around you.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[32] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1, Screen.height / 10), "The choices now are to see how much better he can get, or pull the plug.");
		}
				break;
			case(32):
		if (rememberer.GetComponent<rememberer>().memories1Array[33] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "I think you need a counselor. Escpecially if you feel this way often.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[33] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "I suggest we continue to moniter his progress over the next several days.");
		}
				break;
			case(33):
		if (rememberer.GetComponent<rememberer>().memories1Array[34] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1, Screen.height / 10), "You are such a geek! Do something with your life!");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[34] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1, Screen.height / 10), "He may never wake from this state.");
		}
				break;
			case(34):
		if (rememberer.GetComponent<rememberer>().memories1Array[35] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "I'm leaving this gun here for you. Don't call, I won't answer.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[35] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "The MRI seems to indicate he is experiencing REM, like he is having some kind of dream.");
		}
			break;
			case(35):
		if (rememberer.GetComponent<rememberer>().memories1Array[36] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "I'm so happy I have you. I don't know what I would do without you.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[36] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Police have confirmed it. Attempted suicide.");
		}
				break;
			case(36):
		if (rememberer.GetComponent<rememberer>().memories1Array[37] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "What is his name? How long have you been seeing him?");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[37] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "I'm sorry for putting you all in this position, but it is time to decide.");
		}
				break;
			case(37):
		if (rememberer.GetComponent<rememberer>().memories1Array[38] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Hopefully someone will remember me.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[38] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "Likelihood of waking up is quickly diminishing.");
		}
				break;
			case(38):
		if (rememberer.GetComponent<rememberer>().memories1Array[39] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 3f, Screen.width / 1.5f, Screen.height / 10), "Do you still love me? Just be honest. I need an honest answer.");
		}
				if (rememberer.GetComponent<rememberer>().memories2Array[39] == 1) {
			GUI.Label(new Rect(Screen.width / 5f, Screen.height / 4f, Screen.width / 1.5f, Screen.height / 10), "So be it. Say your goodbyes.");
		}
				break;
			}
			
			GUI.Label(new Rect(Screen.width / 1.75f, Screen.height / 4.7f, Screen.width / 3, Screen.height / 10), (memories));
			GUI.Label(new Rect(Screen.width / 2.2f, Screen.height / 4.7f, Screen.width / 7, Screen.height / 10), ("Level " + (page + 1)));
		
		
		GUI.color = new Color(1,1,1,0.8f); 
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "Main Menu")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
			StartCoroutine(moveBack());
		}
			
			if (GUI.Button(new Rect(Screen.width / 30, Screen.height / 2, Screen.width / 7, Screen.height / 10), "Previous")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
			if (page != 1){
			page--;
			}
			else {
				page = 38;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width / 1.22f, Screen.height / 2, Screen.width / 7, Screen.height / 10), "Next")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
			if (page != 38){
			page++;
			}
			else {
				page = 1;
			}
		}
		
		if (GUI.Button(new Rect(Screen.width / 1.3f, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "Forget")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
				
			wantToForget = true;
		}
		GUI.color = new Color(1,1,1,1f); 
		
		
		if (wantToForget) {
			GUI.Label(new Rect(Screen.width / 3f, Screen.height / 1.25f, Screen.width / 1.5f, Screen.height / 10), "Are you sure you want to forget all of your memories?\n This will also lock ALL of the unlocked levels.");
			
			GUI.color = new Color(1,1,1,0.8f); 
			if (GUI.Button(new Rect(Screen.width / 2.4f, Screen.height / 1.1f, Screen.width / 20, Screen.height / 20), "Yes")) {
					if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
					
				wantToForget = false;
				
				rememberer.GetComponent<rememberer>().resetMemory();
				rememberer.GetComponent<rememberer>().reLock();
			}
			
			if (GUI.Button(new Rect(Screen.width / 1.9f, Screen.height / 1.1f, Screen.width / 20, Screen.height / 20), "No")) {
					if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
					
				wantToForget = false;
			}
			GUI.color = new Color(1,1,1,1f); 
			
		}
		
		}
	}
}
