using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Singleton<PlayerManager>
{
    public int maxNumberOfActions = 3;
    public Slider actionBar;

    // Start is called before the first frame update
    void Start()
    {
        actionBar = GameObject.FindGameObjectWithTag("ActionBar").GetComponent<Slider>();
        actionBar.maxValue = maxNumberOfActions;
        actionBar.value = maxNumberOfActions;
    }

    // Update is called once per frame
    void Update()
    {
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
