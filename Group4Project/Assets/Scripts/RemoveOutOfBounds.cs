/*
 * Group 4
 * CIS 350:01
 * removes obstacles when they stray out of bounds
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOutOfBounds : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 4.5 || transform.position.y > .5)
        {
            Destroy(gameObject);
        }
    }
}
