//script for the tutorial NPC
//the tutorial NPC just serves as an interaction tutorial and doesn't want an item
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialNPC : Interactables
{
    //reference to speech canvas
    [SerializeField] private GameObject Speech;

    private Text SpeechText;

    private void Awake()
    {
        //set reference
        SpeechText = Speech.GetComponentInChildren<Text>();

        //hide speech
        Speech.SetActive(false);

        //set outline references
        outlines = GetComponentsInChildren<cakeslice.Outline>();
    }

    //general interaction function for tutorial NPC
    public override void Interact()
    {
        if (PlayerManager.Instance.Staminavalue != 0)
        {
            //On interact with NPC, talk to npc in its current state
            StartCoroutine(Talk());
        }
    }

    public IEnumerator Talk()
    {
        //set text
        SpeechText.text = "<b>" + label + "</b>\nHello, how are you doing?";

        //shows speech bubble
        Speech.SetActive(true);

        //waits 4 seconds so can be read by player
        yield return new WaitForSeconds(4);

        //hides speech bubble
        Speech.SetActive(false);
    }
}
