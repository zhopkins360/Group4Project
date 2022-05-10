using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDoor : Interactables
{
    public override void Interact()
    {
        StartCoroutine(BlackoutScreen());
        SceneManager.LoadScene("DevScene", LoadSceneMode.Single);
    }
}
