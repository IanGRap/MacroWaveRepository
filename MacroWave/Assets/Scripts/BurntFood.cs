﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurntFood : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Working");
		if (other.gameObject.tag == "enemy") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
