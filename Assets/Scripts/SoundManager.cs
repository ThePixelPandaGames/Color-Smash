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

    public AudioClip sfx_se_star_during;
    public AudioClip sfx_lose_life;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();  

    }


    public void ShotScoreSFX()
    {
        AudioClip randomClip = sfx_score[ Random.Range(0, sfx_score.Length)];
        audioSource.PlayOneShot(randomClip);
    }

    public void ShotDuringStarSFX()
    {
        audioSource.PlayOneShot(sfx_se_star_during);
    }

    public void ShotLoseLifeSFX()
    {
        audioSource.PlayOneShot(sfx_lose_life);
    }

    public void StopDuringStarSFX()
    {
        //audioSource.Stop();
        FadeOut();
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

    private void FadeOut()
    {
        StartCoroutine(FadeOutCo(audioSource, 0.75f, 0f));
    }

    IEnumerator FadeOutCo(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = SettingsManager.currentSettings.SFXVolume;
        yield break;
    }

}
