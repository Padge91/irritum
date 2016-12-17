using UnityEngine;
using System.Collections;

public class Rotating : MonoBehaviour {
	
	 public float Xspeed = 10;
	public float Yspeed = 10;
	public float Zspeed = 10;
	
	 public bool rotationX = false;
	 public bool rotationY = false;
	 public bool rotationZ = false;
	

	// Use this for initialization
	void Start () {
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = Resources.Load("Audio/moverLoop") as AudioClip;
		audio.loop = true;
		audio.volume = .3f;
		audioSource.minDistance = 5;
		audioSource.maxDistance = 10;
		audioSource.Play();
		gameObject.tag = "Rotator";
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (rotationX) 
			
		transform.Rotate(Time.deltaTime * Xspeed, 0, 0, Space.Self);
		
		else if (rotationY)
			
		transform.Rotate(0, Time.deltaTime * Yspeed, 0, Space.Self);
		
		else if (rotationZ)
			
		transform.Rotate(0, 0, Time.deltaTime * Zspeed, Space.Self);
	}
	
	public IEnumerator Raddle() {
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
}
