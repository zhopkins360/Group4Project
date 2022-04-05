using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactables
{
    public bool inBackPack;
    public int ID;

    public override void Interact()
    {
        //On interact collect item
        Collect();
    }

    public void Collect()
    {
        inBackPack = true;
        gameObject.SetActive(false);
    }

    public void Remove()
    {
        inBackPack = false;
    }
}
