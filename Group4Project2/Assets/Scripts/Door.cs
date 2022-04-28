using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : Interactables
{
    //playerManager reference
    private PlayerManager playerManager;

    //reference to blackout UI
    private CanvasGroup blackout;

    public GameObject peopleHelped;
    public Text helpedText;
    public GameObject endingPic;
    public GameObject mainmenuButtion;
    public GameObject directionalLight;

    //fade bools
    public bool fadeIn = false;
    public bool fadeOut = false;

    private void Awake()
    {
        //set outline reference
        outlines = GetComponents<cakeslice.Outline>();
        
        //if outlines are not found, look in childeren
        if (outlines.Length == 0)
        {
            outlines = GetComponentsInChildren<cakeslice.Outline>();
        }

        //get manager instance
        if (PlayerManager.IsInstantilized)
        {
            playerManager = PlayerManager.Instance;
        }
        else
        {
            playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        }

        //sets blackout UI reference
        blackout = GameObject.FindGameObjectWithTag("BlackOut").GetComponent<CanvasGroup>();
    }

    public void backToMainMenu()
    {
        Destroy(directionalLight);
        GameManager.Instance.UnloadLevel("DevScene");
        GameManager.Instance.LoadLevel("MainMenu");
    }

    public override void Interact()
    {
        //moves to next day if interacted with
        NextDay();
    }

    public void NextDay()
    {
        if (playerManager.Day < 3)
        {
            //fades black and back to transition
            StartCoroutine(BlackoutScreen());

            //reset availible actions
            playerManager.ResetActions();

            //TODO: move NPCs depending on day
        }
        else    
        {
            //starts the ending sequence
            StartCoroutine(Ending());
        }
    }

    IEnumerator Ending()
    {
        //start blackout
        fadeIn = true;

        //wait for transition
        yield return new WaitForSeconds(1.5f);

        
        peopleHelped.SetActive(true);
        if (playerManager.peopleHelped == 6)
        {
            helpedText.text = "People Helped : " + playerManager.peopleHelped + "/6";
            yield return new WaitForSeconds(1f);
            endingPic.SetActive(true);
            helpedText.text = "You Helped Everyone\nThank you for playing!";
            mainmenuButtion.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            helpedText.text = "People Helped : " + playerManager.peopleHelped + "/6 \nYou Weren't Able to help everyone. Try again and See if you can!";
            mainmenuButtion.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }

    }

    protected IEnumerator BlackoutScreen()
    {
        //initiates blackout
        fadeIn = true;

        //wait for transition
        yield return new WaitForSeconds(1.5f);

        //set day to next day
        playerManager.Day++;

        //wait for day change
        yield return new WaitForSeconds(0.5f);

        //disable blackout
        fadeOut = true;
    }


    void FixedUpdate()
    {
        //if fading in
        if (fadeIn)
        {
            //if blackout is not opaque
            if (blackout.alpha < 1)
            {
                //add deltaTime to alpha
                blackout.alpha += Time.deltaTime;

                //once alpha = 1, stop fadein
                if (blackout.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        //if fading out
        if (fadeOut)
        {
            //if blackout is visible
            if (blackout.alpha >= 0)
            {
                //subtract deltatime from alpha
                blackout.alpha -= Time.deltaTime;

                //once is not visable, stop fadout
                if (blackout.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
