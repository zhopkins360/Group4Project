using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCycle : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    public float speed;

    private LevelManager level;

    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        startPos = transform.position; // Establish the default starting position 
        repeatWidth = 10;
    }

    private void Update()
    {
        if (!level.gameOver)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        // If background moves left by its repeat width, move it back to start position
        if (transform.position.z < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
