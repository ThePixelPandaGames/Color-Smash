using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip menuMusic;
    public AudioClip buttonSound;


    private void Start()
    {
        musicSource = GetComponent<AudioSource>();  
        musicSource.clip = menuMusic;
        musicSource.loop = true;
        musicSource.Play();

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music Manager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject); 

    }

 
    public void PlayButtonSound()
    {
        musicSource.PlayOneShot(buttonSound, 2.0f);
    }

    public void StartMenuMusic()
    {
        musicSource.clip = menuMusic;
        musicSource.Play();
    }


    public void StopBgMusic()
    {
        musicSource.Stop();
    }

    public void ReduceAudioSpeedBy(float reduce)
    {
        musicSource.pitch *= reduce;
    }

    public void ResetAudioSpeed()
    {
        musicSource.pitch = 1;
    }

    public void SetVolumeTo(float volumeValue)
    {
        musicSource.volume = volumeValue;
    }

    public bool IsPlaying()
    {
        return musicSource.isPlaying;
    }

}
