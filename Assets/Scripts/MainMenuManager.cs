using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    MusicManager musicManager;
    public Animator logoRotationAnimator;
    void Start()
    {
        SettingsManager.LoadSettings();
        
        if(SettingsManager.currentSettings.firstSetup != 1)
        {
            
        }
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();

        logoRotationAnimator.SetTrigger("startSpin");


        ApplySettings();
    }

    private void ApplySettings()
    {
        Time.timeScale = 1;
        if(SettingsManager.currentSettings.isMusicOn == 1) 
            musicManager.SetVolumeTo(SettingsManager.currentSettings.musicVolume); 
        else
        {
            musicManager.SetVolumeTo(0);
        }

        // check if it is the initial setup 
        // if not: do nothing
        // if so: set default values for music & sfx volume and rot speed

        if (SettingsManager.currentSettings.firstSetup == 0)
        {
            SettingsManager.SetupDefaultValues();
        }

        
    }

    private void OnDestroy()
    {
        logoRotationAnimator.SetTrigger("stopSpin");
    }


}
