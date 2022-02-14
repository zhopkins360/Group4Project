using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePrefabMovment : MonoBehaviour
{
    private RectTransform rectTransform;

    public float speed;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        rectTransform.Translate(Vector3.right * Time.deltaTime * speed);
        //if(rectTransform.PosX)
    }
}
