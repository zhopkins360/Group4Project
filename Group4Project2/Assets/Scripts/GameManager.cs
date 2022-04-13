using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    //pause menu reference
    public GameObject pauseMenu;

    //name of current level in a string
    private string CurrentLevelName;

    //methods to load and unload scenes
    public void LoadLevel(string levelName)
    {
        //loads needed scene additively 
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        //if load failed, log issue
        if (ao == null)
        {
            Debug.LogError("Game Manager: unable to load level" + levelName);
            return;
        }

        //set current level name
        CurrentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        //unloads named scene
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);

        //if the unload fails, log issue
        if (ao == null)
        {
            Debug.LogError("Game Manager: unable to unload level" + levelName);
            return;
        }
    }

    //pausing and unpausing
    public void Pause()
    {
        //freeze time
        Time.timeScale = 0f;

        //show pause menu
        pauseMenu.SetActive(true);
    }

    public void UnPause()
    {
        //restart time
        Time.timeScale = 1f;

        //hide the pause menu
        pauseMenu.SetActive(false);
    }

    //called every frame
    private void Update()
    {
        //pause/unpause on P
        if (Input.GetKeyDown(KeyCode.P))
        {
            //if the pause menu is shown, hide it and vice versa
            if (pauseMenu.activeSelf)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }

    //unloads current level
    public void UnloadCurrentLevel()
    {
        UnloadLevel(CurrentLevelName);
    }
}
