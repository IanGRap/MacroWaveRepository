using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private Button start;
	// Use this for initialization
	void Start ()
    {
        start = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("StartScene");
    }
=======
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void onClick(){
		SceneManager.LoadScene ("StartScene");
	}
>>>>>>> 1ab8d7b1a9b9e02a939a3eb4c31a84dfb4ba4cc5
}
