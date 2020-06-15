using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] int waitToLoad = 5;
    [SerializeField] GameObject winLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;


    private void Start()
    {
        winLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        if(numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());

        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void SetTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        var spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner attackerSpawner in spawnerArray)
        {
            attackerSpawner.StopSpawning();
        }
    }
}
