using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactables
{
    public bool inBackPack;
    public int ID;

    private void Awake()
    {
        outlines = GetComponents<cakeslice.Outline>();

        if (outlines == null)
        {
            outlines = GetComponentsInChildren<cakeslice.Outline>();
        }
    }

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
