using UnityEngine;
using System.Collections;

public class regularBehavior : MonoBehaviour {

	bool demo = false;

	string color;
	public string colorActivated = "white";
	GameObject[] colorArray;
	Vector3 velocity;
	bool boost = false;
	bool boost2 = false;
	bool boost3 = false;
	bool boost4 = false;
	bool boost5 = false;
	bool boost6 = false;
	
	bool abletoBoost = true;
	public bool inversed = false;
	public bool flipping = false;
	int counter = 0;
	bool abletoTeleport = true;
	bool isWhiteActive = true;
	GameObject[] whiteArray;
	public bool iAmGhost = false;
	public Transform ghost;
	public Transform ghostToUse;
	GameObject animator;
	bool Wpressed = false;
	bool Spressed = false;
	bool Apressed = false;
	bool Dpressed = false;
	public bool inAir = false; //temporary - make a script that will make this true when in air and false when on ground
	int currentRotation = 0;
	float differenceRotation = 0;
	float convertEulerToRegular = 0;
	bool grounded = false;	
	bool WA = true;
	bool WD = true;
	bool SA = true;
	bool SD = true;
	GameObject shadowObjectMover;
	Transform checkpoint;
	bool paused = false;
	bool levelFinished = false;
	bool collectable1 = false;
	public GameObject collectorExplosion;
	bool footstepsPlaying = false;
	bool alreadyPlaying = false;
	public GUISkin skin;
	public string whichKey = "none";
	public string qualityString;
	int memoryCount;
	GameObject cameraPivot;
	public GameObject targetRotate;
	int loadedLevel;
	bool ableToDie = true;
	bool controller = false;
	
	bool levelShower = true;
	bool landingAnimationPlayed = true;
	bool alreadyInversed = false;
	bool oneLife;
	public Texture whiteTexture;
	
	bool ableToChangeWhite = true;
	AudioSource activateWhite;
	
	AudioSource audioSource1;
	AudioSource audioSource2;
	AudioSource audioSource3;
	AudioSource audioSource4;
	AudioSource audioSource5;
	AudioSource audioSource6;
	AudioSource collectible;
	AudioSource gravitySwitch;
	
	AudioSource land;
	
	AudioSource story1;
	AudioSource story2;
	
	AudioSource footstep1;
	AudioSource footstep2;
	
	AudioSource ghostAudio;
	AudioSource demonVoice;
	AudioSource angelVoice;
	
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
	bool vSyncOn;
    float xSensitivity = 6.0f;
	float ySensitivity = 6.0f;
	public string rekeyString = "";
	bool ableToClick = true;
	float volume = 1.0f;
	
	public Material redIcon;
	public Texture redIconT;
	public Material blueIcon;
	public Texture blueIconT;
	public Material yellowIcon;
	public Texture yellowIconT;
	
		float alphaFadeOutValue = 0;
	float alphaFadeOutValueTwo = 0;
	float alphaFadeInValue = 1;
	float alphaFadeOutValueThree = 0;
	float alphaFadeOutValueEnd = 0;
	
	public Material LIcon;
	public Texture LIconT;
	public Material MIcon;
	public Texture MIconT;
	public Material RIcon;
	public Texture RIconT;
	
	public GameObject angel;
	public GameObject demon;
	float distanceToDemon;
	float distanceToAngel;
	
	Vector3 badLocation;
	Vector3 goodLocation;
	Vector3 midLocation;
	
	
	GameObject remembererObject;
	
	public GameObject dust;
	bool madeDustAlready = true;
	bool dying = false;
	
	bool areYouSureRestart = false;
	bool areYouSureExit = false;
	bool areYouSureSelect = false;
	bool ableToReverse = false;
	bool fadeOut = false;
	bool fadeOutWhite = false;
	bool fadeOutEnd = false;
	
	bool ableToPause = true;
	ParticleSystem system;
	float screenArea;
	float fontSizeOne;
	
	AudioSource click1;
	AudioSource click2;
	
	public Texture colorCorrection;
	
	public Texture overlayT;
	public Material overlayM;
	
	bool lowerVolumeCalled = false;
	public GameObject blocker;
	
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
	
	void checkInput() {
		
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
		AudioListener.volume = remembererObject.GetComponent<rememberer>().volume;
		
		if (remembererObject.GetComponent<rememberer>().inverseY) {
			GameObject.FindGameObjectWithTag("camerapivot").GetComponent<MouseLook>().invertedY = true;
		}
		else if (!remembererObject.GetComponent<rememberer>().inverseY) {
			GameObject.FindGameObjectWithTag("camerapivot").GetComponent<MouseLook>().invertedY = false;
		}
		
		gameObject.GetComponent<MouseLook>().sensitivityX = remembererObject.GetComponent<rememberer>().xSensitivity;
		GameObject.FindGameObjectWithTag("camerapivot").GetComponent<MouseLook>().sensitivityY = remembererObject.GetComponent<rememberer>().ySensitivity;
		
	}
	
	void playLandingAnimation() {
		animator.GetComponent<Animation>().CrossFade("LandingPlayer");
		landingAnimationPlayed = true;
	}
	
	void OnTriggerStay(Collider other) {
		if ((other.gameObject.tag == "checkpoint") && (!iAmGhost)) {
			checkpoint = other.gameObject.transform;
			other.GetComponent<ParticleSystem>().enableEmission = false;
			other.GetComponent<Collider>().enabled = false;
		}
		
	}
	
