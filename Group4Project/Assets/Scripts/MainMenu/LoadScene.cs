﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //scene to be loaded when called | ONLY put scenes in this reference
    public Object SceneToLoad;

    public void loadDevScene()
    {
        //loads scene
        SceneManager.LoadScene(SceneToLoad.name);

        //TODO: check if reference valid before loading just in case
    }
}