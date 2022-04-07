using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject pauseMenu;

    private string CurrentLevelName = string.Empty;


    //methods to load and unload scenes
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("Game Manager: unable to load level" + levelName);
            return;
        }
        CurrentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("Game Manager: unable to unload level" + levelName);
            return;
        }
    }

    //pausing and unpausing
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }


    public void unPause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("Game Manager: unable to unload level" + CurrentLevelName);
            return;
        }
    }
}
