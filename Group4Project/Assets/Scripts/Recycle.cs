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
    //z cordinate for when to move(zBack) and how far(recycleDist) - conrad
    public float zBack, recycleDist;

    //prefab of obstacle to be created when recycled
    public GameObject prefab;

    // Update is called once per frame
    void Update()
    {
        //if object is beyond xBack, reinstantiate it at the start
        if(transform.position.z < zBack)
        {
            //randomize what lane the obstacle appears in
            int laneIndex = Random.Range(-2, 2) * 2;

            //create position to create new copy of prefab
            Vector3 recyclePosition= new Vector3(laneIndex, 0.3f, transform.position.z + recycleDist);

            //create new obstacle with no roatation in case of collision
            Instantiate(prefab, recyclePosition, new Quaternion());

            //destroy self
            Destroy(gameObject);
        }
    }
}
