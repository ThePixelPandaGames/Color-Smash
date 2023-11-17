using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    

    // sfx
    public AudioClip[] sfx_score;

    public AudioClip sfx_levelUp;

    public AudioClip sfx_gameOver;

    public AudioClip sfx_se_star;
    public AudioClip sfx_se_fire;
    public AudioClip sfx_se_hourglass;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();  

    }


    public void ShotScoreSFX()
    {
        AudioClip randomClip = sfx_score[ Random.Range(0, sfx_score.Length)];
        audioSource.PlayOneShot(randomClip);
    }

    public void ShotLeveUpSFX()
    {
        audioSource.PlayOneShot(sfx_levelUp);
    }

    public void ShotGameOverSFX()
    {
        audioSource.PlayOneShot(sfx_gameOver);
    }

    public void ShotStarSFX()
    {
        audioSource.PlayOneShot(sfx_se_star);
    }

    public void ShotFireSFX()
    {
        audioSource.PlayOneShot(sfx_se_fire);
    }

    public void ShotHourglassSFX()
    {
        audioSource.PlayOneShot(sfx_se_hourglass);
    }


    public void SetVolumeTo(float volumeValue)
    {
        Debug.Log("audioSource: " + audioSource);
        audioSource.volume = volumeValue;
    }

}
