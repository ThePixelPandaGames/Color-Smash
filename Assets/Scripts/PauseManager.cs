using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject colorWheel;
    public GameObject effectImage;
    public GameObject centerBubble;


    public void ShowPauseUI()
    {
        Time.timeScale = 0;
        GameManager.Instance.isPaused = true;
        PauseUI.SetActive(true);
        colorWheel.SetActive(false);
        effectImage.SetActive(false);
        centerBubble.SetActive(false);

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
        colorWheel.SetActive(true);
        centerBubble.SetActive(true);

        effectImage.SetActive(true);

    }

    public void BackToMenuButton()
    {
        // use scene manager to go back
    }
}
