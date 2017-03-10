using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFunctions : MonoBehaviour {

    public GameObject crowdAmbient;
    public GameObject crowdCheer;

	// Use this for initialization
	void Start () {
        var crowdSound = Instantiate(crowdAmbient);
        crowdSound.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playCrowdCheer() {
        var sound = Instantiate(crowdCheer);
        sound.GetComponent<AudioSource>().Play();
    }
}
