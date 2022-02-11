/*
 * Group 4
 * 2/11/22
 * removes scene dressing when too far behind player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDressing : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -30)
        {
            Destroy(gameObject);
        }
    }
}
