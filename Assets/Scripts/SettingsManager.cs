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
        currentSettings.firstSetup = PlayerPrefs.GetInt("firstSetup");
    }



    public static void SaveSettings(Settings newSettings) {
        currentSettings.playerName = newSettings.playerName;
        currentSettings.musicVolume = newSettings.musicVolume;
        currentSettings.SFXVolume = newSettings.SFXVolume;
        currentSettings.rotationSensitivity = newSettings.rotationSensitivity;
        currentSettings.isMusicOn = newSettings.isMusicOn;
        currentSettings.isSFXOn = newSettings.isSFXOn;
        currentSettings.firstSetup = newSettings.firstSetup;

        PlayerPrefs.SetString("playerName", newSettings.playerName);
        PlayerPrefs.SetFloat("musicVolume", newSettings.musicVolume);
        PlayerPrefs.SetInt("isMusicOn", newSettings.isMusicOn);
        PlayerPrefs.SetInt("isSFXOn", newSettings.isSFXOn);
        PlayerPrefs.SetFloat("SFXVolume", newSettings.SFXVolume);
        PlayerPrefs.SetFloat("rotationSensitivity", newSettings.rotationSensitivity);
        PlayerPrefs.SetInt("firstSetup", newSettings.firstSetup);

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

    public static void DeleteHighScore()
    {
        PlayerPrefs.SetFloat("score", 0);
        PlayerPrefs.SetFloat("time", 0);
        PlayerPrefs.SetFloat("ratio", 0);

        currentSettings.score = 0;
        currentSettings.time = 0;
        currentSettings.ratio = 0;
    }

    public static void SetupDefaultValues()
    {
        PlayerPrefs.SetFloat("musicVolume", 0.5f);
        PlayerPrefs.SetFloat("SFXVolume", 0.5f);
        PlayerPrefs.SetFloat("rotationSensitivity", 0.5f);

        currentSettings.rotationSensitivity = 0.5f;
        currentSettings.musicVolume = 0.5f;
        currentSettings.SFXVolume = 0.5f;

        currentSettings.firstSetup = 1;
        PlayerPrefs.GetInt("firstSetup", currentSettings.firstSetup);
    }

}


[Serializable]
public class Settings
{
    public Settings() { }
    public int firstSetup;
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


