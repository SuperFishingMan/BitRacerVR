﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExitGate : MonoBehaviour {

	public LevelManager levelMan;

	public int points = 0;

	public List<Transform> rings;

	void OnTriggerEnter(Collider col) {
		if( col.tag == "Player" && !levelMan.player.GetComponent<ShipDriver>().stopped ) {
			levelMan.scoreManager.score += points;
			levelMan.scoreManager.updateDisplays();
			levelMan.wonLevel();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < rings.Count; i++) {
			Transform ring = rings [i];
			Vector3 translate = Vector3.forward * (1 + i/2);
			ring.localEulerAngles += translate;
		}
	}
}
