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
        musicManager.SetVolumeTo(SettingsManager.currentSettings.musicVolume);
    }

  
}
