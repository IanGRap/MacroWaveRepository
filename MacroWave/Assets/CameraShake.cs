using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    private Vector2 vibrator;
    public GameObject cameraHolder;

    private int shakeLength = 0;
    private int shakeTimer = 0;

    private float persistentShaker = 0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (shakeLength > 0) {
            if (shakeTimer < shakeLength) {
                vibrator = Random.insideUnitCircle * 0.5f;
                transform.position = cameraHolder.transform.position + new Vector3(vibrator.x, vibrator.y, 0);

                shakeTimer++;
            }
            else {
                shakeTimer = 0;
                shakeLength = 0;
            }
        }

        else if (persistentShaker > 0) {
            vibrator = Random.insideUnitCircle * persistentShaker;
            transform.position = cameraHolder.transform.position + new Vector3(vibrator.x, vibrator.y, 0);
        }
    }

    public void cameraShakeBurst(int shakeDuration) {
        shakeLength = shakeDuration * 5;
    }

    public void persistentShake(float severity) {
        persistentShaker = severity/40;
    }
}
