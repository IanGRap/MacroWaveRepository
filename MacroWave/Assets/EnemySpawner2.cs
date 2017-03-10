using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour {

    public GameObject[] enemies;

    public GameObject[] landingPoints;

    private int timer = 0;

    //Seconds between spawns
    public float spawnTimer = 1;

    //The score interval at which spawnTimer will change
    public int scoreThreshold = 10;

    //The rate at which the spawnTimer will lower at each score interval
    public float spawnTimerDegradeRate = 0.5f;

    private int previousScoreThreshold = 0;

    public GameObject enemyCounter;

	// Use this for initialization
	void Start () {
        spawnTimer *= 60;
	}
	
	// Update is called once per frame
	void Update () {
        if(timer % spawnTimer == 0 && enemyCounter.GetComponent<EnemyCounter>().activeEnemies < 8) {
            //Spawn an enemy and have them move to the landing
            var theEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation);
            theEnemy.GetComponent<pizza_controller>().landing = landingPoints[Random.Range(0, landingPoints.Length)];
            enemyCounter.GetComponent<EnemyCounter>().activeEnemies++;
        }

        timer++;

        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().score >= previousScoreThreshold + scoreThreshold) {
            if (spawnTimer > 60*spawnTimerDegradeRate) {
                spawnTimer -= spawnTimerDegradeRate * 60;
                previousScoreThreshold = previousScoreThreshold + scoreThreshold;
            }
        }
	}
}
