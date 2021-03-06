﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 3;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0) { 
            StartCoroutine(WaitAndLoadScene(currentSceneIndex + 1));
        }
    }

    IEnumerator WaitAndLoadScene(string newIndex)
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(newIndex);
    }

    IEnumerator WaitAndLoadScene(int newIndex)
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(newIndex);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(WaitAndLoadScene("Game Over"));
    }

    public void Quit()
    {
        Application.Quit();
    }
}
