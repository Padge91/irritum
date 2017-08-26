using UnityEngine;
using System.Collections;

public class whiteCracked : MonoBehaviour {
	
	AudioSource timer1;
	AudioSource timer2;
	AudioSource timer3;
	public int time;
	public GameObject shrapnel;
	int area;

	// Use this for initialization
	void Start () {
		
		area = (int)((GetComponent<Collider>().bounds.size.x * GetComponent<Collider>().bounds.size.y * GetComponent<Collider>().bounds.size.z) / 4f);
		timer1 = gameObject.AddComponent<AudioSource>();
		timer2 = gameObject.AddComponent<AudioSource>();
		timer3 = gameObject.AddComponent<AudioSource>();
		timer1.clip = Resources.Load("Audio/countdown") as AudioClip;
		timer2.clip = Resources.Load("Audio/countdown") as AudioClip;
		timer3.clip = Resources.Load("Audio/countdown") as AudioClip;
	
	}
	
	IEnumerator countdownNoise() {
		timer1.Play();
		yield return new WaitForSeconds(time / 3);
		timer2.Play();
		yield return new WaitForSeconds(time / 3);
		timer3.Play();
		yield return new WaitForSeconds(time / 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter() {
		StartCoroutine(destroySelf());
		StartCoroutine(countdownNoise());
	}
	
	void OnCollisionEnter() {
		StartCoroutine(destroySelf());
		StartCoroutine(countdownNoise());
	}
	
	IEnumerator destroySelf () {
		yield return new WaitForSeconds(time);
		makeShrapnel();
		Destroy(gameObject);
	}
	
	void makeShrapnel() {
		for (int i = 0; i < area; i++) {
		Instantiate(shrapnel, new Vector3(transform.position.x + Random.Range(-gameObject.GetComponent<Collider>().bounds.size.x / 2, gameObject.GetComponent<Collider>().bounds.size.x / 2), transform.position.y + Random.Range(-gameObject.GetComponent<Collider>().bounds.size.y / 2, gameObject.GetComponent<Collider>().bounds.size.y / 2), transform.position.z + Random.Range(-gameObject.GetComponent<Collider>().bounds.size.z / 2, gameObject.GetComponent<Collider>().bounds.size.z / 2)), Random.rotation);
		}
	}
}
