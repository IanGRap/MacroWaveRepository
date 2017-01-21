using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingEventBox : MonoBehaviour {

	public string color;

	private BoxCollider2D bc2d;
	private CookingEventMaster master;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		bc2d = GetComponent<BoxCollider2D> ();
		master = GetComponentInParent <CookingEventMaster> ();
		sprite = GetComponent <SpriteRenderer> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "cursor") {
			master.UpdateCursor (color);
		}
	}

	public void SetSprite(bool spriteStatus){
		sprite.enabled = spriteStatus;
	}




}
