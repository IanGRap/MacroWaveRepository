using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Application;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}

	public void OnMouseDown(){
		Debug.Log ("In return");
		SceneManager.LoadScene ("MainMenu");
	}

}
