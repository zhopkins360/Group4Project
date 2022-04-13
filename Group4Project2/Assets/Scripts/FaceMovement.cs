using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMovement : MonoBehaviour
{
    //position variables
    private Vector3 prevPos, movement;

    private void Start()
    {
        //sets prevPos to current position
        prevPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if the position has changed
        if (prevPos != transform.position)
        {
            //set vector of movement
            movement = (transform.position - prevPos).normalized;

            //set previous position
            prevPos = transform.position;
        }

        //zeroes out vertical movement
        movement.y = 0;

        //set look position
        transform.LookAt(transform.position + movement, Vector3.up);
    }
}
