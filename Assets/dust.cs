using UnityEngine;
using System.Collections;

public class dust : MonoBehaviour {

	// Use this for initialization
	void Start () {
	StartCoroutine(countdown());
	}
	
	IEnumerator countdown() {
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
