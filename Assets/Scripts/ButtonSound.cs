using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    private MusicManager musicManager;
    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();  
    }

    public void PlayButtonSound()
    {
        if (SettingsManager.currentSettings.isSFXOn == 1)
        {
            musicManager.PlayButtonSound();
        }
    }
}
