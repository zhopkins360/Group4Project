/*
 * Group 4
 * CIS 350:01
 * Manages UI during play
 */
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIWriter : MonoBehaviour
{
    public Text textBox;

    public Slider health, time;

    public GameObject maniMenuButton;

    public LevelManager level;

    // Start is called before the first frame update
    void Start()
    {
        //gets reference to level variables and the UI textBox
        level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        textBox = gameObject.GetComponentInChildren<Text>();

        time = GetComponentsInChildren<Slider>().FirstOrDefault(r => r.tag == "Time");
        health = GetComponentsInChildren<Slider>().FirstOrDefault(r => r.tag == "Health");
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is over, update the UI information
        if (!level.gameOver)
        {
            //display time / health remaining
            time.value =1 -(level.timeLeft / level.maxTime);
            health.value = level.health;
        }
        else if (level.win)
        {
            maniMenuButton.SetActive(true);
            textBox.text = "You Win!\nPress R to retry";
        }
        else
        {
            maniMenuButton.SetActive(true);
            //if game is over, display instructions
            textBox.text = "Game Over!\nPress R to retry";
        }
    }
}
