using UnityEngine;
using System.Collections;

public class OrangeToggle : MonoBehaviour {

	public Material offMaterial;
	public Material onMaterial;
	public float xAmount = 0;
	public float yAmount = 0;
	public float zAmount = 0;
	public float speed = 1;
	float distance;
	float time;
	
	bool inPosition1 = true;
	bool inPosition2 = false;
	bool moveTo = false;
	bool moveBack = false;
	bool moverCalled = false;
	
	
	// Use this for initialization
	void Start () {
		
		gameObject.GetComponent<Renderer>().material = offMaterial;
		gameObject.layer = 17;
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = false;
		}
		gameObject.tag = "Orange";
	
		
		distance = Mathf.Sqrt(Mathf.Pow(xAmount, 2) + Mathf.Pow(yAmount, 2));
		time = distance / speed;
	}
	
	// Update is called once per frame
	IEnumerator wait1() {
		if (moverCalled) {
			moverCalled = false;
			yield return new WaitForSeconds(time);
			inPosition1 = false;
			inPosition2 = true;
		}

	}
	
	IEnumerator wait2() {
		if (moverCalled) {
			moverCalled = false;
			yield return new WaitForSeconds(time);
			inPosition2 = false;
			inPosition1 = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if ((inPosition1) && (moveTo)){
			moverCalled = true;
			gameObject.transform.Translate(Mathf.Lerp(0, xAmount, Time.deltaTime * speed), Mathf.Lerp(0, yAmount, Time.deltaTime * speed), Mathf.Lerp(0, zAmount, Time.deltaTime * speed), Space.Self);
			StartCoroutine(wait1());
		}
		if ((inPosition2) && (moveBack)) {
			moverCalled = true;
			gameObject.transform.Translate(Mathf.Lerp(0, -xAmount, Time.deltaTime * speed), Mathf.Lerp(0, -yAmount, Time.deltaTime * speed), Mathf.Lerp(0, -zAmount, Time.deltaTime * speed), Space.Self);
			StartCoroutine(wait2());
		}
	
	}
	
	
	public void Activate() {
		if (inPosition1){
			moveTo = true;
			moveBack = false;
		}
		
			GetComponent<Renderer>().material = onMaterial;
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = true;
		}
	}
	
	public void deActivate() {
		if (inPosition2){
			moveTo = false;
			moveBack = true;
		}
		
			GetComponent<Renderer>().material = offMaterial;
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = false;
		}
	}
}
