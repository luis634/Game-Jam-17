using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject [] players;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < players.Length; i++) {
			Instantiate(players[i], GameObject.FindWithTag("Spawn" + (i+1)).GetComponent<Transform>().position, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
