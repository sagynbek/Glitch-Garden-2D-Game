using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in seconds")]
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = Time.timeSinceLevelLoad >= levelTime;

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().SetTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