	void OnTriggerEnter(Collider other) {
		grounded = true;
		
		if (!landingAnimationPlayed) {
			playLandingAnimation();
		}
		
		if ((other.gameObject.tag == "Burn Lasers") && (!iAmGhost)) {
				StartCoroutine(die());
		}
		 else if ((other.gameObject.tag == "Boost Bubble") && (abletoBoost)) {
			other.GetComponent<Animation>().Play("Default Take");
			boost = true;
			abletoBoost = false;
		}
		else if ((other.gameObject.tag == "Portal1") && (abletoTeleport)) {
			StartCoroutine(teleporter(GameObject.FindGameObjectWithTag("Portal2").GetComponent<Rigidbody>().position));
		}
		else if ((other.gameObject.tag == "Portal2") && (abletoTeleport)) {
			StartCoroutine(teleporter(GameObject.FindGameObjectWithTag("Portal1").GetComponent<Rigidbody>().position));
		}
		else if (other.gameObject.tag == "whiteToggle") {
			if (ableToChangeWhite) {
			toggleWhite();
			}
			
		}
		
		else if ((other.gameObject.tag == "checkpoint") && (!iAmGhost)) {
			checkpoint = other.gameObject.transform;
			other.GetComponent<ParticleSystem>().enableEmission = false;
			other.GetComponent<Collider>().enabled = false;
		}
		
		else if ((other.gameObject.tag == "water") && (loadedLevel == 40)) {
			AudioListener.volume = 0;
			GameObject.FindGameObjectWithTag("renderer").gameObject.GetComponent<Renderer>().enabled = false;
			gameObject.GetComponent<ParticleSystem>().enableEmission = false;
		}
		
		else if (other.gameObject.tag == "fall catcher") {
			StartCoroutine(die());
		}
		
		else if (other.gameObject.tag == "credits") {
			fadeOutEnd = true;
		}
		
		else if ((other.gameObject.tag == "level completer") && (gameObject.name == "PlayerPrefab")) {
			finishLevel();
			
			switch (loadedLevel) {
				case 1:
					remembererObject.GetComponent<rememberer>().levelsLocked[2] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[3] = 1;
					remembererObject.GetComponent<rememberer>().Save();
					break;
				case 4:
					remembererObject.GetComponent<rememberer>().levelsLocked[5] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[6] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[7] = 1;
				remembererObject.GetComponent<rememberer>().Save();
					break;
				case 8:
					remembererObject.GetComponent<rememberer>().levelsLocked[9] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[10] = 1;
				remembererObject.GetComponent<rememberer>().Save();
					break;
				case 11:
					remembererObject.GetComponent<rememberer>().levelsLocked[12] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[13] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[14] = 1;
					remembererObject.GetComponent<rememberer>().Save();
					break;
				case 15:
					remembererObject.GetComponent<rememberer>().levelsLocked[16] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[17] = 1;
					remembererObject.GetComponent<rememberer>().Save();
					break;
			case 18:
					remembererObject.GetComponent<rememberer>().levelsLocked[19] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[20] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[21] = 1;
				remembererObject.GetComponent<rememberer>().Save();
					break;
				case 22:
					remembererObject.GetComponent<rememberer>().levelsLocked[23] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[24] = 1;
				remembererObject.GetComponent<rememberer>().Save();
					break;
				case 25:
					remembererObject.GetComponent<rememberer>().levelsLocked[26] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[27] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[28] = 1;
				remembererObject.GetComponent<rememberer>().Save();
					break;
				case 29:
					remembererObject.GetComponent<rememberer>().levelsLocked[30] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[31] = 1;
				remembererObject.GetComponent<rememberer>().Save();
					break;
				case 32:
					remembererObject.GetComponent<rememberer>().levelsLocked[33] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[34] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[35] = 1;
				remembererObject.GetComponent<rememberer>().Save();
					break;
				case 36:
					remembererObject.GetComponent<rememberer>().levelsLocked[37] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[38] = 1;
					remembererObject.GetComponent<rememberer>().levelsLocked[39] = 1;
				remembererObject.GetComponent<rememberer>().Save();
					break;
				case 39:
					remembererObject.GetComponent<rememberer>().levelsLocked[40] = 1;
				remembererObject.GetComponent<rememberer>().Save();
					break;
			}
		}
		else if ((other.gameObject.tag == "collectable") && (gameObject.name == "PlayerPrefab")){
			if (!collectable1) {
				collectable1 = true;
				remembererObject.GetComponent<rememberer>().collectable1();
				collectible.Play();
				story1.Play();
				Destroy(other.gameObject);
				Instantiate(collectorExplosion, transform.position, transform.rotation);
			}
			else if (collectable1) {
				collectible.Play();
				remembererObject.GetComponent<rememberer>().collectable2();
				story2.Play();
				Destroy(other.gameObject);
				Instantiate(collectorExplosion, transform.position, transform.rotation);
			}
		}
	}
	
	IEnumerator doCredits() {
		yield return new WaitForSeconds(5);
		Application.LoadLevel("credits");
	}
	
	IEnumerator lowerAngelVolume() {
		lowerVolumeCalled = true;
		angelVoice.volume  -= .05f;
		demonVoice.volume -= .05f;
		yield return new WaitForSeconds(.25f);
		angelVoice.volume  -= .05f;
		demonVoice.volume -= .05f;
		yield return new WaitForSeconds(.25f);
		angelVoice.volume  -= .05f;
		demonVoice.volume -= .05f;
		yield return new WaitForSeconds(.25f);
		angelVoice.volume  -= .05f;
		demonVoice.volume -= .05f;
		yield return new WaitForSeconds(.25f);
		demonVoice.Stop();
		angelVoice.Stop();
		angelVoice.volume  = .2f;
		demonVoice.volume = .2f;
		lowerVolumeCalled = false;
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
		
		GUI.color = new Color(1,1,1,.6f);
		Graphics.DrawTexture(new Rect(0,0,Screen.width, Screen.height), overlayT, overlayM);
		GUI.color = new Color(1,1,1,1);
		
		
		if (areYouSureRestart) {
			areYouSureExit = false;
			areYouSureSelect = false;
			GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 3.3f, Screen.width / 1.5f, Screen.height / 10), "Are you sure you want to reset this level?");
			if (GUI.Button(new Rect(Screen.width / 2.4f, Screen.height / 2.8f, Screen.width / 20, Screen.height / 20), "Yes")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
				
				ableToPause = false;
				unPause();
				optionsMenu = false;
				paused = false;
				Cursor.visible = false;
				Screen.lockCursor = false;
				gameObject.GetComponent<MouseLook>().enabled = true;
				cameraPivot.GetComponent<MouseLook>().enabled = true;
				areYouSureRestart = false;
				areYouSureExit = false;
				areYouSureSelect = false;
				fadeOutWhite = true;
			}
			
