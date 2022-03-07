/*
 * Group 4
 * shows introductions to levels
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIntroManager : MonoBehaviour
{
    //to pause at the start, must turn off level manager, family behavior, and player control
    private LevelManager levelManager;
    private PlayerControl playerControl;
    private FamilyBehavior familyBehavior;

    //bool to determine if the intro sequence plays at all: must be set inside Unity
    public bool doIntro;
    //int to keep track of which level is here: must be set inside Unity
    public int currentLevel;

    //strings
    public string sonIntroString = "You have now picked up your son. He loves rides in the car and isn't content to wait until he's 16 to start driving.\n" +
        "Your son will sometimes grab your wheel, forcibly moving you left or right.";
    public string daughterIntroString = "You have now picked up your daughter. Recently, she's become obsessed with showing you the drawings she's been working on.\n" +
        "Your daughter will show you her pictures, blocking your view of the road.";
    public string wifeIntroString = "You have now picked up your wife. She is concerned with how little time is left to get home.\n" +
        "Your wife will sometimes order you to drive faster, increasing your speed.";
    public string familyIntroString = "Now, all three of your family members are present, and each of their effects will be active and can occur simultaneously.";
    public string continueString = "Press Space to begin";

    //4 elements to intro: background image, main text, continue text, and the text background color "image".
    public Text introText;
    public Text continueText;
    public GameObject textBackground;
    public GameObject backImage;


    private void Awake()
    {
        //set references
        levelManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        familyBehavior = GameObject.FindGameObjectWithTag("GameController").GetComponent<FamilyBehavior>();

        //run intro if it's allowed
        if (doIntro)
        {
            //disable game elements
            levelManager.enabled = false;
            playerControl.enabled = false;
            familyBehavior.enabled = false;
            StartCoroutine(runIntro());
        }
    }

    IEnumerator runIntro()
    {
        //show intro elements
        introText.enabled = true;
        continueText.enabled = true;
        textBackground.SetActive(true);
        backImage.SetActive(true);
        //set appropriate text
        switch (currentLevel)
        {
            case 2:
                introText.text = sonIntroString;
                break;
            case 3:
                introText.text = daughterIntroString;
                break;
            case 4:
                introText.text = wifeIntroString;
                break;
            case 5:
                introText.text = familyIntroString;
                break;
        }
        continueText.text = continueString;

        //then wait for player to continue
        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }

        //disable intro elements
        introText.enabled = false;
        continueText.enabled = false;
        textBackground.SetActive(false);
        backImage.SetActive(false);
        introText.text = "";
        continueText.text = "";

        //enable game elements, starting the level
        levelManager.enabled = true;
        playerControl.enabled = true;
        familyBehavior.enabled = true;
    }
}
