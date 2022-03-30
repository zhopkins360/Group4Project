using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactables
{
    [SerializeField] private GameObject Speech;
    private Text SpeechText;
    [SerializeField] private int NPCState = 0;
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

    public IEnumerator Talk(int status)
    {
        //triggers display of the current response depending on status
        SpeechText.text = Sentances[status];

        Speech.SetActive(true);

        yield return new WaitForSeconds(4);

        Speech.SetActive(false);
    }
}
