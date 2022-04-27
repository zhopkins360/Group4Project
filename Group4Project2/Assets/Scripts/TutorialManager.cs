using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject actionBarHighlight;
    public GameObject dayCounterHighlight;
    public Text mainText;
    public Text otherText;
    public Text dayLabel;
    public GameObject tutorialNPC;
    public TutorialNPC npcScript;
    public GameObject item;
    public GameObject tutorialDoor;
    //public GameObject tutorialObjects;
    public GameObject exitDoor;

    // Start is called before the first frame update
    void Start()
    {
        npcScript = tutorialNPC.GetComponent<TutorialNPC>();
        //initialize
        panel.SetActive(true);
        actionBarHighlight.SetActive(false);
        dayCounterHighlight.SetActive(false);
        mainText.text = "";
        otherText.text = "";
        dayLabel.text = "Day: 0";
        tutorialNPC.SetActive(false);
        item.SetActive(false);
        tutorialDoor.SetActive(false);
        //exitDoor.SetActive(false);
        npcScript.enabled = false;

        //run tutorial coroutine
        StartCoroutine(tutorial());

    }

    IEnumerator tutorial()
    {
        //set initial texts
        mainText.text = "Welcome to the Emergency Kindness tutorial.\nUse the <b>MOUSE</b> to look around.\nUse the <b>WASD</b> keys to move your character.";
        otherText.text = "Move your character with WASD to continue";
        //progress once player moves
        while (!(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))) { yield return null; }
        mainText.text = "A character has just spawned. Other characters in the game will request items when you talk to them. You can find and return these items to them in the game.";
        otherText.text = "Press SPACE to continue";
        tutorialNPC.SetActive(true);

        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        mainText.text = "Walk up to the character and press E to <b>Interact</b> with him. When you are close enough to an interactable, it is highlighted in red.";
        otherText.text = "Talk to the character (E) to continue";
        npcScript.enabled = true;

        while (!Input.GetKeyDown(KeyCode.E)) { yield return null; }
        mainText.text = "Performing <i>Actions,</i> like talking to the character just now, will deplete your Action Bar, highlighted above. The Action Bar represents the number of actions you can complete in a day.";
        otherText.text = "Press SPACE to continue";
        actionBarHighlight.SetActive(true);

        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        mainText.text = "Actions are used when talking to characters, picking up items, and returning items. You must manage your Actions carefully!";
        PlayerManager.Instance.actionBar.value = PlayerManager.Instance.maxNumberOfActions;

        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        actionBarHighlight.SetActive(false);
        mainText.text = "An item has just spawned. Items are present throughout the level and can be picked up by pressing E to <b>Interact</b> with them when you are close enough. Pick up the Pizza now.";
        otherText.text = "Pick up the Pizza (E) to continue.";
        item.SetActive(true);

        while (!Input.GetKeyDown(KeyCode.E)) { yield return null; }
        mainText.text = "In the game, there will be multiple items for multiple characters. Use the <b>Inventory</b> view to keep track of your items. For the tutorial, your inventory is empty. Open the inventory using R.";
        otherText.text = "Open the inventory (R) to continue";
        item.SetActive(false);

        while (!Input.GetKeyDown(KeyCode.R)) { yield return null; }
        mainText.text = "The inventory can be closed again by pressing R.\nAs you progress, you will eventually run out of actions. To refill them, you must sleep at your home, represented by the black door in the level.";
        otherText.text = "Press SPACE to continue.";
        PlayerManager.Instance.actionBar.value = 3;
        tutorialNPC.SetActive(false);
        actionBarHighlight.SetActive(true);
        tutorialDoor.SetActive(true);

        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        mainText.text = "Interact with the door to replenish your actions and advance to the next day.";
        otherText.text = "Interact (E) with the door to continue";
        actionBarHighlight.SetActive(false);

        while (!Input.GetKeyDown(KeyCode.E)) { yield return null; }
        PlayerManager.Instance.actionBar.value = PlayerManager.Instance.maxNumberOfActions;
        dayLabel.text = "Day: 1";
        mainText.text = "Sleeping advances the <b>Day</b>. You have 3 full days to do as much as you can. Afterwards, the game will end. The ending is affected by how many characters you help.";
        otherText.text = "Press SPACE to continue";
        dayCounterHighlight.SetActive(true);
        tutorialDoor.SetActive(false);

        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        dayLabel.text = "Day: 0";
        mainText.text = "You have completed the tutorial! For more information, you can Pause the game with P and view additional tutorial menus. Interact with the door again to start the game!";
        otherText.text = "Interact (E) with the door to start the game";
        exitDoor.SetActive(true);

        //while (!Input.GetKeyDown(KeyCode.E)) { yield return null; } 

    }
}
