using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuitButton : MonoBehaviour {
    public void OnMouseDown()
    {
        EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
