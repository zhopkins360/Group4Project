using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMovement : MonoBehaviour
{
    private Vector3 prevPos, movement;

    private void Start()
    {
        prevPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (prevPos != transform.position)
        {
            movement = (transform.position - prevPos).normalized;
            prevPos = transform.position;
        }
        //movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.LookAt(transform.position + movement, Vector3.up);

    }
}
