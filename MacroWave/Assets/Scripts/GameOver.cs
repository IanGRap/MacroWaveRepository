
//Note: create a UI image
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Application;

public class GameOver : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void playerDied() {
        //Disable player movement

        //Allow enemies to swarm over the body for a few seconds

        //Fade to black

        //Go to next scene, which shows the player score and has button for main menu and retry
        SceneManager.LoadScene("GAMEOVER");
    }
		
}
