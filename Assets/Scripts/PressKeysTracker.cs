using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressKeysTracker : Singleton<PressKeysTracker>, ITick
{
    private void Awake()
    {
        UpdateManager.Add(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) => UpdateManager.Add(this);
    private void OnSceneUnloaded(Scene current) => Toolbox.ClearTools();

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == "Scene1") SceneManager.LoadScene("Scene2");
            else SceneManager.LoadScene("Scene1");
        }
    }
}
