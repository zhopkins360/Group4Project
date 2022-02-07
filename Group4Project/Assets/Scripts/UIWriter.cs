using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWriter : MonoBehaviour
{
    private Text textBox;

    private LevelManager level;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        textBox = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "Time left: " + level.timeLeft.ToString("2f") + "\n";

        for (int i = 0; i < level.health; i++)
        {
            textBox.text += "<color ff0000>❤</color>";
        }
        for (int i = level.health; i < level.maxHealth; i++)
        {
            textBox.text += "<color bb0000>❤</color>";
        }
    }
}
