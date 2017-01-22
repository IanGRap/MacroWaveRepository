using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
