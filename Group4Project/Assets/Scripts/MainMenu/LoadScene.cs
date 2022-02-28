/*
 * Group 4
 * CIS 350:01
 * Manage scene transitions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadDevScene()
    {
        //loads scene
        SceneManager.LoadScene("DevScene");
    }
    public void LoadmainMenu()
    {
        //loads scene
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadLevel1()
    {
        Debug.Log("Function called");
        //loads scene
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        //loads scene
        SceneManager.LoadScene("level2");
    }
    public void LoadLevel3()
    {
        //loads scene
        SceneManager.LoadScene("level3");
    }
    public void LoadLevel4()
    {
        //loads scene
        SceneManager.LoadScene("level4");
    }
    public void LoadLevel5()
    {
        //loads scene
        SceneManager.LoadScene("level5");
    }
}