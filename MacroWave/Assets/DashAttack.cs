using System.Collections;
using System.Collections.Generic;
using Application;
using UnityEngine;

public class DashAttack : MonoBehaviour {

    public float maxDashSpeed;

    public int timeToMax;
    public int timeAtMax;
    public int timeToStop;

    private int dashingTimer = 0;
    private float windIter;
    private float stopIter;

    private float currentDashSpeed;

    private string dashState = ""; //windingUp, dashing, or stopping

    public bool hungry = true;     //If the dash is ready to be activated on click
    public bool recharging = false;
    public float dashCooldown = 200f;
    private float dashCooldownIter = 0f;


    // Use this for initialization
    void Start() {
        windIter = maxDashSpeed / timeToMax;
        stopIter = maxDashSpeed / timeToStop;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (hungry && !recharging) {
                dashState = "windingUp";
            }
        }

        //Impliment the current dash speed
        if (dashState != "") {
            transform.position += transform.up * Time.deltaTime * currentDashSpeed;
        }

        if (dashState == "windingUp") {
            if (currentDashSpeed < maxDashSpeed) {
                currentDashSpeed += windIter;
            }
            else {
                dashState = "dashing";
            }
        }

        else if (dashState == "dashing") {
            currentDashSpeed = maxDashSpeed;

            if (dashingTimer > timeAtMax) {
                dashingTimer = 0;
                dashState = "stopping";
            }
            else {
                dashingTimer++;
            }
        }
        else if (dashState == "stopping") {
            if (currentDashSpeed > 0) {
                currentDashSpeed -= stopIter;
            }
            else {
                endDash();
            }
        }
        if (recharging) {
            if(dashCooldownIter > dashCooldown) {
                recharging = false;
                dashCooldownIter = 0;
            }
            else {
                dashCooldownIter++;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "enemy") {
            if (dashState != "" && hungry == true) {
                //We are hungry, let's try to eat an enemy!
                other.gameObject.GetComponent<EnemyDeath>().killEnemy(this.gameObject);
                //GetComponent<Cooking>().cooking = true;
                //hungry = false;
                //endDash();
                dashState = "";
            }
            else {
                //Check if the enemy is a threat
                if (other.gameObject.GetComponent<EnemyDeath>().dying == false) {
                    GetComponent<Health>().takeHealth(1);
                }
            }
        }
    }

    private void endDash() {
        dashState = "";
        currentDashSpeed = 0;
        recharging = true;

        //Begin the cooldown
    }
}