using UnityEngine;
using System.Collections;

public class GreenCracked : MonoBehaviour {

    public Material offMaterial;
	public Material onMaterial;
		public float time = 1;
	public int respawnTime = 5;
		AudioSource timer1;
	AudioSource timer2;
	AudioSource timer3;
	public BoxCollider colliderVar;
	
	// Use this for initialization
	void Start () {
		colliderVar = gameObject.GetComponent<Collider>() as BoxCollider;
		colliderVar.size = new Vector3(colliderVar.size.x +.1f, colliderVar.size.y, colliderVar.size.z +.1f);
		gameObject.GetComponent<Renderer>().material = offMaterial;
		gameObject.layer = 15;
		
		timer1 = gameObject.AddComponent<AudioSource>();
		timer2 = gameObject.AddComponent<AudioSource>();
		timer3 = gameObject.AddComponent<AudioSource>();
		timer1.clip = Resources.Load("Audio/countdown") as AudioClip;
		timer2.clip = Resources.Load("Audio/countdown") as AudioClip;
		timer3.clip = Resources.Load("Audio/countdown") as AudioClip;
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = false;
		}
		gameObject.tag = "Green";
	
	}
	
	IEnumerator countdownNoise() {
		timer1.Play();
		yield return new WaitForSeconds(time / 3);
		timer2.Play();
		yield return new WaitForSeconds(time / 3);
		timer3.Play();
		StartCoroutine(Raddle());
		yield return new WaitForSeconds(time / 3);
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			StartCoroutine(destroySelf());
			StartCoroutine(countdownNoise());
		}
	}
	
	IEnumerator destroySelf () {
		yield return new WaitForSeconds(time);
		gameObject.GetComponent<Renderer>().enabled = false;
		gameObject.GetComponent<Rigidbody>().GetComponent<Collider>().enabled = false;
		yield return new WaitForSeconds(respawnTime);
		gameObject.GetComponent<Renderer>().enabled = true;
		gameObject.GetComponent<Rigidbody>().GetComponent<Collider>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator Raddle() {
		Vector3 newer = transform.position;
		
		int which = Random.Range(1,3);
		
		if (which == 1) {
		newer.x += .05f;
		transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		}
		else if (which == 2) {
			newer.x += .05f;
		transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
	
			
		}
		else {
			newer.x += .05f;
		transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		}
		}
	
	public void Activate() {

		
		
			GetComponent<Renderer>().material = onMaterial;
		
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = true;
		}
	}
	
	public void deActivate() {
			GetComponent<Renderer>().material = offMaterial;
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = false;
		}
	}
}
