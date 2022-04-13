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

    public GameObject wantedItem;

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
        //states:
        //state 0: NPC has never been spoken to
        //state 1: NPC has since informed you of the requested item
        //state 2: Player completes request
        //state 3: Player has already completed request

        //when in certain states, energy shouldn't be used, especially since the NPC will just repeat himself
        if (status == 1 || status == 3)
        {
            PlayerManager.Instance.actionBar.value += 1;
        }

        //check if wanted item is in inventory
        if (Backpack.Instance.IsObjectInBackpack(wantedItem.GetComponent<Collectable>().ID) && status == 1)
        {
            NPCState = 2;
            status = 2;
        }


        if (status < Sentances.Length)
        {
            //sets the speech text
            SpeechText.text = "<b>" + label + "</b>\n" + Sentances[status];
        }
        else
        {
            SpeechText.text = "<b>" + label + "</b>\n" + "Current status does not have any text associated with it. Status #: " + status;
        }

        //advance states appropriately
        //if in state 0, npc has now been spoken to, advance state
        if (status == 0)
        {
            AdvanceState();
        }
        //if in state 2, npc has now acknowledged the fulfilled request, so advance state
        else if (status == 2)
        {
            AdvanceState();
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
