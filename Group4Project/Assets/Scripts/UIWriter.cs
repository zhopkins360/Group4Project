/*
 * Group 4
 * CIS 350:01
 * Manages UI during play
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWriter : MonoBehaviour
{
    public Text textBox;

    public LevelManager level;

    // Start is called before the first frame update
    void Start()
    {
        //gets reference to level variables and the UI textBox
        level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        textBox = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is over, update the UI information
        if (!level.gameOver)
        {
            //print time remaining
            textBox.text = "Time left: " + level.timeLeft.ToString("F2") + "\n";

            //display health / maxHealth
            for (int i = 0; i < level.health; i++)
            {
                textBox.text += "<color=#ff0000ff>❤</color>";
            }
            for (int i = level.health; i < level.maxHealth; i++)
            {
                textBox.text += "<color=#6b0000ff>❤</color>";
            }
        }
        else
        {
            //if game is over, display instructions
            textBox.text = "Game Over!\nPress R to retry";
        }
    }
}
