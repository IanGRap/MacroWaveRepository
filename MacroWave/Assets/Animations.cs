using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {

    public GameObject player;
    private Vector2 vibrator;

    public Sprite openMouth1;
    public Sprite openMouth2;
    public Sprite closeMouth1;
    public Sprite closeMouth2;

    private bool chewing = false;

    private SpriteRenderer oppSprite;

    private int animator = 0;

    // Use this for initialization
    void Start () {
        oppSprite = GetComponent<SpriteRenderer>();
        oppSprite.sprite = openMouth1;
    }
	
	// Update is called once per frame
	void Update () {
        chewing = player.GetComponent<Attack>().full;

        if (Input.GetKeyDown(KeyCode.Space)) {
            chewing = !chewing;
            if (chewing) {
                oppSprite.sprite = closeMouth1;
            }
        }

        if (animator % 20 == 0) {
            //switch animation frame
            if (chewing == false) {
                if (oppSprite.sprite == openMouth1)
                    oppSprite.sprite = openMouth2;
                else
                    oppSprite.sprite = openMouth1;
            }
            else {
                if (oppSprite.sprite == closeMouth1)
                    oppSprite.sprite = closeMouth2;
                else
                    oppSprite.sprite = closeMouth1;
            }
        }

        if (chewing == true) {
            vibrator = Random.insideUnitCircle * 0.1f;
            transform.position = player.transform.position + new Vector3(vibrator.x, vibrator.y, 0);// Random.insideUnitCircle * 0.1f;
        }

        animator++;
    }
}
