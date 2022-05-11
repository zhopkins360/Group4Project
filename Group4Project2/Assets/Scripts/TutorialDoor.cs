using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDoor : Interactables
{
    //playerManager reference
    private PlayerManager playerManager;

    //reference to blackout UI
    private CanvasGroup blackout;

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

    public override void Interact()
    {
<<<<<<< Updated upstream
        //StartCoroutine(BlackoutScreen());
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
=======
        StartCoroutine(BlackoutScreen());
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
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
>>>>>>> Stashed changes
    }
}
