/*
 * group 4
 * 2/2/22
 * recycles objects that go off screen
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycle : MonoBehaviour
{
    //z cordinate for when to move(zBack) and how far(zFront) - conrad
    public float zBack, zFront;

    //prefab of obstacle to be created when recycled
    public GameObject[] prefab;

    // Update is called once per frame
    void Update()
    {
        //if object is beyond xBack, reinstantiate it at the start
        if(transform.position.z < zBack)
        {
            recycle();
        }
    }

    public void recycle()
    {
        //randomize what one of 5 lanes the obstacle appears in
        int laneIndex = Random.Range(-2,3)*2;

        //create position to create new copy of prefab
        Vector3 recyclePosition = new Vector3(laneIndex, 0.1f, zFront);

        //create new obstacle with no roatation in case of collision
        Instantiate(prefab[Random.Range(0, prefab.Length)], recyclePosition, new Quaternion());

        //destroy self
        Destroy(gameObject);
    }
}
