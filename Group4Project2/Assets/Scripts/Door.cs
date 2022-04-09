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

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        blackout = GameObject.FindGameObjectWithTag("BlackOut").GetComponent<CanvasGroup>();
    }

    public override void Interact()
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
    void Update()
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
