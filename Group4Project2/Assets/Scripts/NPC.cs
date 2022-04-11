using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactables
{
    [SerializeField] private GameObject Speech; private Text SpeechText;

    private int NPCState = 0;

    //array of statements to be displayed when interacted with
    public string[] Sentances;

    private void Awake()
    {
        SpeechText = Speech.GetComponentInChildren<Text>();

        Speech.SetActive(false);

        outlines = GetComponentsInChildren<cakeslice.Outline>();
    }

    public override void Interact()
    {
        //On interact with NPC, talk to npc in its current state
        StartCoroutine(Talk(NPCState));
    }

    //triggers display of the current response depending on status
    public IEnumerator Talk(int status)
    {
        if (status < Sentances.Length)
        {
            //sets the speech text
            SpeechText.text = "<b>" + label + "</b>\n" + Sentances[status];
        }
        else
        {
            SpeechText.text = "<b>" + label + "</b>\n" + "Current status does not have any text associated with it. Status #: " + status;
        }

        //shows speech bubble
        Speech.SetActive(true);

        //waits 4 seconds so can be read by player
        yield return new WaitForSeconds(4);

        //hides speech bubble
        Speech.SetActive(false);
    }

    public int GetState()
    {
        return NPCState;
    }

    public void AdvanceState()
    {
        NPCState++;
    }
}
