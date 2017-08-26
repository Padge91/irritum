 using UnityEngine;
using System.Collections;

public class AlternatingCube : MonoBehaviour {
	public Material red;
	public Material blue;
	public Material yellow;
	
	public Material redOff;
	public Material blueOff;
	public Material yellowOff;
	
	Color redTwo = new Color(1, .114f, .114f, 1f);
	Color redTwoOff = new Color(1, .114f, .114f, .07f);
	
	Color blueTwo = new Color(0, .498f, 1, 1);
	Color blueTwoOff = new Color(0, .498f, 1, .07f);
	
	Color yellowTwo  = new Color(.86f, .76f, .345f, 1);
	Color yellowTwoOff = new Color(.86f, .76f, .345f, .06f);
	
	string colorActive;
	int color;
	int nextColor;
	public float time = 1;
	
	AudioSource timer1;
	AudioSource timer2;
	AudioSource timer3;
	
	public BoxCollider colliderVar;
	
	
	void Start() {
		
		colliderVar = gameObject.GetComponent<Collider>() as BoxCollider;
		colliderVar.size = new Vector3(colliderVar.size.x +.1f, colliderVar.size.y, colliderVar.size.z +.1f);
		
		timer1 = gameObject.AddComponent<AudioSource>();
		timer2 = gameObject.AddComponent<AudioSource>();
		timer3 = gameObject.AddComponent<AudioSource>();
		timer1.clip = Resources.Load("Audio/alternating ticker") as AudioClip;
		timer2.clip = Resources.Load("Audio/alternating ticker") as AudioClip;
		timer3.clip = Resources.Load("Audio/alternating ticker") as AudioClip;
		
			color = Random.Range(1, 4);
			colorActive =  (GameObject.FindGameObjectWithTag("Player")).GetComponent<regularBehavior>().colorActivated;
			
			if (color == 1) {
				if (colorActive == "red") {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", redTwo);
				}
				else {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", redTwoOff);
				}
			}
			
			if (color == 2) {
				if (colorActive == "blue") {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", blueTwo);
				}
				else {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", blueTwoOff);
				}
			}
			
			if (color == 3) {
				if (colorActive == "yellow") {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", yellowTwo);
				}
				else {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", yellowTwoOff);
				}
			}
		
		StartCoroutine(changeColorMethod());
	}
	
	IEnumerator countdownNoise() {
		timer1.Play();
		yield return new WaitForSeconds(time / 3);
		timer2.Play();
		yield return new WaitForSeconds(time / 3);
		timer3.Play();
		//StartCoroutine(moveColor());
		yield return new WaitForSeconds(time / 3);
	}
	
	IEnumerator moveColor() {
		float pointInTime = 0.0f;
		float duration = time / 3;
		Color color2 = new Color(1,1,1,1);
		
		if (nextColor == 1) {
			while (pointInTime <= duration) {
				color2.a = Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").a, redTwoOff.a, pointInTime);
				color2.b =  Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").b, redTwoOff.b, pointInTime);
				color2.g =  Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").g, redTwoOff.g, pointInTime);
				color2.r =  Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").r, redTwoOff.r, pointInTime);
				gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", color2);
				yield return new WaitForSeconds(time / 12);
				pointInTime += time / 12;
			}
				
			}
		else if (nextColor == 2) {
			while (pointInTime <= duration) {
				color2.a = Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").a, blueTwoOff.a, pointInTime);
				color2.b =  Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").b, blueTwoOff.b, pointInTime);
				color2.g = Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").g, blueTwoOff.g, pointInTime);
				color2.r = Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").r, blueTwoOff.r, pointInTime);
				gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", color2);
				yield return new WaitForSeconds(duration);
				pointInTime += time / 12;
			}
			
		}
		else if (nextColor == 3) {
			while (pointInTime <= duration) {
				color2.a = Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").a, yellowTwoOff.a, pointInTime);
				color2.b =  Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").b, yellowTwoOff.b, pointInTime);
				color2.g = Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").g, yellowTwoOff.g, pointInTime);
				color2.r = Mathf.Lerp(gameObject.GetComponent<Renderer>().material.GetColor("_TintColor").r, yellowTwoOff.r, pointInTime);
				gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", color2);
				yield return new WaitForSeconds(duration);
				pointInTime += time / 12;
			}
			
		}
	}
	
	IEnumerator changeColorMethod() {
		while (true) {
			StartCoroutine(countdownNoise());
			yield return new WaitForSeconds(time);
			color = nextColor;
			
			if (color == 1) {
				nextColor = Random.Range(2, 4);
			}
			else if (color == 2) {
				
				if (Random.Range(1,3) == 1) {
					nextColor = 1;
				}
				else {
					nextColor = 3;
				}
			}
			else {
				nextColor = Random.Range(1, 3);
			}
			colorActive =  (GameObject.FindGameObjectWithTag("Player")).GetComponent<regularBehavior>().colorActivated;
			
			if (color == 1) {
				if (colorActive == "red") {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", redTwo);
				}
				else {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", redTwoOff);
				}
			}
			
			if (color == 2) {
				if (colorActive == "blue") {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", blueTwo);
				}
				else {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", blueTwoOff);
				}
			}
			
			if (color == 3) {
				if (colorActive == "yellow") {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", yellowTwo);
				}
				else {
					gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", yellowTwoOff);
				}
			}			

	}
	}
	
	
	public void Activate(){
		
		if (color == 1) {
			gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", redTwo);

		}
		else if (color == 2) {
			gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", blueTwo);

		}
		else if (color == 3) {
			gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", yellowTwo);

		}	
	}
	
	public void deActivate() {
		if (color == 1) {
			gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", redTwoOff);
		}
		else if (color == 2) {
			gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", blueTwoOff);
		}
		else if (color == 3) {
			gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", yellowTwoOff);
		}
	}

	
	// Update is called once per frame
	void Update () {
		
		
		if (color == 1) {
			gameObject.tag = "Red";
			gameObject.layer = 12;
		}
		else if (color == 2) {
			gameObject.tag = "Blue";
			gameObject.layer = 13;
		}
		else if (color == 3) {
			gameObject.tag = "Yellow";
			gameObject.layer = 14;
		}
	
	}
}
