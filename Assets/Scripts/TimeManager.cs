using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [HideInInspector]public int secondsPast;
    [HideInInspector]public bool timeIsTicking;
    public TextMeshProUGUI timerUI;
    [HideInInspector] public float secondsToWait;

    void Start()
    {
        secondsPast = 0;
        timeIsTicking = true;
        secondsToWait = 1f;
        StartCoroutine(StartTimer());
    }

    public void ResumeTimer()
    {
        Time.timeScale = 1;
        timeIsTicking = true;
        StartCoroutine(StartTimer());
    }


    IEnumerator StartTimer ()
    {
        while (timeIsTicking && !GameManager.Instance.isPaused)
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
