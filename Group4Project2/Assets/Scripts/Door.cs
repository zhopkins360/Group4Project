using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Door : Interactables
{
    private PlayerManager playerManager;
    private CanvasGroup blackout;
    public bool fadeIn = false;
    public bool fadeOut = false;

    private void Awake()
    {
        outlines = GetComponents<cakeslice.Outline>();

        if (outlines == null)
        {
            outlines = GetComponentsInChildren<cakeslice.Outline>();
        }

        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        blackout = GameObject.FindGameObjectWithTag("BlackOut").GetComponent<CanvasGroup>();
    }

    public override void Interact()
    {
        NextDay();
    }

    public void NextDay()
    {
        StartCoroutine(BlackoutScreen());
        playerManager.ResetActions();
    }

    IEnumerator BlackoutScreen()
    {
        fadeIn = true;
        yield return new WaitForSeconds(1.5f);
        playerManager.Day++;
        yield return new WaitForSeconds(1);
        fadeOut = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fadeIn)
        {
            if (blackout.alpha < 1)
            {
                blackout.alpha += Time.deltaTime;
                if (blackout.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (blackout.alpha >= 0)
            {
                blackout.alpha -= Time.deltaTime;
                if (blackout.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
