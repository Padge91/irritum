using UnityEngine;
using System.Collections;

public class parabolaContact : MonoBehaviour {
	
	public GameObject particleSpawner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionS(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Instantiate(particleSpawner, contact.point, transform.rotation);
	}
	}
}
