using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour {

    public bool cooking = false;
    public bool spitting = false;
    public GameObject fireball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cooking) {
            if (Input.GetMouseButtonDown(0)) {
                //Create fireball facing the direction of the microwave
                Instantiate(fireball, transform.position, transform.rotation);

                cooking = false;

                //Reset the attack variables to be able to cook once again
                GetComponent<DashAttack>().recharging= true;
                GetComponent<DashAttack>().hungry = true;
                spitting = true;
            }
        }
	}
}
