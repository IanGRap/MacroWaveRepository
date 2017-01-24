
//Note: create a UI image
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Application;

public class GameOver : MonoBehaviour {

    // vars

    public Health HPscript;
    public player_movement Movescript;
	private bool gitgud;
	private bool pause;
	private float alpha;
	private float fade_time;
    private float pause_time;
    private float pause_start;
    private float pause_end;
	public Image black;
    private Color c;

	void Start () {
        gitgud = false;
		pause = false;
		alpha = 0;
		fade_time = 0;
		c = black.material.color;
		c.a = alpha;
		black.material.color = c;

	}

	void Update () {
		if (HPscript.HP <= 0){
			//pause buffer
			if (!pause) {
				pause_start = Time.time;
				pause_end = pause_start + pause_time;
                //pause the game before fading to black
                //this does not work since it messes with the time and time is needed for the fading
                //I don't think we need it to pause when the player dies
                //Time.timeScale = 0;
                Movescript.speed = 0;
				Debug.Log("in pause");
				pause = true;
			}
			if (pause_end < Time.time){

				fade_time += Time.deltaTime;
				//need to tweek the values for the fade as it fades in too fast
				if (fade_time > 0.9f){
					
					alpha += 0.2f;
					fade_time = 0;
				}
				c = black.material.color;
				c.a = alpha;
				black.material.color = c;

				if (alpha >= 20f) {
					gitgud = true;
				}
				if (gitgud) {
					SceneManager.LoadScene ("GAMEOVER");
				}
			}

		}
	}
		
}
