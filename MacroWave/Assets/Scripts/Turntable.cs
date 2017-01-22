using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour {

    public AudioClip Jomesic;
    public AudioClip Hughesic;
    AudioSource Sona;

	// Use this for initialization
	void Start () {
        Sona = GetComponent<AudioSource>();
        float track = Mathf.Floor(Random.Range(0.0f, 1.999f));
        if (track == 0)
        {
            Sona.clip = Jomesic;
        }
        else
        {
            Sona.clip = Hughesic;
        }
        Sona.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
