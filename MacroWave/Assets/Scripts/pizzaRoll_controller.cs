using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizzaRoll_controller : MonoBehaviour
{
    private GameObject player;
    private Vector3 target_pos;
    public float speed = 2.4f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player"); // Find and get player
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        var player_pos = player.transform.position;
        target_pos = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target_pos, step); // Move towards function
    }
}
