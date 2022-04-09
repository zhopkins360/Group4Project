using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Singleton<PlayerManager>
{
    public int Day;
    public int maxNumberOfActions = 3;
    public Slider actionBar;
    public Text dayCounter;

    // Start is called before the first frame update
    void Start()
    {
        Day = 1;
        actionBar = GameObject.FindGameObjectWithTag("ActionBar").GetComponent<Slider>();
        actionBar.maxValue = maxNumberOfActions;
        actionBar.value = maxNumberOfActions;
    }

    // Update is called once per frame
    void Update()
    {
        dayCounter.text = "Day : " + Day;
        if (Input.GetKeyDown(KeyCode.P))
        {
            UseAction();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ResetActions();
        }
    }

    //Code for interacting with the players stamina 
    public void UseAction()
    {
        actionBar.value -= 1;
    }

    public void ResetActions()
    {
        actionBar.value = maxNumberOfActions;
    }
}
