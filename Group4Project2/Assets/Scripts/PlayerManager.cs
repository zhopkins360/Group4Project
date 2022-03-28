using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
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
            useAction();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            resetActions();
        }
    }

    public void useAction()
    {
        actionBar.value -= 1;
    }

    public void resetActions()
    {
        actionBar.value = maxNumberOfActions;
    }
}
