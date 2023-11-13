using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager: MonoBehaviour
{

    public static SettingsManager instance;

    public Settings currentSettings;


    private void Start()
    {
        currentSettings = new Settings();

        if (InMainMenuScene())
        {
            LoadSettings();
        }

        GameObject[] objs = GameObject.FindGameObjectsWithTag("settings manager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }



    private bool InMainMenuScene()
    {
        return SceneManager.GetActiveScene().name == "Main Menu";
    }
    public void LoadSettings()
    {
        currentSettings.playerName = PlayerPrefs.GetString("playerName");
        currentSettings.musicVolume = PlayerPrefs.GetFloat("musicVolume");
        currentSettings.SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        currentSettings.rotationSensitivity = PlayerPrefs.GetFloat("rotationSensitivity");
        currentSettings.score = PlayerPrefs.GetFloat("score");
        currentSettings.time = PlayerPrefs.GetFloat("time");
        currentSettings.ratio = PlayerPrefs.GetFloat("ratio"); 
    }



    public void SaveSettings(Settings newSettings) {
        currentSettings.playerName = newSettings.playerName;
        currentSettings.musicVolume = newSettings.musicVolume;
        currentSettings.SFXVolume = newSettings.SFXVolume;
        currentSettings.rotationSensitivity = newSettings.rotationSensitivity;

        PlayerPrefs.SetString("playerName", newSettings.playerName);
        PlayerPrefs.SetFloat("musicVolume", newSettings.musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", newSettings.SFXVolume);
        PlayerPrefs.SetFloat("rotationSensitivity", newSettings.rotationSensitivity);

        LoadSettings();
    }


    public void SaveHighScore(int score, int time)
    {
        Settings newSettings = new Settings();

        newSettings.score = score;
        newSettings.time = time;
        newSettings.ratio = score / time;

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
}


