using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    int secondsPast;
    bool timeIsTicking;
    public TextMeshProUGUI timerUI;
    [HideInInspector] public float secondsToWait;

    void Start()
    {
        secondsPast = 0;
        timeIsTicking = true;
        secondsToWait = 1f;
        StartCoroutine(StartTimer());
    }


    IEnumerator StartTimer ()
    {
        while (timeIsTicking)
        {
            secondsPast++;
            UpdateTimerUI();
            yield return new WaitForSecondsRealtime(secondsToWait); ;
        }
    }

    private void UpdateTimerUI()
    {
        timerUI.text = secondsPast.ToString() + "s"; 
    }
}
