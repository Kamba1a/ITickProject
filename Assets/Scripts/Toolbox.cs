using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

public class Toolbox : Singleton<Toolbox>
{
    Dictionary<Type, object> tools = new Dictionary<Type, object>();

    //public static void Add(object obj)
    //{
    //    Instance.tools.Add(obj.GetType(), obj);
    //    Debug.Log(obj.GetType());
    //}

    //public static T Get<T>()
    //{
    //    Instance.tools.TryGetValue(typeof(T), out object obj);
    //    return (T)obj;
    //}

    public static T GetOrCreate<T>()
    {
        if (!Instance.tools.ContainsKey(typeof(T)))
        {
            Instance.tools.Add(typeof(T), new GameObject("UpdateManager").AddComponent<UpdateManager>());
        }
        return (T)Instance.tools[typeof(T)];
    }

    public static void ClearTools()
    {
        Instance.tools.Clear();
    }
}
