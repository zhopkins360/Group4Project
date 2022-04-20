using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactables
{
    //bool if item is collected
    public bool inBackPack;

    //ID # assigned at runtime
    public int ID;

    private void Awake()
    {
        //set outlines
        outlines = GetComponents<cakeslice.Outline>();

        //if outline is not found, look in childeren
        if (outlines.Length == 0)
        {
            outlines = GetComponentsInChildren<cakeslice.Outline>();
        }
    }

    public override void Interact()
    {
        if (PlayerManager.Instance.Staminavalue != 0)
        {
            //On interact collect item
            Collect();
        }
    }

    public void Collect()
    {
        //display as in backpack/inventory
        inBackPack = true;

        //hid object
        gameObject.SetActive(false);
    }

    public void Remove()
    {
        //remove from backpack/inventory
        inBackPack = false;
    }
}
