using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactables
{
    private Text SpeechBox;
    [SerializeField] private int NPCState = 0;

    public override void Interact()
    {
        //On interact with NPC, talk to npc in its current state
        Talk(NPCState);
    }

    public void Talk(int status)
    {
        //triggers display of the current response depending on status
    }
}
