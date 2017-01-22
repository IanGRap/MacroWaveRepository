using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizza_controller : MonoBehaviour {
	private GameObject player;
	private bool charging = false;
	private bool chargeReady = true;
	private Vector3 target_pos;
	private float chargeRate = 1.0f;
	private float nextCharge = 0.0f;

	public float speed = 5.0f;

    private bool jumping = true;
    public GameObject landing;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");//find and get player

	}

    // Update is called once per frame
    void FixedUpdate() {
        if (jumping == true) {
            if(landing != null) {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, landing.transform.position, step);
                if(transform.position == landing.transform.position) {
                    jumping = false;
                }
            }
        }
        else {
            float step = speed * Time.deltaTime;
            var player_pos = player.transform.position;
            float distanceToPlayer = Mathf.Sqrt(Mathf.Pow((transform.position.x - player_pos.x), 2) + Mathf.Pow((transform.position.y - player_pos.y), 2));
            //print (distanceToPlayer);
            if (distanceToPlayer <= 5.0f && !charging && chargeReady) {
                charging = true;
                chargeReady = false;
                target_pos = player.transform.position;

                print("charging!");
            }
            if (charging == false && chargeReady) {
                target_pos = player.transform.position;//update target pos to player pos
                print("updating target_pos");
            }

            float distanceToTarget = Mathf.Sqrt(Mathf.Pow((transform.position.x - target_pos.x), 2) + Mathf.Pow((transform.position.y - target_pos.y), 2));
            //print (distanceToTarget);
            if (distanceToTarget <= 0.1 && charging == true) {
                charging = false;
                nextCharge = Time.time + chargeRate;
                print("finished charge");

            }
            if (!charging && !chargeReady) {
                Vector3 vectorToTarget = player.transform.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
                if (Time.time > nextCharge) {
                    chargeReady = true;
                    print("charge ready!");
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, target_pos, step);//move towards function
        }
    }
}
