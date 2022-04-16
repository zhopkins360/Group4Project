using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Singleton<PlayerManager>
{
    //current day
    public int Day;

    //max number of actions to be taken in a day
    public int maxNumberOfActions = 3;

    //
    public int peopleHelped;

    //UI references
    public Slider actionBar;
    public Text dayCounter;

    // Start is called before the first frame update
    void Start()
    {
        //sets starting values
        peopleHelped = 0;
        Day = 1;

        //finds and initialises actionbar with max actions
        actionBar = GameObject.FindGameObjectWithTag("ActionBar").GetComponent<Slider>();
        actionBar.maxValue = maxNumberOfActions;
        actionBar.value = maxNumberOfActions;
    }

    // Update is called once per frame
    void Update()
    {
        //displays current day
        dayCounter.text = "<b>Day : " + Day + "</b>\n";
        
        //debug commands
        if (Input.GetKeyDown(KeyCode.K))
        {
            UseAction();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ResetActions();
        }

        //if action bar is below half, tutorialize the day system
        if (actionBar.value < actionBar.maxValue / 2 && Day == 1)
        {
            dayCounter.text += "\nYou're getting tired,\n"
                               + "try going to your house\n"
                               + "where you started";
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
