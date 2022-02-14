using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        Vector2 movementVector = new Vector2(speed, 0);
        rectTransform.anchoredPosition += movementVector;

        if(rectTransform.anchoredPosition.x > 700)
        {
            Destroy(gameObject);
        }
    }
}
