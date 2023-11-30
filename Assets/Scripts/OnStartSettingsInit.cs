using UnityEngine;
using UnityEngine.UI;

public class OnStartSettingsInit : MonoBehaviour
{

    public Slider music_slider;
    public Slider SFX_slider;
    public Slider rotationSensitivity_slider;

    public GameObject successfullMesage;


    void Start()
    {
        UpdateSettingsInfoUI();
    }


    private void UpdateSettingsInfoUI()
    {
        music_slider.value = SettingsManager.currentSettings.musicVolume;
        SFX_slider.value = SettingsManager.currentSettings.SFXVolume;
        rotationSensitivity_slider.value = SettingsManager.currentSettings.rotationSensitivity;
    }


    public void SaveSettings()
    {
        Settings newSettings = new Settings();

        newSettings.playerName = "defaultName";
        newSettings.musicVolume = music_slider.value;
        newSettings.SFXVolume = SFX_slider.value;
        newSettings.rotationSensitivity = rotationSensitivity_slider.value;

        if(newSettings.musicVolume > 0)
        {
            newSettings.isMusicOn = 1;
        } else
        {
            newSettings.isMusicOn = 0;
        }

        if (newSettings.SFXVolume > 0)
        {
            newSettings.isSFXOn = 1;
        }
        else
        {
            newSettings.isSFXOn = 0;
        }

        SettingsManager.SaveSettings(newSettings);

        successfullMesage.gameObject.SetActive(true);
    }
}
