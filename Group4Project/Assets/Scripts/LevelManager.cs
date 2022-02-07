using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int health, maxHealth;
    
    public float timeLeft;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health> maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 0 || timeLeft <=0)
        {
            gameOver = true;
        }

        while (!gameOver)
        {
            timeLeft = timeLeft - Time.deltaTime;
        }
    }

    public void damage()
    {
        health--;
    }
}
