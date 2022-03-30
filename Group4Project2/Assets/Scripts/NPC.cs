using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactables
{
    [SerializeField] private GameObject Speech; private Text SpeechText;

    [SerializeField] private int NPCState = 0;

    //array of statements to be displayed when interacted with
    public string[] Sentances;

    private void Awake()
    {
        SpeechText = Speech.GetComponentInChildren<Text>();

        Speech.SetActive(false);
    }

    public override void Interact()
    {
        //On interact with NPC, talk to npc in its current state
        StartCoroutine(Talk(NPCState));
    }

    //triggers display of the current response depending on status
    public IEnumerator Talk(int status)
    {
        //sets the speech text
        SpeechText.text = Sentances[status];

        //shows speech bubble
        Speech.SetActive(true);

        //waits 4 seconds so can be read by player
        yield return new WaitForSeconds(4);

        //hides speech bubble
        Speech.SetActive(false);
    }
}
