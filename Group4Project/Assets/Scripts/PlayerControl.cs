﻿/*
 * group 4
 * 2/2/22
 * controls player movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //veriable for input, max speed, and limit of +/- x
    public float horizontalInput, speed, xLimit;

    //for debug below
    public GameObject prefab;

    // Update is called once per frame
    void Update()
    {
        //get input
        horizontalInput = Input.GetAxis("Horizontal");

        //move player
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed,Space.World);

        //Rotate on move
        transform.rotation = Quaternion.Euler(0, horizontalInput * 25, 0);

        //keep player bounded
        if (transform.position.x < -xLimit || transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit * Mathf.Sign(transform.position.x), transform.position.y, transform.position.z);
        }

        //Debug summon cars
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, transform.position - new Vector3(0, 0, 10), new Quaternion());
        }
    }
}