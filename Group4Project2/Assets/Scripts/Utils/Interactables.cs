using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    //name of the object/NPC seprate from inspector name
    public string label;

    public bool isHighlighted;

    protected cakeslice.Outline[] outlines;

    //method used to interact in a general way with an object/NPC
    public abstract void Interact();

    private void Update()
    {
        if (isHighlighted)
        {
            foreach (var item in outlines)
            {
                item.enabled = true;
            }
        }
        else
        {
            foreach (var item in outlines)
            {
                item.enabled = false;
            }
        }

        isHighlighted = false;
    }
}