using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {

    public int lastScore;
    public Text scoreInt;
    public Text scoreString;

    public string[] scoreMonikers; //0-10, 11-20 etc.

    void Awake() {
        lastScore = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().score;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

	// Use this for initialization
	void Start () {
        scoreInt.text = lastScore.ToString();
        if(lastScore < 10) {
            scoreString.text = scoreMonikers[0];
        }
        else if(lastScore < 25) {
            scoreString.text = scoreMonikers[1];
        }
        else if(lastScore < 40) {
            scoreString.text = scoreMonikers[2];
        }
        else if(lastScore < 50) {
            scoreString.text = scoreMonikers[3];
        }
        else {
            scoreString.text = scoreMonikers[4];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
