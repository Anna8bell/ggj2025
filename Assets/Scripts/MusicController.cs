using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    
    public AudioResource menuMusic;
    public AudioResource gameplayMusic;

    public bool isGameplayMusicStart = false;
    
    void Start()
    {
            audioSource.Play();
    }

    private void Update()
    {
        if (isGameplayMusicStart)
        {
            isGameplayMusicStart = false;
            PlayGameplayMusic();
        }
    }

    public void PlayGameplayMusic()
    {
        StartCoroutine(FadeOutAndStartGameplayMusic(0.2f));
    }

    private IEnumerator FadeOutAndStartGameplayMusic(float fadeDuration)
    {
        float startVolume = audioSource.volume;
        
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }
        
        audioSource.volume = 0;
        audioSource.Stop();
        audioSource.resource = gameplayMusic;
        audioSource.Play();
        
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, startVolume, t / fadeDuration);
            yield return null;
        }
        
        audioSource.volume = startVolume;

    }

}
