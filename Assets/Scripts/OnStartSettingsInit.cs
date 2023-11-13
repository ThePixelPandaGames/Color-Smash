using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartSettingsInit : MonoBehaviour
{

    public Slider music_slider;
    public Slider SFX_slider;
    public Slider rotationSensitivity_slider;

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

        SettingsManager.SaveSettings(newSettings);
    }
}
