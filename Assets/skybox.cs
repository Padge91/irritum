using UnityEngine;
using System.Collections;

public class skybox : MonoBehaviour {
	
	public Material lightning;
	public Material skyboxMaterial;
	bool lightningTimer = true;
	public GameObject cameraObject;
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material = skyboxMaterial;
	
	}
	
	IEnumerator lightningMethod() {
		
		cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
		
		lightningTimer = false;
		
		yield return new WaitForSeconds(44.5f);
		gameObject.GetComponent<Renderer>().material = lightning;
		cameraObject.GetComponent<Camera>().backgroundColor = new Color (0, .14f, .16f, 1);
		yield return new WaitForSeconds(.05f);
		gameObject.GetComponent<Renderer>().material = skyboxMaterial;
		cameraObject.GetComponent<Camera>().backgroundColor = new Color (0, 0, 0, 1);
		yield return new WaitForSeconds(.1f);
		gameObject.GetComponent<Renderer>().material = lightning;
		cameraObject.GetComponent<Camera>().backgroundColor = new Color (0, .14f, .16f, 1);
		yield return new WaitForSeconds(.2f);
		gameObject.GetComponent<Renderer>().material = skyboxMaterial;
		cameraObject.GetComponent<Camera>().backgroundColor = new Color (0, 0, 0, 1);
		yield return new WaitForSeconds(.05f);
		gameObject.GetComponent<Renderer>().material = lightning;
		cameraObject.GetComponent<Camera>().backgroundColor = new Color (0, .14f, .16f, 1);
		yield return new WaitForSeconds(.05f);
		gameObject.GetComponent<Renderer>().material = skyboxMaterial;
		cameraObject.GetComponent<Camera>().backgroundColor = new Color (0, 0, 0, 1);
		lightningTimer = true;
	}
	
	// Update is called once per frame
	void Update () {
	if (lightningTimer) {
			StartCoroutine(lightningMethod());
		}
	}
}
