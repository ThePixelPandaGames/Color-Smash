using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    int secondsPast;
    bool timeIsTicking;
    public TextMeshProUGUI timerUI;

    void Start()
    {
        secondsPast = 0;
        timeIsTicking = true;
        StartCoroutine(StartTimer());
    }


    IEnumerator StartTimer ()
    {
        while (timeIsTicking)
        {
            secondsPast++;
            UpdateTimerUI();
            yield return new WaitForSecondsRealtime(1);
        }
    }

    private void UpdateTimerUI()
    {
        timerUI.text = secondsPast.ToString() + "s"; 
    }
}
