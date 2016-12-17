using UnityEngine;
using System.Collections;

public class ControlDisplayer : MonoBehaviour {
	
	string textUsed;
	
	GameObject rememberer;
	TextMesh mesh;

	// Use this for initialization
	void Start () {
		mesh = gameObject.GetComponent<TextMesh>();
		
		rememberer = GameObject.FindGameObjectWithTag("rememberer");
		
		if (Application.loadedLevel == 1) {
			mesh.text = "Use the mouse to look around.\nUse " + rememberer.GetComponent<rememberer>().moveForwards + ", " + rememberer.GetComponent<rememberer>().moveBackwards + ", " + rememberer.GetComponent<rememberer>().moveLeft + ", " + rememberer.GetComponent<rememberer>().moveRight + " to move.";
		}
		else if (Application.loadedLevel == 2) {
			mesh.text = "Press " + rememberer.GetComponent<rememberer>().jump + " to jump over obstacles.";
		}
		else if (Application.loadedLevel == 3) {
			mesh.text = "Press " + rememberer.GetComponent<rememberer>().escape + " to pause the game, change game \noptions, return to the main menu or restart the level.";
		}
		else if (Application.loadedLevel == 4) {
			mesh.text = "Press " + rememberer.GetComponent<rememberer>().change1 + ", " + rememberer.GetComponent<rememberer>().change2 + ", " + rememberer.GetComponent<rememberer>().change3 + " to change activated colors. \nYou can also review or change the controls from the options menu.";
		}
		else if (Application.loadedLevel == 8) {
			mesh.text = "Placeholder for now ";
		}
		else if (Application.loadedLevel == 25) {
			mesh.text = "Press " + rememberer.GetComponent<rememberer>().invert + " to reverse gravity.\n You must me mid-air to reverse gravity.";
		}
		else if (Application.loadedLevel == 36) {
			mesh.text = "Press " + rememberer.GetComponent<rememberer>().invert + " to switch to your ghost. The ghost can not change\n colors, or switch gravity. However, the ghost is invulnrable to lasers.";
		}
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
