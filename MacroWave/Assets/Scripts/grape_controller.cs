using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grape_controller : MonoBehaviour {
	private float grapeSpeed = 0.5f;
	private Rigidbody2D rb;
	private int numGrape;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (grapeSpeed * Random.Range (-10, 10), grapeSpeed * Random.Range (-10, 10));

	}

	// Update is called once per frame
	void Update () {
		

	}
}
