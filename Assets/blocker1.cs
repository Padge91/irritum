using UnityEngine;
using System.Collections;

public class blocker1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	StartCoroutine(wait());
	}
	
	IEnumerator wait() {
		yield return new WaitForSeconds(1.5f);
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
