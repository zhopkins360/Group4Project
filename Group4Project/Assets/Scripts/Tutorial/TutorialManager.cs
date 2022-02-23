/*
 * Group 4
 * script manages the flow of the tutorial level (Level1 Scene)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    //the tutorial level will start with certain game elements turned off
    //throughout the tutorial, elements will be turned on/off and manipulated using the script references
    //intitialize all references to other scripts
    private BackgroundCycle backgroundCycle;
    private LevelManager levelManager;
    private PlayerControl playerControl;

    //text to display on entire screen, potentially blocking the player's view
    public Text txtOver;
    //text to display underneath the player, which is out of the way
    public Text txtUnder;

    //game object which is the overlay text, which won't be visible all the time
    public GameObject textOverlay;

    //frequently used UI string
    public string continueKey = "<Press Space to Continue>";

    // Start is called before the first frame update
    void Start()
    {
        //set all references
        backgroundCycle = GameObject.FindGameObjectWithTag("TutorialRoad").GetComponent<BackgroundCycle>();
        levelManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        //call initialize
        initTutorial();

        //run tutorial
        StartCoroutine(tutorial());
    }

    //initTutorial disables appropriate scripts and sets appropriate values for the tutorial
    void initTutorial()
    {
        //disable scripts
        backgroundCycle.enabled = false;
        playerControl.enabled = false;
        levelManager.enabled = false;
        //disable text overlay in case it isn't already
        //remember to set this textOverlay variable as active any time you want to display overlay text
        textOverlay.SetActive(false);
    }

    //tutorial method is the whole tutorial itself
    IEnumerator tutorial()
    {
        //with everything disabled (assuming initTutorial has been run), display the introductory text
        //the spacebar is the default key to progress the tutorial
        textOverlay.SetActive(true);
        txtOver.text = "Welcome to the tutorial.";
        //display standard skip dialogue
        txtUnder.text = continueKey;
        //display it until the player presses space, use this a lot
        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        txtOver.text = "Your goal is to maneuver yourself and your family to its destination, while avoiding the other vehicles on the road! Complete each level to gather each member of your family.";
        //add WaitForSeconds to prevent players from skipping more than once per spacebar press
        yield return new WaitForSeconds(1.0f);

        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        //start "moving"
        backgroundCycle.enabled = true;
        txtOver.text = "Use the left and right arrow keys to move your car.\nTry it now!";
        yield return new WaitForSeconds(1.0f);
        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        textOverlay.SetActive(false);
        txtUnder.text = "Use the left and right arrow keys to move your car.";
        //give player control
        playerControl.enabled = true;
        yield return new WaitForSeconds(5.0f);

        //show and describe next tutorial: obstacle cars
        textOverlay.SetActive(true);
        txtOver.text = "Throughout each level, cars will appear in your way. Avoid them!";
        txtUnder.text = continueKey;
        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        textOverlay.SetActive(false);
        txtUnder.text = "Avoid the other cars!";

        //spawn a few cars
        levelManager.Spawn();
        yield return new WaitForSeconds(0.5f);
        levelManager.Spawn();
        yield return new WaitForSeconds(1.0f);
        levelManager.Spawn();
        //after a few more seconds the player should have passed (or hit) the last car
        yield return new WaitForSeconds(4.0f);

        //next tutorial: health and damage
        levelManager.health = levelManager.maxHealth;
        levelManager.lowHealthParticles.SetActive(false);
        textOverlay.SetActive(true);
        txtOver.text = "If you collide with another vehicle, you take damage, represented by the heart icons in the top left.";
        txtUnder.text = continueKey;
        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        levelManager.health = 1;
        levelManager.criticalHealthParticles.SetActive(true);
        txtOver.text = "Let your health reach 0, and it's Game Over!";
        yield return new WaitForSeconds(1.0f);
        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }

        //HEALTH PICKUP TUTORIAL HERE

        levelManager.health = levelManager.maxHealth;
        levelManager.criticalHealthParticles.SetActive(false);
        txtOver.text = "Each level will only take a certain amount of time to complete, as shown in the top left. Survive until the end to win the level and pick up a member of your family.";
        yield return new WaitForSeconds(1.0f);
        //decrement time until the player presses space to continue
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            levelManager.timeLeft -= Time.deltaTime;
            yield return null;
        }
        levelManager.timeLeft = 60;
        //Note: as you pick up each family member, there should be a description of the debuff then, not here in the tutorial
        txtOver.text = "Beware, each level gets progressively harder, and picking up each new family member introduces a new challenging mechanic!";
        yield return new WaitForSeconds(1.0f);
        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        //turn off everything for the effect
        initTutorial();
        textOverlay.SetActive(true);
        txtOver.text = "Tutorial Complete!";
        yield return new WaitForSeconds(1.0f);

        //tutorial is complete, load next scene here when player presses space to continue
        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        SceneManager.LoadScene("MainMenu");
    }
}