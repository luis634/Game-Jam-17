using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {
	private float num; 
	private Movement move;
	// Use this for initialization
	void Start () {
		num = Random.Range (0.0f, 2.0f);
		if (num < 1)
			gameObject.GetComponent<Material> ().color = new Color (0f, 0.1f, 1f);
		else if (num <= 2 && num >= 1)
			gameObject.GetComponent<Material> ().color = new Color (0f, 1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Transform> ().Rotate (0, 30*Time.deltaTime, 0);
	}

	//void OnCollisionEnter(Collision other){
		//if (num < 1)
			//StartCoroutine (Movement.speedIncrease());
		//else if (num <= 2 && num >= 1)
			//StartCoroutine (Movement.invisibility());
	//}
}
