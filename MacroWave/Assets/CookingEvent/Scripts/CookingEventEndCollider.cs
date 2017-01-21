using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingEventEndCollider : MonoBehaviour {

	private Rigidbody2D rb2d;
	private CookingEventMaster master;

	// Use this for initialization
	void Start () {
		master = GetComponentInParent <CookingEventMaster> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "cursor") {
			master.Deactivate ();
			master.MissedCursor ();
		}
	}
}
