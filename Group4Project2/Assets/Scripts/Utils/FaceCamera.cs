using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    //main camera to face
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        //set main camera reference
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //faces camera position
        transform.LookAt(cam.transform);
    }
}
