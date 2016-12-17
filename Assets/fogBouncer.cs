using UnityEngine;
using System.Collections;

public class fogBouncer : MonoBehaviour {
	public float time;
		bool starter = true;

	// Use this for initialization
	void Start () {
	RenderSettings.fogColor = Color.black;
	RenderSettings.fog = true;
		
	}
	
	IEnumerator bouncer() {
		starter = false;
		RenderSettings.fogDensity = 0;
		yield return new WaitForSeconds(time / 10);
		RenderSettings.fogDensity += .025f;
		yield return new WaitForSeconds(time / 10);
		RenderSettings.fogDensity += .025f;
		yield return new WaitForSeconds(time / 10);
		RenderSettings.fogDensity += .025f;
		yield return new WaitForSeconds(time / 10);
		RenderSettings.fogDensity += .025f;
		yield return new WaitForSeconds(time / 10);
		RenderSettings.fogDensity += .025f;
		yield return new WaitForSeconds(time / 10);
		RenderSettings.fogDensity += .025f;
		yield return new WaitForSeconds(time / 10);
		RenderSettings.fogDensity += .025f;
		yield return new WaitForSeconds(time / 10);
		RenderSettings.fogDensity += .025f;
		yield return new WaitForSeconds(time / 10);
		RenderSettings.fogDensity += .025f;
		yield return new WaitForSeconds(time / 10);
		RenderSettings.fogDensity += .025f;
		starter = true;
		
	}
	
	
	// Update is called once per frame
	void Update () {
		if (starter) {
			StartCoroutine(bouncer());
		}
		
	}
}
