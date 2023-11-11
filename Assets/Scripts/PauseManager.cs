using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseUI;

    public void ShowPauseUI()
    {
        Time.timeScale = 0;
        GameManager.Instance.isPaused = true;
        PauseUI.SetActive(true);
    }

    public void HidePauseUI()
    {
        PauseUI.SetActive(false);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        GameManager.Instance.isPaused = false;
        GetComponent<TimeManager>().ResumeTimer();
        HidePauseUI();
    }

    public void BackToMenuButton()
    {
        // use scene manager to go back
    }
}
