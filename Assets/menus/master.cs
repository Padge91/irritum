using UnityEngine;
using System.Collections;



public class master : MonoBehaviour {
	
	public GameObject main;
	
	
	void Start () {
		
		main.GetComponent<titlemenu>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void turnOnScript(string s) {
		if (s.Equals("options")) {
			main.GetComponent<titlemenu>().enabled = false;
			main.GetComponent<optionsMenu>().switching = false;
			main.GetComponent<optionsMenu>().enabled = true;
			
		}
		else if (s.Equals("memories")) {
			main.GetComponent<titlemenu>().enabled = false;
			main.GetComponent<memoriesMenuScript>().switching = false;
			main.GetComponent<memoriesMenuScript>().enabled = true;
			
		}
		else if (s.Equals("level")) {
			main.GetComponent<titlemenu>().enabled = false;
			main.GetComponent<levelMenuScript>().switching = false;
			main.GetComponent<levelMenuScript>().enabled = true;
			
			
		}
		else if (s.Equals("title")) {
			main.GetComponent<levelMenuScript>().enabled = false;
			main.GetComponent<optionsMenu>().enabled = false;
			main.GetComponent<memoriesMenuScript>().enabled = false;
			main.GetComponent<titlemenu>().switching = false;
			main.GetComponent<titlemenu>().enabled = true;
			
		}
		
	}
}