			if (GUI.Button(new Rect(Screen.width / 1.9f, Screen.height / 2.8f, Screen.width / 20, Screen.height / 20), "No")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
				areYouSureRestart = false;
			}
			
		}
		
		if (areYouSureExit) {
			areYouSureSelect = false;
			areYouSureRestart = false;
			GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 3.3f, Screen.width / 1.5f, Screen.height / 10), "Are you sure you want to quit this level?");
			if (GUI.Button(new Rect(Screen.width / 2.4f, Screen.height / 2.8f, Screen.width / 20, Screen.height / 20), "Yes")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
				ableToPause = false;
				unPause();
				optionsMenu = false;
				paused = false;
				Cursor.visible = false;
				Screen.lockCursor = false;
				gameObject.GetComponent<MouseLook>().enabled = true;
				cameraPivot.GetComponent<MouseLook>().enabled = true;
				areYouSureRestart = false;
				areYouSureExit = false;
				areYouSureSelect = false;
				fadeOut = true;
			}
			
			if (GUI.Button(new Rect(Screen.width / 1.9f, Screen.height / 2.8f, Screen.width / 20, Screen.height / 20), "No")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
				areYouSureExit = false;
			}
			
		}
		
		if (areYouSureSelect) {
			areYouSureExit= false;
			areYouSureRestart = false;
			GUI.Label(new Rect(Screen.width / 2.7f, Screen.height / 3.3f, Screen.width / 1.5f, Screen.height / 10), "Are you sure you want to leave this level?");
			if (GUI.Button(new Rect(Screen.width / 2.4f, Screen.height / 2.8f, Screen.width / 20, Screen.height / 20), "Yes")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
				remembererObject.GetComponent<rememberer>().loadedFromLevel = true;
				ableToPause = false;
				unPause();
				optionsMenu = false;
				paused = false;
				Cursor.visible = false;
				Screen.lockCursor = false;
				gameObject.GetComponent<MouseLook>().enabled = true;
				cameraPivot.GetComponent<MouseLook>().enabled = true;
				areYouSureRestart = false;
				areYouSureExit = false;
				areYouSureSelect = false;
				fadeOut = true;
			}
			
			if (GUI.Button(new Rect(Screen.width / 1.9f, Screen.height / 2.8f, Screen.width / 20, Screen.height / 20), "No")) {
				if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
				areYouSureSelect = false;
			}
			
		}
		
		if ((90 < distanceToAngel) && (distanceToAngel < 120) && (loadedLevel == 40)) {
			if ((!angelVoice.isPlaying)&& (gameObject.activeSelf)) {
				angelVoice.Play();
			}
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Disappointing. Cassus appears to have persuaded you to remember. You have not only doomed yourself to eternity in the void, but you have denied another of their life. Selfishness is your burden. I gave you an opportunity for forgiveness of your suicide, and you have chosen to ignore it. Your punishment is eternity in this void, with your only company being your memories.");
		}
		
			
		if (distanceToAngel < 7) {
			if ((!angelVoice.isPlaying) && (gameObject.activeSelf)) {
				angelVoice.Play();
			}
			if (!Application.isLoadingLevel) {
			switch (loadedLevel) {
			case 1:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "My name is Sollus. I am here to offer you redemption. Obey me, and life will return. Use the mouse to look around, and " + moveForwards + ", " + moveLeft + ", " + moveRight + ", " + moveBackwards + " to move. Follow the beam of light to continue to your destination.");
				break;
			case 2:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Press " + jump + " to overcome obstacles. In order to create life, you must listen to my instructions. My first instruction, do not try to remember. Memory is failure.");
				break;
			case 3:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "This is a part of the brain, your medula oblongata. It regulates your autonomic systems like your heartrate and breathing. If redemption is desired, you need to reach it. Walk into the column of light to activate it.");
				break;
			case 4:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "You must now cross the planes of existence. Use " + change1 + ", " + change2 + ", " + change3 + " to activate a plane. You exists only on one plane at a time.");
				break;
			case 5:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Falling is not necessarily failure. You must choose how to continue. This has to be something you need to finish alone. I am only here to guide you.");
				break;
			case 6:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Be wary of what Cassus tells you. He is here to see you fail. Where I pull you up, he pushes you down.");
				break;
			case 7:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "The cerebellum lies ahead. It pertains to your motor control and attention. The more parts of the brain you activate, the more difficult the others will become to reach.");
				break;
			case 8:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Persistence will lead to victory. Never give up hope. Hopelessness will damn you.");
				break;
			case 9:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Memories are enemies. You will only find pain if you remember. Do not become distracted. You need to discover your own goal, not remember an old one.");
				break;
			case 10:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Your next few choices are the most important. Decide wisely. They will affect you forever.");
				break;
			case 11:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Careful, these lasers will delay your journey. They are the partitions between your mind and your subconscious. A failsafe to keep one sane.");
				break;
			case 12:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "You can consider yourself in purgatory. Neither dead nor alive. Both of us know this is much more complicated though.");
				break;
			case 13:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Life runs in cycles. This challenge determines if the cycle continues, or ends.");
				break;
			case 14:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "The Tectum lays before you, it controls your reflexes. The body is almost finished. However the mind remains in shambles. It will be healed in time.");
				break;
			case 15:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "These blue orbs will push you upwards. Use them to reach heights you would otherwise not be able to.");
				break;
			case 16:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Choices are not always clear. One orb will punish you, and the other continues your path. There is no reason to blindly guess.");
				break;
			case 17:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "A beautiful mind is being created here. You should be proud of what you are accomplishing.");
				break;
			case 18:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Cracking planes will disintegrate after you touch them. These planes have become damaged by greed and selfishness. Take note.");
				break;
			case 19:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Impressive. You are completing an honorable duty. I respect you for that.");
				break;
			case 20:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Do not feel rushed. You have eternity, if needed, to complete this journey.");
				break;
			case 21:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Your Hippocampus is in the distance. It controls your navigation. Reactivate it to complete the body. Now we can work on fixing the mind.");
				break;
			case 22:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Some platforms randomly drift between planes. They aimlessly exist in this world. If you do not wish to join them, pay attention and move wisely.");
				break;
			case 23:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "If you begin to remember, you may become selfish once again. Selflessness is why you have succeeded so far.");
				break;
			case 24:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Use the orbs to progress further than before. Here, falling is your friend, yet still your enemy.");
				break;
			case 25:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Press " + invert + " to reverse gravity. Use this to circumvent obstacles you would normally not be able to pass. You can only do this after jumping.");
				break;
			case 26:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "The intent of the demon is to sway you from your way. Cassus is trying to finish what you started. I offer you an opportunity at redemption though. You would be foolish not to take it.");
				break;
			case 27:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "The cost of this power comes with the loss of your dimensional awareness. Keep the column of light in sight, and you will soon prevail.");
				break;
			case 28:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Now you must activate the pons. The pons controls your sleep and dreams. In order to enter reality, one must first discover what is not real.");
				break;
			case 29:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "These orbs activate and deactivate white platforms. Your previous security is no longer to be taken for granted. Existence becomes different than what you know.");
				break;
			case 30:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Only two parts of your brain remain. Death is almost lifted. Soon life will return to the world.");
				break;
			case 31:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Soon enough, your retribution will be at hand. Do not lose sight of your goal.");
				break;
			case 32:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "The green orbs will teleport you between two distances. They are empty nerve endings that use to pass electrical impulses. Now they will pass your essence.");
				break;
			case 33:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Your existence will soon become meaningful once again. The progress you have made is admirable. ");
				break;
			case 34:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Cassus is at his most influential when you are the closest to your goal. You must end jour journey and not allow his words to persuade you in any way.");
				break;
			case 35:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "The amygdala lies before you. Emotions are regulated by it. To experience life to the fullest, one must be emotionally aware.");
				break;
			case 36:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Press " + createGhost + " to create an extension of yourself. A level beneath your subconscience. It can not be damaged, but it is limited in abilities.");
				break;
			case 37:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "Not far now. Hold strong. You will be rewarded for your effort accordingly.");
				break;
			case 38:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "I have given you another chance, and you have chosen to take it. Not all have made this decision. Others have spent eternity in oblivion.");
				break;
			case 39:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "The cerebrum lies ahead. It controls your memories and your learning. When you activate it, the body and mind will be ready to enter the world. I must let you know, you will not return to the life you previously held.");
				break;
			case 40:
				GUI.Label(new Rect(Screen.width / 50, Screen.height / 10f, Screen.width / 3f, Screen.height / 1), "In your past you chose to take your own life, and now you have gifted a new life unto the world. You were not reviving yourself, but rather donating your life for anothers. Your selfishness and sins have been forgiven. You are welcome to enter the afterlife.");
				break;
				}
			}
		}
		
		if (distanceToDemon < 7) {
			if ((!demonVoice.isPlaying)&& (gameObject.activeSelf)) {
				demonVoice.Play();
			}
			if (!Application.isLoadingLevel) {
			switch (loadedLevel) {
			case 1:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Welcome to purgatory. You can call me Cassus. If you listen to me, you can return to your old life.");
				break;
			case 2:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Those shiny things up there and down below are your memories. In case you don't...  remember, they will inform you of what has been forgotten. Don't you want to know why you are here?");
				break;
			case 3:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Sollus isn't trying to save you from death. He is leading you to it. Listen to me, and you can escape limbo and return to your loved ones.");
				break;
			case 4:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "I hope this isn't too difficult for you. Maybe you should just give up now. What is life worth anyways?");
				break;
			case 5:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Sollus will betray you. Your memories will save you. You need to make a decision. Try to return to the life you left, or suffer for eternity in this place. Trust me, this is not somewhere you want to be forever.");
				break;
			case 6:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Trying to kill yourself was a mistake. We know that. But it doesn't have to end there. If you remember, you can be revived.");
				break;
			case 7:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "If you ask me to end this now, I will. Face it, this challenge is too much for you to overcome. Not everyone is created equal.");
				break;
			case 8:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "You may as well fall into The Styx below. Wash away with the sands of time. They have already forgotten you.");
				break;
			case 9:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "You may as well be dead. This is your afterlife. If I were you, I would just get used to it.");
				break;
			case 10:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Who are you? Or rather, who were you? You will only know if you remember. It's a natural reaction to want to know.");
				break;
			case 11:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "What do you think will happen at the end of this journey? Remembering is what you need to do if you want to understand why you are here.");
				break;
			case 12:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "This is your hell. Your only chance of escape is to remember.");
				break;
			case 13:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Interesting... you are fighting because you think you can live. Makes you wonder why you are here in the first place.");
				break;
			case 14:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "These platforms are passing you by. Much like your worthless life did. Waiting here will not get you what you want.");
				break;
			case 15:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Sollus doesn't want you to remember. Why is that? There is nothing wrong in knowing your past. It's in your nature.");
				break;
			case 16:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "You are hopeless. You have no idea what you are fighting for. You have no idea who to trust.");
				break;
			case 17:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Do you hear those? Your memories? They echo through your mind as you ignore them.");
				break;
			case 18:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "I have news for you. While you sit here trying to decide whether to remember or not, your loved ones sit up there trying to decide whether to kill you or not.");
				break;
			case 19:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "The longer you try, the weaker you become. Obstacles do not make you stronger in this place. They all take their toll.");
				break;
			case 20:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "This world you know crumbles away as you progress. It is falling apart as you think you become more whole. How can you be whole without memories?");
				break;
			case 21:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "This looks quite complicated. There is no shame in giving up. That is why you're here right? Because you gave up.");
				break;
			case 22:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "What is Sollus trying to do to you? These platforms are unreliable and dangerous. I thought he was your friend. It seems he is leading you to failure.");
				break;
			case 23:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Why resist your instinct? It's natural to want to know, to want to remember. You are doing yourself a disservice.");
				break;
			case 24:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Sollus, you, and I are all more alike than you know. One in the same being.");
				break;
			case 25:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Now you have two directions to avoid. How is Sollus helping you exactly? Trust me. Remember why you are here. I hope you come to a realization before it is too late.");
				break;
			case 26:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Which direction is native? Will you confuse up and down, right and wrong? I have already. Such simple questions with no obvious answers.");
				break;
			case 27:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "What are you doing down here? Where are you trying to go? The column of light shouldn't be your answer. What has it done for you so far?");
				break;
			case 28:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Why would your dreams make you come back to life? How do you know you're not dreaming now? If you can't tell the difference when you're asleep, how could you tell the difference here?");
				break;
			case 29:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "The one notion of home you use to carry is now abandoned. A stranger to the ways you use to know. The familiarity of this void is all gone now.");
				break;
			case 30:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "You are too far down now. Your trust has wrought your own self destruction. Interesting that you resort to self destruction both in your lifetime and beyond it.");
				break;
			case 31:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "No doubt, your journey will soon end. Whether it ends the way you want, that is another issue.");
				break;
			case 32:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Repercussions of your decisions will soon be made known. You may have counted yourself lucky before.");
				break;
			case 33:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "You are slipping towards something. Retribution? Suffering? You have no idea what the future holds. You shouldn't be surprised though, you know where you are heading.");
				break;
			case 34:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Your memories aid you. Why leave them behind when they are so easy to reach? Why not return to the world with any memory of your life?");
				break;
			case 35:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Back and forth, back and forth. Sollus is leading you to your end. If he knew where the end was, why would he not bring you there himself?");
				break;
			case 36:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Is it wise to divide your soul even further? What will remain is not something you wish to create. You are becoming weaker and weaker.");
				break;
			case 37:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "One memory will aid you in ways you can not even imagine. What is life worth living if you don't know who anyone is, what anything is, or for that matter, who you are?");
				break;
			case 38:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Curious. You decided to try and end your own life, yet you spend all this time and effort to try and save it.");
				break;
			case 39:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Sollus has betrayed you. Death is what you welcome. Being divised is the reality of this place.");
				break;
			case 40:
				GUI.Label(new Rect(Screen.width / 1.38f, Screen.height / 10f, Screen.width / 4, Screen.height / 1), "Your selfishness brought you to kill yourself in life, and now it haunts you in the afterlife. I am glad you have chosen to remember, for it has lead you to forfeit redemption. Death is your future, nothingness is what approaches. The afterlife is reserved for only worthy souls.");
				break;
			}
			}
			
		}
		
		
		if ((loadedLevel > 3) && (loadedLevel != 40)) {
		
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
		
		
		if ((levelShower) && (!iAmGhost)) {
			if (!Application.isLoadingLevel) {
			GUI.Label(new Rect( Screen.width / 2.1f, Screen.height / 6, Screen.width / 2, Screen.height / 2), "Level " + loadedLevel);
			}
		}
		
		if (paused && !optionsMenu) {
			GUI.color = new Color(1,1,1,0.8f);
			
			if (!oneLife) {
			if (GUI.Button(new Rect(Screen.width / 7, Screen.height / 1.5f, Screen.width / 7, Screen.height / 10), "Main Menu")){
					if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
					areYouSureExit = true;
			}
			
			if (GUI.Button(new Rect(Screen.width / 7, Screen.height / 1.8f, Screen.width / 7, Screen.height / 10), "Options")){
					if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
				optionsMenu = true;
					areYouSureExit = false;
					areYouSureSelect = false;
					areYouSureRestart = false;
			}
			
			if (GUI.Button(new Rect(Screen.width / 7, Screen.height / 2.25f, Screen.width / 7, Screen.height / 10), "Change Level")){
					if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
					areYouSureSelect = true;
			}
			
			if (GUI.Button(new Rect(Screen.width / 7, Screen.height / 3, Screen.width / 7, Screen.height / 10), "Restart Level")){
					if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
					areYouSureRestart = true;
			}
			
			if (GUI.Button (new Rect(Screen.width / 7, Screen.height / 4.5f, Screen.width / 7, Screen.height / 10), "Resume")){
					if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
				unPause();
				paused = false;
				Cursor.visible = false;
				gameObject.GetComponent<MouseLook>().enabled = true;
				GameObject.FindGameObjectWithTag("camerapivot").GetComponent<MouseLook>().enabled = true;
			}
			}
			else if (oneLife) {
				if (GUI.Button(new Rect(Screen.width / 7, Screen.height / 2.25f, Screen.width / 7, Screen.height / 10), "Quit")){
					if (!click2.isPlaying || !click1.isPlaying) {
					areYouSureExit = true;
				}
				Application.LoadLevel("title");
			}
				
				if (GUI.Button(new Rect(Screen.width / 7, Screen.height / 3f, Screen.width / 7, Screen.height / 10), "Options")){
					if (!click2.isPlaying || !click1.isPlaying) {
					click1.Play();
				}
				optionsMenu = true;
			}
				if (GUI.Button (new Rect(Screen.width / 7, Screen.height / 4.5f, Screen.width / 7, Screen.height / 10), "Resume")){
					if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
				unPause();
				paused = false;
				Cursor.visible = false;
				gameObject.GetComponent<MouseLook>().enabled = true;
				GameObject.FindGameObjectWithTag("camerapivot").GetComponent<MouseLook>().enabled = true;
			}
				
			}
			GUI.color = new Color(1,1,1,1f); 
			
		}
		
		if (optionsMenu) {
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
		
		GUI.Label(new Rect(Screen.width / 1.76f, Screen.height / 2f, Screen.width / 3, Screen.height / 10), "Quality Settings");
			
		GUI.Label(new Rect(Screen.width / 1.4f, Screen.height / 1.8f, Screen.width / 5, Screen.height / 4), "*Change Game Resolution by using StartUp Configurator (Hold Alt/Option while starting the game to force it to appear) Please change controls from this menu");
		
		inversedHere = GUI.Toggle(new Rect(Screen.width / 2, Screen.height / 3.3f, Screen.width / 6, Screen.height / 20), inversedHere, "Inverted Y Axis");		vSyncOn = GUI.Toggle(new Rect(Screen.width / 1.63f, Screen.height / 1.27f, Screen.width / 9, Screen.height / 20), vSyncOn, "Vsync");
		
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
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
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
   xSensitivity = 6.0f;
	ySensitivity = 6.0f;
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
			QualitySettings.SetQualityLevel(6, true);
			//Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,true);
			
					
					
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
		
		
		
		
		if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 1.2f, Screen.width / 7, Screen.height / 10), "Return")) {
			if (ableToClick) {
						if (!click2.isPlaying || !click1.isPlaying) {
					click2.Play();
				}
			updateRememberer();
			optionsMenu = false;
			}
		}
				GUI.color = new Color(1,1,1,1f); 
			}
		}
		
		if (levelFinished) {		
				
			ableToDie = false;
			alphaFadeOutValue += Mathf.Clamp01(Time.deltaTime / 3);

 
		GUI.color = new Color(1, 1, 1, alphaFadeOutValue);
			
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
			
			}
		
		if (fadeOutWhite) {
			alphaFadeOutValueThree += Mathf.Clamp01(Time.deltaTime / 3);
			
 
		GUI.color = new Color(1, 1, 1, alphaFadeOutValueThree);
			
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
			
		}
		
		if (fadeOutEnd) {
			alphaFadeOutValueEnd += Mathf.Clamp01(Time.deltaTime / 3);
			
 
		GUI.color = new Color(1, 1, 1, alphaFadeOutValueEnd);
			
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
			
		}
		
		if (fadeOut) {
			alphaFadeOutValueTwo += Mathf.Clamp01(Time.deltaTime / 5);

 
		GUI.color = new Color(0, 0, 0, alphaFadeOutValueTwo);

		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
			
		}
		
		if (alphaFadeOutValueTwo >= 1) {
			Application.LoadLevel(0);
		}
		
		if (alphaFadeOutValueThree >= 1) {
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if (alphaFadeOutValueEnd >= 1) {
			StartCoroutine(doCredits());
		}
		
		if (alphaFadeOutValue >= 1) {
			if (!demo) {
			switch (Application.loadedLevel) {
			case 3:
				Application.LoadLevel(43);
				break;
			case 7:
				Application.LoadLevel(44);
				break;
			case 14:
				Application.LoadLevel(45);
				break;
			case 21:
				Application.LoadLevel(46);
				break;
			case 28:
				Application.LoadLevel(47);
				break;
			case 35:
				Application.LoadLevel(48);
				break;
			case 39:
				Application.LoadLevel(49);
				break;
			default:
				Application.LoadLevel(loadedLevel+1);
				break;
				}
			}
			else {
				Application.LoadLevel(loadedLevel+1);
			}
		}
	
		
		if ((alphaFadeInValue <= 1) || (alphaFadeInValue >= 0)) {
	
			alphaFadeInValue -= Mathf.Clamp01(Time.deltaTime / 4);
 
		GUI.color = new Color(1, 1, 1, alphaFadeInValue);
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
			
		}
		
		if (dying) {
			GUI.color = new Color(1, 0, 0, .2f);
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
		}
		else if (!dying) {
			GUI.color = new Color(0, 0, 0, 0);
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), whiteTexture );
		}
	}
	
	
	
	IEnumerator die() {
		if (ableToDie) {
		if ((!oneLife) || (gameObject.name == "Ghost(Clone)")){
			if (gameObject.name == "PlayerPrefab") {
			gameObject.transform.position = checkpoint.position;
			}
			else if (gameObject.name == "Ghost(Clone)"){
			gameObject.transform.position = GameObject.FindGameObjectWithTag("ghostSpawnLocation").transform.position;
			}
			
			gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			dying = true;
				
			//turn off
				Instantiate(blocker, transform.position, transform.rotation);
			gameObject.GetComponent<CharacterMotor>().enabled = false;
			yield return new WaitForSeconds(1);
				gameObject.GetComponent<CharacterMotor>().enabled = true;
				dying = false;
			//turn back on
				
		}
		else if (oneLife) {
				if (gameObject.name == "Ghost(Clone)") {
				gameObject.transform.position = GameObject.FindGameObjectWithTag("ghostSpawnLocation").transform.position;

				}
				else {
			dying = true;
			yield return new WaitForSeconds(.1f);
			Application.LoadLevel("one-life menu");
				}
		}
		}
	}
	
	IEnumerator waitForWhite() {
		activateWhite.Play();
		ableToChangeWhite = false;
		
		Physics.IgnoreLayerCollision(8, 20, true);
		Physics.IgnoreLayerCollision(19, 20, true);
		
		yield return new WaitForSeconds(3);	
		
		Physics.IgnoreLayerCollision(8, 20, false);
		Physics.IgnoreLayerCollision(19, 20, false);
		
		ableToChangeWhite = true;
		
	}
	
	void toggleWhite() {
		StartCoroutine(waitForWhite());
		
		if (isWhiteActive) {
			Physics.IgnoreLayerCollision(8, 11, true);
			Physics.IgnoreLayerCollision(19, 11, true);
			isWhiteActive = false;
			
			
			whiteArray = GameObject.FindGameObjectsWithTag("White");
			
			for (int i = 0; i < whiteArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)whiteArray[i];
					coloredObject.BroadcastMessage("deActivate");
				}
			
		}
		else if (!isWhiteActive) {
			//dont ignore collisions w/ white
			Physics.IgnoreLayerCollision(8, 11, false);
			Physics.IgnoreLayerCollision(19, 11, false);
			isWhiteActive = true;
			
			
			whiteArray = GameObject.FindGameObjectsWithTag("White");
			
			for (int i = 0; i < whiteArray.Length; i++)
				{
					GameObject coloredObject = (GameObject)whiteArray[i];
					coloredObject.BroadcastMessage("Activate");
				}
			
			
		}
	}
	
	IEnumerator teleporter(Vector3 destination) {
		gameObject.transform.position = destination;
		abletoTeleport = false;
		yield return new WaitForSeconds(3);
		abletoTeleport = true;
		
	}

	//here
	IEnumerator movePlayerUp() {
		if (boost) {
			yield return new WaitForSeconds(.6f);
			boost = false;
			boost2 = true;
		}
		if (boost2) {
			yield return new WaitForSeconds(.5f);
			boost2 = false;
			boost3 = true;
		}
		if (boost3) {
			yield return new WaitForSeconds(.4f);
			boost3 = false;
			boost4 = true;
		}
		if (boost4) {
			yield return new WaitForSeconds(.3f);
			boost4 = false;
			boost5 = true;
		}
		if (boost5){
			yield return new WaitForSeconds(.2f);
			boost5 = false;
			boost6 = true;
		}
		if (boost6) {
			yield return new WaitForSeconds(.1f);	
			boost6 = false;
				}
		yield return new WaitForSeconds(2);
		abletoBoost = true;
	}
	
	void OnEnable() {
		checkInput();
		
		Wpressed = false;
		Spressed = false;
		Apressed = false;
		Dpressed = false;
		gameObject.GetComponent<CharacterMotor>().enabled = true;
		dying = false;
		
		inversedHere =  remembererObject.GetComponent<rememberer>().inverseY;
     xSensitivity = remembererObject.GetComponent<rememberer>().xSensitivity;
	ySensitivity = remembererObject.GetComponent<rememberer>().ySensitivity;
		volume =  remembererObject.GetComponent<rememberer>().volume;
		vSyncOn = remembererObject.GetComponent<rememberer>().vSyncOn;
	}
	
	void Awake() {
		
		cameraPivot = GameObject.FindGameObjectWithTag("camerapivot");
	}
	
	
	IEnumerator displayLevel() {
		levelShower = true;
		yield return new WaitForSeconds(5f);
		levelShower = false;
		
	}
	
	
	void Start () {
		
		Physics.IgnoreLayerCollision(8, 11, false);
		Physics.IgnoreLayerCollision(19, 11, false);
		Physics.IgnoreLayerCollision(8, 20, false);
		Physics.IgnoreLayerCollision(19, 20, false);
			isWhiteActive = true;
		
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
				
		
		
		
		Time.timeScale = 1;	
		remembererObject = GameObject.FindGameObjectWithTag("rememberer");
	
		
		oneLife = remembererObject.GetComponent<rememberer>().oneLife;
		loadedLevel = Application.loadedLevel;
		cameraPivot = GameObject.FindGameObjectWithTag("camerapivot");
		memoryCount = remembererObject.GetComponent<rememberer>().countMemory();
		Screen.lockCursor = true;
		
		demon = GameObject.FindGameObjectWithTag("demon");
		angel = GameObject.FindGameObjectWithTag("angel");
		
		if (!iAmGhost) {
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Bloom>().enabled = false;
		}
		
		StartCoroutine(displayLevel());
		AudioListener.volume = remembererObject.GetComponent<rememberer>().volume;
		remembererObject.GetComponent<rememberer>().lastLevel = loadedLevel;
		
		if (loadedLevel == 40) {
			
			badLocation = GameObject.FindGameObjectWithTag("badEnding").transform.position;
		goodLocation = GameObject.FindGameObjectWithTag("goodEnding").transform.position;
			midLocation = GameObject.FindGameObjectWithTag("midEnding").transform.position;
			
			if (remembererObject.GetComponent<rememberer>().countMemory() > 70) {
				gameObject.transform.position = badLocation;
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shafts>().enabled = false;
			}
			else if (remembererObject.GetComponent<rememberer>().countMemory() <= 10) {
				gameObject.transform.position = goodLocation;
			}
			else {
				gameObject.transform.position = midLocation;
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shafts>().enabled = false;
			}
		}
	
		
		inversedHere =  remembererObject.GetComponent<rememberer>().inverseY;
     xSensitivity = remembererObject.GetComponent<rememberer>().xSensitivity;
	ySensitivity = remembererObject.GetComponent<rememberer>().ySensitivity;
		volume =  remembererObject.GetComponent<rememberer>().volume;
		vSyncOn = remembererObject.GetComponent<rememberer>().vSyncOn;
		
		deActivateOtherColors("all");
		checkInput();
		
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
		
		footstep1 = gameObject.AddComponent<AudioSource>();
		footstep1.clip = Resources.Load("Audio/footsteps") as AudioClip;
		footstep1.volume = .003f;
		footstep1.loop = true;
		footstep1.playOnAwake = false;
		
		ghostAudio = gameObject.AddComponent<AudioSource>();
		ghostAudio.clip = Resources.Load("Audio/ghost effect") as AudioClip;
		ghostAudio.volume = .8f;
		ghostAudio.loop = false;
		
		gravitySwitch = gameObject.AddComponent<AudioSource>();
		gravitySwitch.clip = Resources.Load("Audio/gravityswitch") as AudioClip;
		gravitySwitch.volume = .3f;
		gravitySwitch.loop = false;
		gravitySwitch.playOnAwake = false;
		
		collectible = gameObject.AddComponent<AudioSource>();
		collectible.clip = Resources.Load("Audio/bells 3") as AudioClip;
		collectible.volume = .1f;
		collectible.loop = false;
		collectible.playOnAwake = false;
		
		activateWhite = gameObject.AddComponent<AudioSource>();
		activateWhite.clip = Resources.Load("Audio/activateWhite") as AudioClip;
		activateWhite.volume = .1f;
		activateWhite.loop = false;
		activateWhite.playOnAwake = false;
		
		land = gameObject.AddComponent<AudioSource> ();
		land.clip = Resources.Load("Audio/land") as AudioClip;
		land.volume = .1f;
		land.loop = false;
		land.playOnAwake = false;
		
		story1 = gameObject.AddComponent<AudioSource>();
		story1.clip = Resources.Load("Audio/Script/line " + loadedLevel + ".1") as AudioClip;
		story1.volume = 1f;
		story1.playOnAwake = false;
		
		story2 = gameObject.AddComponent<AudioSource>();
		story2.clip = Resources.Load("Audio/Script/line " + loadedLevel + ".2") as AudioClip;
		story2.volume = .06f; 
		story2.playOnAwake = false;
		
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
		
		 audioSource4 = gameObject.AddComponent<AudioSource>();
		audioSource4.clip = Resources.Load("Audio/switchcolor4") as AudioClip;
		audioSource4.volume = .3f;
		audioSource4.playOnAwake = false;
		
		 audioSource5 = gameObject.AddComponent<AudioSource>();
		audioSource5.clip = Resources.Load("Audio/switchcolor5") as AudioClip;
		audioSource5.volume = .3f;
		audioSource5.playOnAwake = false;
		
		 audioSource6 = gameObject.AddComponent<AudioSource>();
		audioSource6.clip = Resources.Load("Audio/switchcolor6") as AudioClip;
		audioSource6.volume = .3f;
		audioSource6.playOnAwake = false;
		
		angelVoice = gameObject.AddComponent<AudioSource>();
		angelVoice.clip = Resources.Load("Audio/angelVoice") as AudioClip;
		angelVoice.volume = .2f;
		angelVoice.playOnAwake = false;
		angelVoice.loop = false;
		
		demonVoice = gameObject.AddComponent<AudioSource>();
		demonVoice.clip = Resources.Load("Audio/demonVoice") as AudioClip;
		demonVoice.volume = .2f;
		demonVoice.playOnAwake = false;
		demonVoice.loop = false;
		
		shadowObjectMover = GameObject.FindGameObjectWithTag("Shadow");
		Cursor.visible = false;
		Screen.lockCursor = true;
		
		//if (!iAmGhost) {
		system = gameObject.GetComponent<ParticleSystem>();
			if (Application.loadedLevel < 20) {
		system.emissionRate = Application.loadedLevel * 10;
			}
			else if (Application.loadedLevel >= 20) {
			system.emissionRate = Application.loadedLevel * 15;
			}
		//}
		
		if ((loadedLevel == 40) && (memoryCount > 10) && (memoryCount < 70)) {
			StartCoroutine(loadCredits(20));
		}
		else if ((loadedLevel == 40) && (memoryCount > 70)) {
			StartCoroutine(loadCredits(65));
		}
		
		if (gameObject.name == "PlayerPrefab") {
		Instantiate(ghost, GameObject.FindGameObjectWithTag("ghostSpawnLocation").transform.position, GameObject.FindGameObjectWithTag("ghostSpawnLocation").transform.rotation);
		animator = GameObject.FindGameObjectWithTag("AnimatorPlayer");
			
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		
		for (int i = 0; i < players.Length ; i++) {
			
		if (players[i].name == "Ghost(Clone)") {
			ghostToUse = players[i].transform;
			}
			
		}
			
		}
		else {
		animator = GameObject.FindGameObjectWithTag("AnimatorGhost");
		}
		
		animator.GetComponent<Animation>()["TurnLeftPlayer"].speed = .1f;
		animator.GetComponent<Animation>()["TurnRightPlayer"].speed = .1f; 
		animator.GetComponent<Animation>()["RunningPlayer"].speed = 2f; 
		animator.GetComponent<Animation>()["JumpPlayer"].speed = 2.5f; 
		animator.GetComponent<Animation>()["FallingPlayer"].speed = 2.5f; 
		animator.GetComponent<Animation>()["LandingPlayer"].speed = 4;
		
		if (gameObject.layer == 19) {
			iAmGhost = true;
			GameObject.FindGameObjectWithTag("World").GetComponent<ghostActivator>().setGhost(gameObject);
		}
		
	}
		
	void inverse() {
		
		
		if (!grounded) {
			
		if (!inversed) {
				
				Physics.IgnoreLayerCollision(2, 8, true);
				GameObject worldObject = GameObject.FindGameObjectWithTag("World");
				worldObject.transform.Rotate(0, 0, 180);
				ghostToUse.transform.Rotate(0, 0, 180);
				gravitySwitch.Play();
				alreadyInversed = true;
				inversed = true;
				flipping = true;

			}
			
			else if (inversed) {
				
				Physics.IgnoreLayerCollision(2, 8, true);
				GameObject worldObject = GameObject.FindGameObjectWithTag("World");
				worldObject.transform.Rotate(0,0, -180);
				ghostToUse.transform.Rotate(0, 0, -180);
				gravitySwitch.Play();
				alreadyInversed = true;
				inversed = false;
				flipping = true;

			}
		
		}
	}
	
	IEnumerator invincible(float f) {
		ableToDie = false;
		yield return new WaitForSeconds(f);
		ableToDie = true;
	}
	
	IEnumerator waitScript() {
		gameObject.GetComponent<MouseLook>().enabled = false;
		yield return new WaitForSeconds(.5f);
		gameObject.GetComponent<MouseLook>().enabled = true;
		Physics.IgnoreLayerCollision(2, 8, false);
	}
	
	void activateGhost(){
		checkInput();
		ableToChangeWhite = true;
		Physics.IgnoreLayerCollision(8, 20, false);
		Physics.IgnoreLayerCollision(19, 20, false);
		levelShower = false;
		GameObject.FindGameObjectWithTag("World").GetComponent<ghostActivator>().activateGhost();
	}
	
	void deActivateGhost(){
		ableToChangeWhite = true;
		Physics.IgnoreLayerCollision(8, 20, false);
		Physics.IgnoreLayerCollision(19, 20, false);
		levelShower = false;
		GameObject.FindGameObjectWithTag("World").GetComponent<ghostActivator>().deActivateGhost();
		
	}
	

	IEnumerator loadCredits(int n) {
		yield return new WaitForSeconds(n);
		Application.LoadLevel("credits");
	}
	
	void finishLevel() {
			levelFinished = true;
	}
	
	void pause() {
		RenderSettings.fogDensity = .1f;
			RenderSettings.fogStartDistance = 0;
			RenderSettings.fogColor = Color.black;
			RenderSettings.fog = true;
			Time.timeScale = 0;
	}
	
	void unPause() {
		RenderSettings.fog = false;
			Time.timeScale = 1;
		areYouSureRestart = false;
				areYouSureExit = false;
				areYouSureSelect = false;
	}
	
	IEnumerator inverseTimer() {
		Physics.IgnoreLayerCollision(2, 8, true);
		yield return new WaitForSeconds(.5f);
		ableToReverse = true;
		Physics.IgnoreLayerCollision(2, 8, false);
	}
	
	
	void Update () {
		if (controller) {
		change1 = KeyCode.JoystickButton10;
		change2 = KeyCode.JoystickButton11;
		change3 = KeyCode.JoystickButton9;
			
		//change MouseX in MouseLook to MouseXTwo
		}
		
		distanceToAngel = Vector3.Distance (gameObject.transform.position, angel.transform.position);
		distanceToDemon = Vector3.Distance (gameObject.transform.position, demon.transform.position);
		
		if ((angelVoice.isPlaying) && (distanceToAngel > 7) && (!lowerVolumeCalled)) {
			StartCoroutine(lowerAngelVolume());
		}
		
		if ((demonVoice.isPlaying) && (distanceToDemon > 7) && (!lowerVolumeCalled)) {
			StartCoroutine(lowerAngelVolume());
		}
		
		//if (!iAmGhost) {
		ParticleSystem.Particle[] p = new ParticleSystem.Particle[GetComponent<ParticleSystem>().particleCount];
		int l = GetComponent<ParticleSystem>().GetParticles(p);
		
		
		if (inversed) {
			for (int i = 0; i < l; i++) {
					p[i].velocity = new Vector3(0, p[i].remainingLifetime / p[i].startLifetime * 125F, 0);
				}
				gameObject.GetComponent<ParticleSystem>().SetParticles(p, l);
		}
		else {
			for (int i = 0; i < l; i++) {
					p[i].velocity = new Vector3(0, p[i].remainingLifetime / p[i].startLifetime * -125F, 0);
				}
				gameObject.GetComponent<ParticleSystem>().SetParticles(p, l);
		}
		//}
		
		AudioListener.volume = volume;
		
		
		if ((footstepsPlaying) && (!alreadyPlaying)) {
			alreadyPlaying = true;
			footstep1.Play();
		}
		
		if ((animator.GetComponent<Animation>().IsPlaying("RunningPlayer")) || (animator.GetComponent<Animation>().IsPlaying("BackUpPlayer"))) {
			footstepsPlaying = true;
		}
		else {
			footstepsPlaying = false;
			alreadyPlaying = false;
			footstep1.Stop();
		}
		
		if (Input.GetKeyDown(escape)) {
			if (ableToPause) {
			cameraPivot = GameObject.FindGameObjectWithTag("camerapivot");
			if (paused) {
				unPause();
				optionsMenu = false;
				paused = false;
				Cursor.visible = false;
				Screen.lockCursor = true;
				gameObject.GetComponent<MouseLook>().enabled = true;
				cameraPivot.GetComponent<MouseLook>().enabled = true;
				areYouSureRestart = false;
				areYouSureExit = false;
				areYouSureSelect = false;
				updateRememberer();
			}
			else if (!paused) {
				pause();
				paused = true;
				Cursor.visible = true;
				Screen.lockCursor = false;
				gameObject.GetComponent<MouseLook>().enabled = false;
				cameraPivot.GetComponent<MouseLook>().enabled = false;
			}
			}
			
			
		} 
		
		RaycastHit hit;
		
		RaycastHit hit2;
		
		  if (Physics.Raycast(transform.position, Vector3.down, out hit, 30)) {
			shadowObjectMover.GetComponent<Renderer>().enabled = true;
			shadowObjectMover.transform.position = Vector3.MoveTowards(shadowObjectMover.transform.position, hit.point , 100);
			shadowObjectMover.transform.rotation = hit.transform.rotation;
		} 
		else {
			shadowObjectMover.GetComponent<Renderer>().enabled = false;
		}
		
		if (Physics.Raycast(transform.position, Vector3.down, out hit2, 1.25f)) {
			ableToReverse = false;
			grounded = true;
			alreadyInversed = false;
			if (!madeDustAlready) {
				madeDustAlready = true;
				Instantiate(dust, hit2.point, transform.rotation);
				if (!land.isPlaying) {
				land.Play();
				}
			}
			
		} 
		else {
			madeDustAlready = false;
			grounded = false;
			landingAnimationPlayed = false;
		}
		
		
		if (grounded) {
			
		if ((Input.GetAxis("Mouse X") < 0) && (animator.GetComponent<Animation>().IsPlaying("IdlePlayer"))) {
			animator.GetComponent<Animation>().CrossFade("TurnRightPlayer", .2f);
		}
		
		if ((Input.GetAxis("Mouse X") > 0) && (animator.GetComponent<Animation>().IsPlaying("IdlePlayer"))){
			animator.GetComponent<Animation>().CrossFade("TurnLeftPlayer", .2f);
		} 
			
			
		if (Wpressed) {
			animator.GetComponent<Animation>().CrossFade("RunningPlayer", .4f);
		}

		if (Spressed) {
			animator.GetComponent<Animation>().CrossFade("BackUpPlayer", .4f);
		}
		 else if (Apressed) {
			animator.GetComponent<Animation>().CrossFade("RunningPlayer", .4f);
		}
		else if (Dpressed) {
			animator.GetComponent<Animation>().CrossFade("RunningPlayer", .2f);
		}
		
		if (Apressed && Dpressed) {
				animator.GetComponent<Animation>().CrossFade("IdlePlayer", .5f);
				gameObject.GetComponent<CharacterMotor>().canControl = false;
		}
		 else if (Wpressed && Spressed) {
			animator.GetComponent<Animation>().CrossFade("IdlePlayer", .5f);
			gameObject.GetComponent<CharacterMotor>().canControl = false;
		}
			else {
				gameObject.GetComponent<CharacterMotor>().canControl = true;
			}
			
		}
	
		
		if (animator.transform.localEulerAngles.y > 180) {
		convertEulerToRegular = animator.transform.localEulerAngles.y - 360;
		differenceRotation = convertEulerToRegular - currentRotation;
		}
		else {
		differenceRotation = animator.transform.localEulerAngles.y - currentRotation;
		}
		
		if ((differenceRotation != currentRotation)) {
			animator.transform.Rotate(0, -differenceRotation * Time.deltaTime * 6, 0);
		}
		
		
		if (!Wpressed && !Dpressed && !Apressed && !Spressed) {
			currentRotation = 0;
		}
		
		/************************************/
		if (Input.GetKeyDown(moveForwards)){
			Wpressed = true;
		}
		 if (Input.GetKeyUp(moveForwards)){
			if (!Dpressed && !Apressed) {
			animator.GetComponent<Animation>().CrossFade("IdlePlayer", .5f);
			}
			Wpressed = false;
		}
			
		/************************************/
		if (Input.GetKeyDown(moveRight)){
			currentRotation += 90;
			
			Dpressed = true;
		}
		 if (Input.GetKeyUp(moveRight)){
			currentRotation -= 90;
			Dpressed = false;
			
			
			if (!Wpressed && !Apressed) {
			animator.GetComponent<Animation>().CrossFade("IdlePlayer", .5f);
			}
			
		}
		
		
		/************************************/
		if (Input.GetKeyDown(moveLeft)){
			currentRotation -= 90;
			Apressed = true;
		}
		else if (Input.GetKeyUp(moveLeft)){
			currentRotation += 90;
			
			Apressed = false;
			
			if (!Wpressed && !Dpressed) {
			animator.GetComponent<Animation>().CrossFade("IdlePlayer", .5f);
			}
			
		}
		
		/************************************/
		if (Input.GetKeyDown(moveBackwards)){
			Spressed = true;
		}
		else if (Input.GetKeyUp(moveBackwards)){
			Spressed = false;

			
			if (!Wpressed) {
			animator.GetComponent<Animation>().CrossFade("IdlePlayer", .5f);
			}
			
		}
		
		/************************************/
		
		
		if (Wpressed && Dpressed && WD) {
			WD = false;
			currentRotation -= 45;
			
		}
		else  if ((!Wpressed || !Dpressed) && !WD) {
			WD = true;
			currentRotation += 45;
			
		}
		/************************************/
		
		if (Wpressed && Apressed && WA) {
			WA = false;
			currentRotation += 45;
			
		}
		else  if ((!Wpressed || !Apressed) && !WA) {
			WA = true;
			currentRotation -= 45;
			
		}
		/************************************/
		
		
		if (Spressed && Apressed && SA) {
			SA = false;
			currentRotation += 135;

		}
		else if ((!Spressed || !Apressed) && !SA) {
			SA = true;
			currentRotation -= 135;
;
			
		}
		
		/************************************/
			
		if (Spressed && Dpressed && SD) {
			SD = false;
			currentRotation -= 135;

		}
		else if ((!Spressed || !Dpressed) && !SD) {
			SD = true;
			currentRotation += 135;

		}

		
		
		if (!animator.GetComponent<Animation>().isPlaying) {
			animator.GetComponent<Animation>().CrossFade("IdlePlayer", .2f);
		}
		
		if ((Input.GetKeyDown(jump)) && (grounded)) {
			StartCoroutine(inverseTimer());
			animator.GetComponent<Animation>().CrossFade("JumpPlayer", .2f);
			grounded = false;
			landingAnimationPlayed = false;
			
		}
		
		if ((loadedLevel > 35) && (loadedLevel != 40)) {
		if ((Input.GetKeyDown(createGhost)) && !paused) {
			if (iAmGhost) {
				deActivateGhost();
			}
			else if (!iAmGhost) {
				activateGhost();
			}
			
		}
		}
		
		if (!grounded) {
			animator.GetComponent<Animation>().CrossFade("FallingPlayer");
		}
		
		if (flipping) {
			
			if ((transform.rotation.z < 180) && (counter < 36) && (inversed)){	
				StartCoroutine(invincible(.2f));
				transform.Rotate(0, 0, 5);
				counter += 1;
				
				StartCoroutine(waitScript());
				
			}
			else if ((transform.rotation.z <= 180) && (counter > 0) && (!inversed)) {
				StartCoroutine(invincible(.2f));
				transform.Rotate(0, 0, -5);
				counter -= 1;
				
				StartCoroutine(waitScript());
				
			}
			
		}
		
		//here
		if (boost) {
			gameObject.transform.Translate(0, Mathf.Lerp(0, 45, Time.deltaTime), 0, Space.Self);
			StartCoroutine(movePlayerUp());
		}
		if (boost2){
			gameObject.transform.Translate(0, Mathf.Lerp(0, 40, Time.deltaTime), 0, Space.Self);
			StartCoroutine(movePlayerUp());
		}
		if (boost3){
			gameObject.transform.Translate(0, Mathf.Lerp(0, 35, Time.deltaTime), 0, Space.Self);
			StartCoroutine(movePlayerUp());
		}
		if (boost4){
			gameObject.transform.Translate(0, Mathf.Lerp(0, 30, Time.deltaTime), 0, Space.Self);
			StartCoroutine(movePlayerUp());
		}
		if (boost5){
			gameObject.transform.Translate(0, Mathf.Lerp(0, 25, Time.deltaTime), 0, Space.Self);
			StartCoroutine(movePlayerUp());
		}
		if (boost6){
			gameObject.transform.Translate(0, Mathf.Lerp(0, 00, Time.deltaTime), 0, Space.Self);
			StartCoroutine(movePlayerUp());
		}
		
		
		if (!levelFinished) {
		if (!iAmGhost) {
		
		if ((ableToReverse) && (Input.GetKeyDown(invert) && (!paused) &&  (!alreadyInversed) && ((loadedLevel > 24) && (loadedLevel != 40)))) {
				inverse();
		}
			
		if ((!paused && (loadedLevel > 3)) && loadedLevel != 40) {
	
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
