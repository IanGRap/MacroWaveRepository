using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour {

    public GameObject[] enemies;

    public GameObject[] landingPoints;

    private int timer = 0;

    //Seconds between spawns
    public float spawnTimer = 1;

	// Use this for initialization
	void Start () {
        spawnTimer *= 60;
	}
	
	// Update is called once per frame
	void Update () {
        if(timer % spawnTimer == 0) {
            //Spawn an enemy and have them move to the landing
            var theEnemy = Instantiate(enemies[0], transform.position, transform.rotation);
            theEnemy.GetComponent<pizza_controller>().landing = landingPoints[Random.Range(0, landingPoints.Length)];
        }

        timer++;
	}
}
