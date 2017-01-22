using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target.transform.localPosition != transform.localPosition) {
            transform.localPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }
	}
}
