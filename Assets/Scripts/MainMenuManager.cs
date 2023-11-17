using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    MusicManager musicManager;
    void Start()
    {
        SettingsManager.LoadSettings();

        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();    

        ApplySettings();
    }

    private void ApplySettings()
    {
        if(SettingsManager.currentSettings.isMusicOn == 1) musicManager.SetVolumeTo(SettingsManager.currentSettings.musicVolume); else
        {
            musicManager.SetVolumeTo(0);
        }
    }

  
}
