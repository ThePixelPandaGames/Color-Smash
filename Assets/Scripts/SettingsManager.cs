using System;
using UnityEngine;

public static class SettingsManager
{
    public static Settings currentSettings = new Settings();
  
    public static void LoadSettings()
    {
        currentSettings.playerName = PlayerPrefs.GetString("playerName");
        currentSettings.musicVolume = PlayerPrefs.GetFloat("musicVolume");
        currentSettings.SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        currentSettings.rotationSensitivity = PlayerPrefs.GetFloat("rotationSensitivity");
        currentSettings.score = PlayerPrefs.GetFloat("score");
        currentSettings.time = PlayerPrefs.GetFloat("time");
        currentSettings.ratio = PlayerPrefs.GetFloat("ratio");
        currentSettings.isMusicOn = PlayerPrefs.GetInt("isMusicOn");
        currentSettings.isSFXOn = PlayerPrefs.GetInt("isSFXOn");

    }



    public static void SaveSettings(Settings newSettings) {
        currentSettings.playerName = newSettings.playerName;
        currentSettings.musicVolume = newSettings.musicVolume;
        currentSettings.SFXVolume = newSettings.SFXVolume;
        currentSettings.rotationSensitivity = newSettings.rotationSensitivity;
        currentSettings.isMusicOn = newSettings.isMusicOn;
        currentSettings.isSFXOn = newSettings.isSFXOn;  

        PlayerPrefs.SetString("playerName", newSettings.playerName);
        PlayerPrefs.SetFloat("musicVolume", newSettings.musicVolume);
        PlayerPrefs.SetInt("isMusicOn", newSettings.isMusicOn);
        PlayerPrefs.SetInt("isSFXOn", newSettings.isSFXOn);
        PlayerPrefs.SetFloat("SFXVolume", newSettings.SFXVolume);
        PlayerPrefs.SetFloat("rotationSensitivity", newSettings.rotationSensitivity);

        LoadSettings();
    }


    public static void SaveHighScore(float score, float time, float ratio)
    {
        Settings newSettings = new Settings();

        newSettings.score = score;
        newSettings.time = time;
        newSettings.ratio = ratio;

      
        PlayerPrefs.SetFloat("score", newSettings.score);
        PlayerPrefs.SetFloat("time", newSettings.time);
        PlayerPrefs.SetFloat("ratio", newSettings.ratio);
    }


}


[Serializable]
public class Settings
{
    public Settings() { }

    public string playerName;
    public float musicVolume;
    public float SFXVolume;
    public float rotationSensitivity;
    public float score;
    public float time;
    public float ratio;
    public int isMusicOn;
    public int isSFXOn;
}


