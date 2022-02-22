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
    //scene to be loaded when called | ONLY put scenes in this reference
    public Object Dev;
    public Object level1;
    public Object level2;
    public Object level3;
    public Object level4;
    public Object level5;
    public Object mainMenu;

    public void LoadDevScene()
    {
        //loads scene
        SceneManager.LoadScene(Dev.name);
    }
    public void LoadmainMenu()
    {
        //loads scene
        SceneManager.LoadScene(mainMenu.name);
    }
    public void LoadLevel1()
    {
        //loads scene
        SceneManager.LoadScene(level1.name);
    }
    public void LoadLevel2()
    {
        //loads scene
        SceneManager.LoadScene(level2.name);
    }
    public void LoadLevel3()
    {
        //loads scene
        SceneManager.LoadScene(level3.name);
    }
    public void LoadLevel4()
    {
        //loads scene
        SceneManager.LoadScene(level4.name);
    }
    public void LoadLevel5()
    {
        //loads scene
        SceneManager.LoadScene(level5.name);
    }
}