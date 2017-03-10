using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

    public bool dying = false;
    private float shrinkIter = 2f;
    private int spinIter = 0;

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
                transform.Rotate(0, 0, spinIter);
                spinIter += 1;
            }
            else {
                target.GetComponent<Cooking>().cooking = true;
                target.GetComponent<DashAttack>().hungry = false;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyCounter>().activeEnemies--;
                Destroy(this.gameObject);
            }
        }
    }
}
