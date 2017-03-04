using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance { get; set;}
	public GameObject [] players;
	private Transform[] targets = new Transform[4];
	public float time1, time2, time3;
	public int phase;
	private bool onPhase, gameFinished;
	// Use this for initialization
	void Start () {
		onPhase = false;
		gameFinished = false;
		phase = 1;
		for (int i = 0; i < players.Length; i++) {
			Instantiate(players[i], GameObject.FindWithTag("Spawn" + (i+1)).GetComponent<Transform>().position, Quaternion.identity);
			players [i].GetComponent<Movement>().pNumber = i + 1;
			targets[i] = players [i].GetComponent<Transform>();
		}
		StartCoroutine (Countdown (time1));
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		//for (int i = 0; i < targets.Length; i++) {
			//CameraControl.instance.m_Targets [i] = targets [i];
		//}
		if (phase == 1 && !onPhase) {
			StartCoroutine (Countdown (time1));
		} else if (phase == 2 && !onPhase) {
			StartCoroutine (Countdown (time2));
		} else if (phase == 3 && !onPhase) {
			StartCoroutine (Countdown (time3));
		} else {
			gameFinished = true;
		}
	}

	public IEnumerator Countdown(float time){
		print ("Started coroutine!");
		onPhase = true;
		yield return new WaitForSeconds (time);
		phase++;
		onPhase = false;
	}
}
