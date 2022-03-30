using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    //name of the object/NPC seprate from inspector name
    public string label;

    //method used to interact in a general way with an object/NPC
    public abstract void Interact();
}