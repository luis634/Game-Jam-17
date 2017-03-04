using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Transform> ().Rotate (0, 30*Time.deltaTime, 0);
	}
}
