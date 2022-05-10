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
        string name = MainScene.name;
        StartCoroutine(BlackoutScreen());
        SceneManager.LoadScene("DevScene");
    }
}
