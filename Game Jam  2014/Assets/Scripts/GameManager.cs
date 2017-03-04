using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject [] players;
	private Transform[] targets = new Transform[4];
	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < players.Length; i++) {
			Instantiate(players[i], GameObject.FindWithTag("Spawn" + (i+1)).GetComponent<Transform>().position, Quaternion.identity);
			players [i].GetComponent<Movement>().pNumber = i + 1;
			targets[i] = players [i].GetComponent<Transform>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < targets.Length; i++) {
			CameraControl.instance.m_Targets [i] = targets [i];
		}
	}
}
