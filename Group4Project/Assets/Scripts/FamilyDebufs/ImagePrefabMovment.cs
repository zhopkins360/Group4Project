using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImagePrefabMovment : MonoBehaviour
{
    private RectTransform rectTransform;

    public float speed;
    private LevelManager levelManagerScript;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        levelManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
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
        if (levelManagerScript.gameOver)
        {
            Destroy(gameObject);
        }
    }
}
