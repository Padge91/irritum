using UnityEngine;
using System.Collections;

public class ghostActivator : MonoBehaviour {
	
	public GameObject ghost;
	public GameObject player;
	GameObject[] players;
	AudioSource audioSource1;
	AudioSource rainAmbience;
	AudioSource thunderAmbience;
	AudioSource accentAudio;
	bool thunderTimer = true;
	bool accentTimer = true;

	// Use this for initialization
	void Start () {
		
		if ((Application.loadedLevel >= 1)  && (Application.loadedLevel <= 7)){
		audioSource1 = gameObject.AddComponent<AudioSource>();
		audioSource1.clip = Resources.Load("Audio/ambience 5") as AudioClip;
			audioSource1.loop = true;
			audioSource1.minDistance = 3000000f;
			audioSource1.volume = .55f;
		audioSource1.Play();
	
		}
		else if ((Application.loadedLevel > 7) && (Application.loadedLevel <= 14)) {
			audioSource1 = gameObject.AddComponent<AudioSource>();
			audioSource1.clip = Resources.Load("Audio/ambience izmir") as AudioClip;
		audioSource1.loop = true;
		audioSource1.minDistance = 3000000f;
		audioSource1.volume = .09f;
		audioSource1.Play();
			
		}
		else if ((Application.loadedLevel > 14) && (Application.loadedLevel <= 21)) {
			audioSource1 = gameObject.AddComponent<AudioSource>();
			audioSource1.clip = Resources.Load("Audio/ambience 4") as AudioClip;
			audioSource1.loop = true;
			audioSource1.minDistance = 3000000f;
			audioSource1.volume = .69f;
		audioSource1.Play();
			
		}
		else if ((Application.loadedLevel > 21) && (Application.loadedLevel <= 28)) {
			audioSource1 = gameObject.AddComponent<AudioSource>();
			audioSource1.clip = Resources.Load("Audio/ambience 3") as AudioClip;
			audioSource1.loop = true;
			audioSource1.minDistance = 3000000f;
			audioSource1.volume = .09f;
		audioSource1.Play();
			
		}
		else if ((Application.loadedLevel > 28) && (Application.loadedLevel <= 35)) {
			audioSource1 = gameObject.AddComponent<AudioSource>();
			audioSource1.clip = Resources.Load("Audio/ambience 2") as AudioClip;
			audioSource1.loop = true;
			audioSource1.minDistance = 3000000f;
			audioSource1.volume = .6f;
		audioSource1.Play();
			
		}
		else if ((Application.loadedLevel > 35) && (Application.loadedLevel <= 39)) {
			audioSource1 = gameObject.AddComponent<AudioSource>();
			audioSource1.clip = Resources.Load("Audio/ambience 6") as AudioClip;
			audioSource1.loop = true;
			audioSource1.minDistance = 3000000f;
			audioSource1.volume = .15f;
		audioSource1.Play();
		}
		
		
		
		
		rainAmbience = gameObject.AddComponent<AudioSource>();
		rainAmbience.clip = Resources.Load("Audio/rain ambience") as AudioClip;
		rainAmbience.loop = true;
		rainAmbience.minDistance = 3000000f;
		rainAmbience.Play();
		
		if ((Application.loadedLevel > 0) && (Application.loadedLevel <= 10)) {
		rainAmbience.volume = .01f;
		}
		else if ((Application.loadedLevel > 10) && (Application.loadedLevel <= 20)) {
		rainAmbience.volume = .02f;
		}
		else if ((Application.loadedLevel > 20) && (Application.loadedLevel <= 30)) {
		rainAmbience.volume = .03f;
		}
		else if (Application.loadedLevel > 30) {
		rainAmbience.volume = .05f;
		}
		
		
		thunderAmbience = gameObject.AddComponent<AudioSource>();
		thunderAmbience.clip = Resources.Load("Audio/thunder ambience") as AudioClip;
		thunderAmbience.loop = false;
		thunderAmbience.minDistance = 3000000f;
		
		if ((Application.loadedLevel > 0) && (Application.loadedLevel <= 10)) {
		thunderAmbience.volume = .02f;
		}
		else if ((Application.loadedLevel > 10) && (Application.loadedLevel <= 20)) {
		thunderAmbience.volume = .05f;
		}
		else if ((Application.loadedLevel > 20) && (Application.loadedLevel <= 30)) {
		thunderAmbience.volume = .1f;
		}
		else if (Application.loadedLevel > 30) {
		thunderAmbience.volume = .2f;
		}
		
		if (Application.loadedLevel == 40) {
			thunderAmbience.volume = 0f;
		}
		
		accentAudio = gameObject.AddComponent<AudioSource>();
		accentAudio.clip = Resources.Load("Audio/bells 1") as AudioClip;
		accentAudio.loop = false;
		accentAudio.minDistance = 3000000f;
		accentAudio.volume = .008f;
		
		gameObject.tag = "World";
		players = GameObject.FindGameObjectsWithTag("Player");
		
		
		for (int i = 0; i < players.Length ; i++) {
			
		if (players[i].name == "PlayerPrefab") {
			player = players[i];
			}
			
		}
		
	}
	
	
	IEnumerator accent() {
		accentTimer = false;
		yield return new WaitForSeconds(Random.Range(15, 30));
		accentAudio.Play();
		accentTimer = true;
	}
	
	IEnumerator thunderclap() {
		thunderTimer = false;
		yield return new WaitForSeconds(45);
		thunderAmbience.Play();
		thunderTimer = true;
	}
	
	public void setGhost(GameObject ghoster) {
		ghost = ghoster;
		ghost.transform.parent = GameObject.FindGameObjectWithTag("World").transform;
		deActivateGhost();
	}
	
	// Update is called once per frame
	void Update () {
		if (thunderTimer) {
			StartCoroutine(thunderclap());
		}
		
		if (accentTimer) {
			StartCoroutine(accent());
		}
	
	}
	
	public void activateGhost() {
		player.GetComponent<AudioListener>().enabled = false;
		player.SetActive(false);
		
		ghost.SetActive(true);
		ghost.GetComponent<AudioListener>().enabled = true;
	}
	
	public void deActivateGhost() {
		ghost.GetComponent<AudioListener>().enabled = false;
		ghost.SetActive(false);
		
		player.SetActive(true);
		player.GetComponent<AudioListener>().enabled = true;
		
	}
}
