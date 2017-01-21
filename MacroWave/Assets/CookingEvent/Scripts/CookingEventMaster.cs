using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingEventMaster : MonoBehaviour {

	public CookingEventBox[] EventBoxes;
	public CookingEventCursor cursor;

	private SpriteRenderer background;
	private bool active = false;
	private string cursorStatus = null;

	void Start(){
		background = GetComponentInChildren <SpriteRenderer> ();
		background.enabled = false;
		cursor = GetComponentInChildren <CookingEventCursor> ();
		for (int i = 0; i < EventBoxes.Length; i++) {
			EventBoxes [i].SetSprite (false);
		}
	}

	void Update(){
		if (active) {
			if (Input.GetButtonDown ("action")) {
				CursorHit ();
			}
		}
	}

	public void Activate(float speed){
		active = true;
		for (int i = 0; i < EventBoxes.Length; i++) {
			EventBoxes [i].SetSprite (true);
		}
		background.enabled = true;
		cursor.Activate (speed);
	}

	public void Deactivate(){
		cursorStatus = null;
		active = false;
		for (int i = 0; i < EventBoxes.Length; i++) {
			EventBoxes [i].SetSprite (false);
		}
		background.enabled = false;
		cursor.Deactive ();
	}

	public bool CheckActive(){
		return active;
	}

	public void UpdateCursor(string status){
		if (status == "yellow") {
			cursorStatus = "yellow";
		} else if (status == "green") {
			cursorStatus = "green";
		} else if (status == "red") {
			cursorStatus = "red";
		}
	}

	// Kyle This Part
	void CursorHit(){
		if (cursorStatus == "yellow") {
			//release enemy
			Debug.Log ("Yellow");
		} else if (cursorStatus == "green") {
			//heal player
			Debug.Log ("Green");
		} else if (cursorStatus == "red") {
			//fire enemy as projectile
			Debug.Log ("Red");
		} else
		Deactivate ();
	}

	public void MissedCursor(){
		//Whatever happens if the cursor runs of the end without being hit
	}
}
