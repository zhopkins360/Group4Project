using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDoor : Door
{
    [Header("Scene to be loaded by door \nWARNING: only add scene references here")]
    public Object MainScene;

    public override void Interact()
    {
        if (MainScene != null)
        {
            StartCoroutine(BlackoutScreen());
            SceneManager.LoadSceneAsync(MainScene.name);
        }
        else
        {
            Debug.Log("Devscene is null");
        }
    }
}
