using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactables
{
    //reference to speech canvas
    [SerializeField] private GameObject Speech;

    //reference to speech text field
    private Text SpeechText;

    //current state
    private int NPCState = 0;
    //states:
    //state 0: NPC has never been spoken to
    //state 1: NPC has since informed you of the requested item
    //state 2: Player completes request
    //state 3: Player has already completed request

    //array of statements to be displayed when interacted with
    public string[] Sentances;

    //reference to the object the NPC wants
    public GameObject wantedItem;

    private void Awake()
    {
        //set reference
        SpeechText = Speech.GetComponentInChildren<Text>();

        //hide speech
        Speech.SetActive(false);

        //set outline references
        outlines = GetComponentsInChildren<cakeslice.Outline>();
    }

    //general interaction function
    public override void Interact()
    {
        if (PlayerManager.Instance.Staminavalue != 0) {
            //On interact with NPC, talk to npc in its current state
            StartCoroutine(Talk());
        }
    }

    //displays text based on provided status
    public IEnumerator Talk(int status)
    {
        //checks if given status exists
        if (status < Sentances.Length)
        {
            //sets the speech text
            SpeechText.text = "<b>" + label + "</b>\n" + Sentances[status];
        }
        else
        {
            //reports if not found
            SpeechText.text = "<b>" + label + "</b>\n" + "Current status does not have any text associated with it. Status #: " + status;
            Debug.Log("Current status does not have any text associated with it. Status #: " + status);
        }

        //shows speech bubble
        Speech.SetActive(true);

        //waits 4 seconds so can be read by player
        yield return new WaitForSeconds(4);

        //hides speech bubble
        Speech.SetActive(false);
    }

    //triggers display of the current response depending on current NPCState
    public IEnumerator Talk()
    {
        //when in certain states, energy shouldn't be used, especially since the NPC will just repeat himself
        if (NPCState == 1 || NPCState == 3)
        {
            PlayerManager.Instance.actionBar.value += 1;
        }

        //check if wanted item is in inventory
        if (Backpack.Instance.IsObjectInBackpack(wantedItem.GetComponent<Collectable>().ID) && NPCState == 1)
        {
            PlayerManager.Instance.peopleHelped++;
            NPCState = 2;
        }

        //checks if given status exists
        if (NPCState < Sentances.Length)
        {
            //sets the speech text
            SpeechText.text = "<b>" + label + "</b>\n" + Sentances[NPCState];
        }
        else
        {
            //reports if not found
            SpeechText.text = "<b>" + label + "</b>\n" + "Current status does not have any text associated with it. Status #: " + NPCState;
            Debug.Log("Current status does not have any text associated with it. Status #: " + NPCState);
        }

        //remove item from backpack when given to NPC
        if (NPCState == 2)
        {
            Backpack.Instance.removeObjectFromBackpack(wantedItem.GetComponent<Collectable>().ID);
        }

        //advance states appropriately
        //if in state 0, npc has now been spoken to, advance state
        //if in state 2, npc has now acknowledged the fulfilled request, so advance state
        if (NPCState == 0 || NPCState == 2)
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

    //state management fuctions
    public int GetState()
    {
        return NPCState;
    }

    public void AdvanceState()
    {
        NPCState++;
    }
}
