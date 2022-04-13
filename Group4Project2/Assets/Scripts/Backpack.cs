using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : Singleton<Backpack>
{
    //dynamic list of all collectable items
    public Collectable[] inventory;
    private GameObject[] slots;

    //refrence to backpack UI
    private GameObject backpack;

    //slot prefab
    [SerializeField]
    private GameObject backpackItemPrefab;

    //where to add slots
    private GameObject backpackSlotParent;

    void Start()
    {
        //get reference to inventory and slotParent
        backpack = GameObject.FindGameObjectWithTag("Inventory");
        backpackSlotParent = backpack.GetComponentInChildren<GridLayoutGroup>().gameObject;

        //lsit all collectables in scene
        inventory = GameObject.FindObjectsOfType<Collectable>();

        //array for inventory slots
        slots = new GameObject[inventory.Length];

        //set up backpack for each item
        for (int i = 0; i < inventory.Length; i++)
        {
            //add ID to item
            inventory[i].ID = i;

            //create slot for the item
            GameObject newCollectable = Instantiate(backpackItemPrefab, backpackSlotParent.transform);
            newCollectable.GetComponentInChildren<Text>().text = inventory[i].label;

            //add created slot to slots array
            slots[i] = newCollectable;

            //set as not collected as defualt
            inventory[i].inBackPack = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //itterate through 

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].inBackPack)
            {
                //set buttons color to show it has been picked up
                slots[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            else
            {
                //set buttons color to show it has been picked up
                //slots[i].GetComponent<Image>().color = new Color(50, 50, 50, 200);
            }
        }
    }

    //function to see if object with ID is collected
    public bool IsObjectInBackpack(int ID)
    {
        return inventory[ID].inBackPack;
    }
}
