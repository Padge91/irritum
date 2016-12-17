using UnityEngine;
using System.Collections;

public class BlueCracked : MonoBehaviour {


	public Material offMaterial;
	public Material onMaterial;
		public float time = 1;
	public int respawnTime = 5;
	AudioSource timer1;
	AudioSource timer2;
	AudioSource timer3;
	public BoxCollider colliderVar;
	public GameObject shrapnel;
	bool ableToBlow = true;
	int area;
	
	bool ableToShiver = true;
	
	
		AudioSource explosion;

	
	// Use this for initialization
	void Start () {
		colliderVar = gameObject.collider as BoxCollider;
		colliderVar.size = new Vector3(colliderVar.size.x +.1f, colliderVar.size.y, colliderVar.size.z +.1f);
		gameObject.renderer.material = offMaterial;
		gameObject.layer = 13;
		gameObject.tag = "Blue";
		area = (int)((collider.bounds.size.x * collider.bounds.size.y * collider.bounds.size.z) / 1.5f);
		
		 timer1 = gameObject.AddComponent<AudioSource>();
		timer2 = gameObject.AddComponent<AudioSource>();
		timer3 = gameObject.AddComponent<AudioSource>();
		timer1.clip = Resources.Load("Audio/countdown") as AudioClip;
		timer2.clip = Resources.Load("Audio/countdown") as AudioClip;
		timer3.clip = Resources.Load("Audio/countdown") as AudioClip;
		gameObject.transform.particleSystem.enableEmission = false;
		
		explosion = gameObject.AddComponent<AudioSource>();
		explosion.clip = Resources.Load("Audio/break1") as AudioClip;
		explosion.volume = .5f;
		explosion.loop = false;
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = false;
		}
		
	StartCoroutine(wait());
		
	}
	
		void makeShrapnel() {
		for (int i = 0; i < area; i++) {
		Instantiate(shrapnel, new Vector3(transform.position.x + Random.Range(-gameObject.collider.bounds.size.x / 2, gameObject.collider.bounds.size.x / 2), transform.position.y + Random.Range(-gameObject.collider.bounds.size.y / 2, gameObject.collider.bounds.size.y / 2), transform.position.z + Random.Range(-gameObject.collider.bounds.size.z / 2, gameObject.collider.bounds.size.z / 2)), Random.rotation);
		}
	}
	
	IEnumerator wait() {
		yield return new WaitForSeconds(1);
		if (gameObject.transform.parent != null) {
			if (gameObject.transform.parent.gameObject.tag.Equals("Rotator")) {
			gameObject.transform.particleSystem.enableEmission = true;
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (ableToBlow) {
			StartCoroutine(destroySelf());
			StartCoroutine(countdownNoise());
		}
	}
	}
	
	
	
	IEnumerator countdownNoise() {
		timer1.Play();
		yield return new WaitForSeconds(time / 3);
		timer2.Play();
		yield return new WaitForSeconds(time / 3);
		timer3.Play();
		if (ableToShiver) {
			//StartCoroutine(Raddle());
		}
		yield return new WaitForSeconds(time / 3);
	}
	
	IEnumerator destroySelf () {
		ableToBlow = false;
		yield return new WaitForSeconds(time);
		makeShrapnel();
		gameObject.renderer.enabled = false;
		gameObject.rigidbody.collider.enabled = false;
		explosion.Play();
		yield return new WaitForSeconds(respawnTime);
			ableToBlow = true;
		gameObject.renderer.enabled = true;
		gameObject.rigidbody.collider.enabled = true;
		
		
	}
	
	// Update is called once per frame
	void Update() {
	}
	
IEnumerator Raddle() {
		
		if (ableToShiver) {
		Vector3 newer = transform.position;
		
		int which = Random.Range(1,3);
		
		if (which == 1) {
		newer.x += .05f;
		transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.x -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.z -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.x += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.y -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		}
		else if (which == 2) {
			newer.x += .05f;
		transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.z -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.x += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.y -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.x -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
	
			
		}
		else {
			newer.x += .05f;
		transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.x -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.x += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.y -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		newer.z -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.001f);
		}
		}
	}
	
	public void Activate() {

		
		
		renderer.material = onMaterial;
		
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = true;
		}
	}
	
	public void deActivate() {
		renderer.material = offMaterial;
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = false;
		}
	}
}