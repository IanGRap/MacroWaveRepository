
//Note: create a UI image
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Application;

public class GameOver : MonoBehaviour {

	// vars

	public Health HPscript;
	private bool gitgud;
	public bool pause;
	public float alpha;
	public float fade_time;
	public float pause_time;
	public float pause_start;
	public float pause_end;
	public Image black;
	//public Sprite box;
	public Color c;

	void Start () {
		gitgud = false;
		pause = false;
		//black.sprite = box;
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
				Debug.Log("in pause");
				pause = true;
			}
			if (pause_end < Time.time){
				Debug.Log ("in fade");
				fade_time += Time.deltaTime;
				//need to tweek the values for the fade as it fades in too fast
				if (fade_time > 0.9f){
					
					alpha += 10f;
					fade_time = 0;
				}
				c = black.material.color;
				c.a = alpha;
				black.material.color = c;

				if (alpha >= 255f) {
					gitgud = true;
				}
				if (gitgud) {
					SceneManager.LoadScene ("GAMEOVER");
				}
			}

		}
	}
		
}
