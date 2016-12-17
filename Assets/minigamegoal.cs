using UnityEngine;
using System.Collections;

public class minigamegoal : MonoBehaviour {
	
	int numberOfGoals;
	public float speed;
	int i = 0;
	float step;
	public bool completed = false;
	
	public Transform[] goals;
	public Transform spawnLocation;
	
	void Start () {
		numberOfGoals = goals.Length;
	}
	
	void Update() {

	step = speed * Time.deltaTime;
	transform.position = Vector3.MoveTowards(transform.position, goals[i].transform.position, step);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "goal") {
			if (i != (numberOfGoals - 1)) {
				i++;
				
			}
			else {
				completed = true;
			}
		}
		else if ((other.gameObject.tag == "Red") || (other.gameObject.tag == "Yellow") || (other.gameObject.tag == "Blue") || (other.gameObject.tag == "White")) {
			i = 0;
			
			gameObject.transform.position = spawnLocation.transform.position;
				
			}
		
	}
}
