using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour {

    public Sprite background1;
    public Sprite background2;

    private SpriteRenderer oppSprite;

    private int animator = 0;

    // Use this for initialization
    void Start () {
        oppSprite = GetComponent<SpriteRenderer>();
        oppSprite.sprite = background1;
    }
	
	// Update is called once per frame
	void Update () {
		if(animator % 20 == 0) {
            if(oppSprite.sprite == background1) {
                oppSprite.sprite = background2;
            }
            else {
                oppSprite.sprite = background1;
            }
        }
        animator++;
	}
}
