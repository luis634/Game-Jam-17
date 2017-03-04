using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour {
	private float startTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.phase == 1)
			gameObject.GetComponent<Text> ().text = "Time remaining: " + Mathf.Floor (GameManager.instance.time1 - Time.time);
		else if (GameManager.instance.phase == 2)
			gameObject.GetComponent<Text> ().text = "Time remaining: " + Mathf.Floor (GameManager.instance.time2 + (GameManager.instance.time1 - Time.time));
		else if (GameManager.instance.phase == 3)
			gameObject.GetComponent<Text> ().text = "Time remaining: " + Mathf.Floor (GameManager.instance.time3 + (GameManager.instance.time2 + (GameManager.instance.time1 - Time.time)));
		else {
			gameObject.GetComponent<Text> ().text = "Game ended!";
		}
	}
}
