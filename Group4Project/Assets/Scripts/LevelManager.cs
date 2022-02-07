﻿/*
 * Group 4
 * CIS 350:01
 * Manages game variables (health, timer, gamestate)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int health, maxHealth;
    
    public float timeLeft;

    public bool gameOver;

    public GameObject laneDiv;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        InvokeRepeating("laneDivider", 0, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        //enforce max health
        if(health> maxHealth)
        {
            health = maxHealth;
        }

        //if out of health or time, clean up time and end game
        if (health <= 0 || timeLeft <=0)
        {
            timeLeft = 0f;
            gameOver = true;
        }

        //when the game is not over, reduce timer
        if (!gameOver)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            //when game is over, restart level when key R is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    //called when the player is damaged, such as when coliding with obstacles
    public void damage()
    {
        health--;
    }

    void laneDivider()
    {
        if (!gameOver)
        {
            for (int i = -3; i < 4; i += 2)
            {
                Instantiate(laneDiv, new Vector3(i, -0.04f, 20), new Quaternion());
            }
        }
    }
}
