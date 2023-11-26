using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    MusicManager musicManager;
    public Animator logoRotationAnimator;
    void Start()
    {
        SettingsManager.LoadSettings();

        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();

        logoRotationAnimator.SetTrigger("startSpin");


        ApplySettings();
    }

    private void ApplySettings()
    {
        if(SettingsManager.currentSettings.isMusicOn == 1) 
            musicManager.SetVolumeTo(SettingsManager.currentSettings.musicVolume); 
        else
        {
            musicManager.SetVolumeTo(0);
        }

        
    }

    private void OnDestroy()
    {
        logoRotationAnimator.SetTrigger("stopSpin");
    }


}
