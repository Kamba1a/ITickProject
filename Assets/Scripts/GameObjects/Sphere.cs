using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour, ITick
{
    private void Awake()
    {
        //Toolbox.GetOrCreate<UpdateManager>().Add(this);
        UpdateManager.Add(this);
    }

    public void Tick()
    {
        Debug.Log($"I'm {gameObject.name}!");
    }
}
