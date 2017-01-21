using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingEventTester : MonoBehaviour {

	public CookingEventMaster cookingEvent;
	public float speed;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") && !cookingEvent.CheckActive()) {
			cookingEvent.Activate (speed);
		}
	}
}
