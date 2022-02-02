/*
 * group 4
 * 2/2/22
 * moves obstacles over time
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //speed of movement
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //move car speed units per second towards the back
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
