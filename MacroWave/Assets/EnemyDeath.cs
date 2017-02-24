using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

    public bool dying = false;
    private float shrinkIter = 2f;

    private GameObject target;

    //Called from other scripts, plays an animation and then removes the object
	public void killEnemy(GameObject michael) {
        dying = true;
        target = michael;
    }

    void Update() {
        if (dying) {
            //Shrink the enemy into Michael and once it's done, tell Michael he's cooking
            transform.position = target.transform.position;

            if (transform.localScale.x > 0) {
                transform.localScale -= Vector3.one * Time.deltaTime * shrinkIter;
            }
            else {
                target.GetComponent<Cooking>().cooking = true;
                target.GetComponent<DashAttack>().hungry = false;
                Destroy(this.gameObject);
            }
        }
    }
}
