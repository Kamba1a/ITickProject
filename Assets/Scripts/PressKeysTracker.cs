using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressKeysTracker : MonoBehaviour, ITick
{
    void Awake()
    {
        UpdateManager.Add(this);
    }
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == "Scene1")
            {
                SceneManager.LoadScene("Scene2");
            }
            else
            {
                SceneManager.LoadScene("Scene1");
            }
            Toolbox.ClearTools();
        }
    }
}
