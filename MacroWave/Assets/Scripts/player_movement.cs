using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class player_movement : MonoBehaviour {
	
	public float speed = 0.25f;
	public Boundary boundary;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//player movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		var movement = new Vector3 (moveHorizontal, moveVertical, 0);
		transform.position += movement * speed; 

		body.position = new Vector3
		(
			Mathf.Clamp (body.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (body.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);
	}
}
