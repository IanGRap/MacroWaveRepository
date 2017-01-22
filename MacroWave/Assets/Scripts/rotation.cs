﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    //Public Vars
    public Camera camera;
    public float speed;

    //Private Vars
    private Vector3 mousePosition;
    private Vector3 direction;
    private float distanceFromObject;

    void FixedUpdate() {

        if (Input.mousePosition != null) {

            //Grab the current mouse position on the screen
            mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - camera.transform.position.z));

            //Rotates toward the mouse
            GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 90);

            //Judge the distance from the object and the mouse
            distanceFromObject = (Input.mousePosition - camera.WorldToScreenPoint(transform.position)).magnitude;

            //Move towards the mouse
            GetComponent<Rigidbody2D>().AddForce(direction * speed * distanceFromObject * Time.deltaTime);

        }//End Move Towards If Case

    }//End Fire3 If case
}
