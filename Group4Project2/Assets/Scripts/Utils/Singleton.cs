using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsInstantilized
    {
        get { return instance != null; }
    }

    protected virtual void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("[Singleton] Attempted to create second instance of singleton");
        }
        else
        {
            instance = (T)this;
        }
    }

    protected virtual void onDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
