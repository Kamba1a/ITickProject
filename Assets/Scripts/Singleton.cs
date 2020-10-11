using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> : MonoBehaviour where T: MonoBehaviour
{
    static T instance;
    static object locker = new object();

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<T>();
                        if (instance == null)
                        {
                            instance = new GameObject(typeof(T).Name).AddComponent<T>();
                        }
                    }
                    DontDestroyOnLoad(instance);
                }
            }
            return instance;
        }
    }

    public static T GetThis()
    {
        if (instance == null)
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        instance = new GameObject(typeof(T).Name).AddComponent<T>();
                    }
                }
            }
        }
        return instance;
    }
}
