using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartSettingsInit : MonoBehaviour
{

    public Slider music_slider;
    public Slider SFX_slider;
    public Slider rotationSensitivity_slider;

    SettingsManager settingsManager;
    void Start()
    {
        settingsManager = GameObject.Find("Settings Manager").GetComponent<SettingsManager>();
        UpdateSettingsInfoUI();
    }


    private void UpdateSettingsInfoUI()
    {
        music_slider.value = settingsManager.currentSettings.musicVolume;
        SFX_slider.value = settingsManager.currentSettings.SFXVolume;
        rotationSensitivity_slider.value = settingsManager.currentSettings.rotationSensitivity;
    }


    public void SaveSettings()
    {
        Settings newSettings = new Settings();

        newSettings.playerName = "defaultName";
        newSettings.musicVolume = music_slider.value;
        newSettings.SFXVolume = SFX_slider.value;
        newSettings.rotationSensitivity = rotationSensitivity_slider.value;

        settingsManager.SaveSettings(newSettings);
    }
}
