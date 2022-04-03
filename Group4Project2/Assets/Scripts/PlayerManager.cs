using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int maxNumberOfActions = 3;
    public Slider actionBar;
    public Item[] backPack;
    GameObject Inventory;
    // Start is called before the first frame update
    void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("Inventory");
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
    }

    //Code for interacting with the players stamina 
    public void useAction()
    {
        actionBar.value -= 1;
    }

    public void resetActions()
    {
        actionBar.value = maxNumberOfActions;
    }


    //code for interacting with the player back pack
    public void pickUpItem()
    {
        int freeIndex = -1;
        for(int i = 0; i < backPack.Length; i++)
        {
            if(backPack[i] == null)
            {
                freeIndex = i;
            }
        }

    }

    public void dropItem(int id)
    {

    }
}
