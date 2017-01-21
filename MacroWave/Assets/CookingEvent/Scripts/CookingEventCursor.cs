using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingEventCursor : MonoBehaviour {

	public Transform startLocation;

	private float speed;
	private Rigidbody2D rb2d;
	private bool active = false;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent <Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		sprite.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate(float s){
		active = true;
		speed = s;
		sprite.enabled = true;
	}

	public void Deactive(){
		active = false;
		this.transform.position = startLocation.position;
		speed = 0f;
		rb2d.velocity = new Vector2(0f, 0f);
		sprite.enabled = false;

	}

	void FixedUpdate(){
		if (active) {
			rb2d.velocity = new Vector2 (1f, 0f) * speed;
		} else {
			rb2d.velocity = new Vector2 (0f, 0f);
		}
	}
}
