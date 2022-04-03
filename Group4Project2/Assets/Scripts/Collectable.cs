using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactables
{
    public bool inBackPack;

    public override void Interact()
    {
        //On interact collect item
        Collect();
    }

    public void Collect()
    {
        //adds item to inventory
    }

    public void Remove()
    {
        //removes item from inventory
    }
}
