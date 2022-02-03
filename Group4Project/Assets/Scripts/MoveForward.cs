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
    public float speed, turning;

    // Update is called once per frame
    void Update()
    {
        //move car speed units per second towards the back, partially in worldspace and partially relevant to object, in order to veer in a more pleasing way
        transform.Translate(Vector3.back * speed*2 * Time.deltaTime,Space.World);
        transform.Translate(Vector3.forward * speed * Time.deltaTime,Space.Self);

        //try to align back to road
        transform.rotation = new Quaternion(0, transform.rotation.y - (transform.rotation.y/turning), 0, 1);
    }
}
