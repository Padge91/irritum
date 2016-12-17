using UnityEngine;
using System.Collections;

public class blocker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if (Time.timeSinceLevelLoad > 3) {
			Destroy(gameObject);
		}
	}
}
