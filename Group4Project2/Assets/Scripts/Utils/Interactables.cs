using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactables : MonoBehaviour
{
    //name of the object/NPC seprate from inspector name
    public string label;

    //highlight bool
    public bool isHighlighted;

    public GameObject ButtonPrompt;

    //outline reference, has to be an array to allow for multipart objects / multiple renderers
    protected cakeslice.Outline[] outlines;

    //method used to interact in a general way with an object/NPC
    public abstract void Interact();

    //called every frame
    private void Update()
    {
        //checks if an object is highlighted
        if (isHighlighted)
        {
            //itterate through the outlines and set them to enabled
            foreach (var item in outlines)
            {
                item.enabled = true;
            }
        }
        else
        {
            //itterate and disable outlines
            foreach (var item in outlines)
            {
                item.enabled = false;
            }
        }

        ButtonPrompt.SetActive(isHighlighted);
        //disable highlighted variable. If it is still in radius, it will be set back
        isHighlighted = false;
    }
}