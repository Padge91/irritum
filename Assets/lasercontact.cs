using UnityEngine;
using System.Collections;

public class lasercontact : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.deltaTime > 1) {
			Destroy(gameObject);
		}
	}
}
