using UnityEngine;
using System.Collections;

public class White : MonoBehaviour {
	
	public Material offMaterial;
	public Material onMaterial;
	public BoxCollider colliderVar;

	// Use this for initialization
	void Start () {
		colliderVar = gameObject.collider as BoxCollider;
		colliderVar.size = new Vector3(colliderVar.size.x +.1f, colliderVar.size.y, colliderVar.size.z +.1f);
		gameObject.renderer.material = onMaterial;
		gameObject.layer = 11;
		gameObject.tag = "White";
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Activate() {
		renderer.material = onMaterial;
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = true;
		}
	}
	
	public void deActivate() {
		renderer.material = offMaterial;
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = false;
		}
	}
}
