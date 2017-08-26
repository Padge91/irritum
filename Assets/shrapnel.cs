using UnityEngine;
using System.Collections;

public class shrapnel : MonoBehaviour {
	
	float gravity = 90f;
	GameObject player;
	bool inversed = false;
	// Use this for initialization
	
	void Start () {
		if (Application.loadedLevel != 0) {
		gameObject.transform.parent = GameObject.FindGameObjectWithTag("World").transform;
		}
		player = GameObject.FindGameObjectWithTag("Player");
		GetComponent<Rigidbody>().useGravity = true;
	StartCoroutine(timer());
	}
	
	IEnumerator timer() {
		if (Application.loadedLevel != 40) {
		yield return new WaitForSeconds(10);
		Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel != 0) {
		inversed = player.GetComponent<regularBehavior>().inversed;
	
		if (inversed) {
		  GetComponent<Rigidbody>().useGravity = false;
		  transform.Translate(Vector3.up * Time.deltaTime * gravity, Space.World);
		  }
		  else {
		  GetComponent<Rigidbody>().useGravity = true;
		  }
		}
		 
	}
}
