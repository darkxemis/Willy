﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Ground : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerController> ();
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			player.grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			player.grounded = false;
		}
	}
}
