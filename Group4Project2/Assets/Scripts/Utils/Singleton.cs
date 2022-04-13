using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    //reference to the current instance
    private static T instance;

    //get method for current intsance
    public static T Instance
    {
        get { return instance; }
    }

    //bool if there is an instance of T
    public static bool IsInstantilized
    {
        get { return instance != null; }
    }

    protected virtual void Awake()
    {
        //if there is a pre-existing instance, log it. otherwise, set the instance reference
        if (instance != null)
        {
            Debug.LogError("[Singleton] Attempted to create second instance of singleton");
        }
        else
        {
            instance = (T)this;
        }
    }

    //nulls instance refrence when current one is destroyed
    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
