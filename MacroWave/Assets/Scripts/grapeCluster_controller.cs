using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapeCluster_controller : MonoBehaviour {
	private GameObject player;
	public GameObject grape;

	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float step = speed * Time.deltaTime;
		var player_pos = player.transform.position;
		float distanceToPlayer = Mathf.Sqrt(Mathf.Pow((transform.position.x -player_pos.x),2) + Mathf.Pow((transform.position.y -player_pos.y),2));
		if (distanceToPlayer <= 5.0f) {
			Instantiate(grape, transform.position, transform.rotation);
			Instantiate(grape, transform.position, transform.rotation);
			Instantiate(grape, transform.position, transform.rotation);
			Instantiate(grape, transform.position, transform.rotation);
			Destroy (this.gameObject);
			print ("exploding");
		}

		transform.position = Vector3.MoveTowards(transform.position, player_pos, step);//move towards function
	}



}
