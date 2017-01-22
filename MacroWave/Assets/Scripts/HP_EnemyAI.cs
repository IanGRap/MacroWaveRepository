using UnityEngine;
using System.Collections;

public class HP_EnemyAI : MonoBehaviour
{
    public Transform playerTarg;
    public float speed;
    private GameObject player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Microwave");  // Find and get player
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float step = speed * Time.deltaTime;
        var player_pos = player.transform.position;
        player_pos += new Vector3(0, 0, 0);     //location to move to in relation to player
        transform.position = Vector3.MoveTowards(transform.position, player_pos, step);
    }
}
