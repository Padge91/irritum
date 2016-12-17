using UnityEngine;
using System.Collections;

public class shrapnelMaker : MonoBehaviour {
	bool create = false;
	public GameObject prefab;

	// Use this for initialization
	void Start () {
		StartCoroutine(wait());
	
	}
	
	IEnumerator wait() {
		create = false;
		yield return new WaitForSeconds(Random.Range(5, 15));
		create = true;
	}
	
	
	void Update () {
	
		
		if (create) {
			Instantiate(prefab, transform.position, Random.rotation);
			StartCoroutine(wait());
		}
	}
}
