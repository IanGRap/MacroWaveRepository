using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizza_controller : MonoBehaviour {
	private GameObject player;
	public float speed = 5.0f;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");//find and get player
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float step = speed * Time.deltaTime;
		var player_pos = player.transform.position;
		player_pos += new Vector3 (0, 0, 0);//location to move to in relation to player
		transform.position = Vector3.MoveTowards(transform.position, player_pos, step);
	}
}
