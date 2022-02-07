/*
 * Group 4
 * CIS 350:01
 * Rotates an object
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    //wheter or not to reverse the rotation
    public bool reverse;

    // Update is called once per frame
    void Update()
    {
        //rotate the object dependant on bool
        transform.Rotate(0, reverse ? 1:-1, 0);
    }
}
