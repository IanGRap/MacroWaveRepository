using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int score;
    private int previousScore;

	// Use this for initialization
	void Start () {
        score = 0;
        previousScore = score;
        updateScore();
	}
	
	// Update is called once per frame
	void Update () {
		if(score != previousScore) {
            updateScore();
            previousScore = score;
        }
	}

    private void updateScore() {
        scoreText.text = "Score: " + score;
    }
}
