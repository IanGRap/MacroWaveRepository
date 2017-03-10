using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : MonoBehaviour {

    public float movementSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > -30 && transform.position.x < 30 && transform.position.y > -30 && transform.position.y < 30) {
            transform.position += transform.up * Time.deltaTime * movementSpeed;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "enemy") {
            Destroy(other.gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().score+=2;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyCounter>().activeEnemies--;
        }
    }
}
