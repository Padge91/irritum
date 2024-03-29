using UnityEngine;
using System.Collections;

public class Green : MonoBehaviour {

	public Material offMaterial;
	public Material onMaterial;
	public BoxCollider colliderVar;
	
	// Use this for initialization
	void Start () {
		colliderVar = gameObject.GetComponent<Collider>() as BoxCollider;
		colliderVar.size = new Vector3(colliderVar.size.x +.1f, colliderVar.size.y, colliderVar.size.z +.1f);
		gameObject.GetComponent<Renderer>().material = offMaterial;
		gameObject.layer = 15;
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = false;
		}
		gameObject.tag = "Green";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator Raddle() {
		Vector3 newer = transform.position;
		
		int which = Random.Range(1,3);
		
		if (which == 1) {
		newer.x += .05f;
		transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		}
		else if (which == 2) {
			newer.x += .05f;
		transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
	
			
		}
		else {
			newer.x += .05f;
		transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.x += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.y += .05f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		newer.z -= .1f;
			transform.position = newer;
			yield return new WaitForSeconds(.005f);
		}
		}
	
	public void Activate() {

		
		
			GetComponent<Renderer>().material = onMaterial;
		
		
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = true;
		}
	}
	
	public void deActivate() {
			GetComponent<Renderer>().material = offMaterial;
		if (gameObject.GetComponent<BloomObject>() != null) {
		gameObject.GetComponent<BloomObject>().enabled = false;
		}
	}
}
