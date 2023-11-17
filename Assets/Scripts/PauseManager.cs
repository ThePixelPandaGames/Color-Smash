using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject colorWheel;
    public GameObject effectImage;
    public GameObject centerBubble;

    public Toggle musicToggle;
    public Toggle SFXToggle;

    private MusicManager musicManager;
    private SoundManager soundManager;

    private void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();
        soundManager = GetComponent<SoundManager>();
    }

    public void ToggleMusic()
    {
        Debug.Log("changing music");
        Settings newSettings = SettingsManager.currentSettings;

        if (musicToggle.isOn )
        {
            musicManager.SetVolumeTo(SettingsManager.currentSettings.musicVolume);
            newSettings.isMusicOn = 1;
        }
        else
        {
            musicManager.SetVolumeTo(0);
            newSettings.isMusicOn = 0;
        }

        SettingsManager.SaveSettings(newSettings);
    }

    public void ToggleSFX()
    {
        Settings newSettings = SettingsManager.currentSettings;

        if (SFXToggle.isOn)
        {
            soundManager.SetVolumeTo(SettingsManager.currentSettings.SFXVolume);
            newSettings.isSFXOn = 1;
        }
        else
        {
            soundManager.SetVolumeTo(0);
            newSettings.isSFXOn = 0;
        }
        SettingsManager.SaveSettings(newSettings);
    }


    public void ShowPauseUI()
    {
        Time.timeScale = 0;
        GameManager.Instance.isPaused = true;
        PauseUI.SetActive(true);
        colorWheel.SetActive(false);
        effectImage.SetActive(false);
        centerBubble.SetActive(false);


        if (SettingsManager.currentSettings.isMusicOn == 0) musicToggle.SetIsOnWithoutNotify(false); else musicToggle.SetIsOnWithoutNotify(true);
        if (SettingsManager.currentSettings.isSFXOn == 0) SFXToggle.SetIsOnWithoutNotify(false); else SFXToggle.SetIsOnWithoutNotify(true);

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
        
    }
}
