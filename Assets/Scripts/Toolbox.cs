using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

public class Toolbox : Singleton<Toolbox>
{
    private Dictionary<Type, object> tools = new Dictionary<Type, object>();

    //public static void Add(object obj)
    //{
    //    Type objType = obj.GetType();
    //    if(objType.IsSubclassOf(typeof(MonoBehaviour)))
    //    {
    //        Instance.tools.Add(objType, new GameObject(objType.ToString()).AddComponent(objType));
    //    }
    //    else Instance.tools.Add(obj.GetType(), obj);
    //}

    //public static T Get<T>()
    //{
    //    Instance.tools.TryGetValue(typeof(T), out object obj);
    //    return (T)obj;
    //}

    public static T GetOrCreate<T>() where T : MonoBehaviour
    {
        Type tool = typeof(T);
        if (!Instance.tools.ContainsKey(tool))
        {
            Instance.tools.Add(tool, new GameObject(tool.ToString()).AddComponent(tool));
        }
        return (T)Instance.tools[tool];
    }

    public static void ClearTools()
    {
        Instance.tools.Clear();
    }
}
