using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, ITick
{
    private void Awake()
    {
        UpdateManager.Add(this);
    }

    public void Tick()
    {
        Debug.Log($"I'm {gameObject.name}!");
    }
}
