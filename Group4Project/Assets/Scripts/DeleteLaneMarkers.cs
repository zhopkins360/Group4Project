using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLaneMarkers : MonoBehaviour
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
