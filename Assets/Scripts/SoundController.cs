using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public AudioSource coinAudioSource;
    public AudioSource pickUpAudioSource;
    public AudioSource doorAudioSource;
    public AudioSource defeatAudioSource;
    public AudioSource startAudioSource;
    public AudioSource jumpAudioSource;
    public AudioSource welcomeAudioSource;
    public AudioSource sword1AudioSource;
    public AudioSource sword2AudioSource;
    public AudioSource dragonAudioSource;
    public AudioSource bonesAudioSource;
    
    
    
    
    public void PlayCoinSound()
    {
        coinAudioSource.Play();
    }
    
    public void PlayPickUpSound()
    {
        pickUpAudioSource.Play();
    }
    
    public void PlayDoorSound()
    {
        doorAudioSource.Play();
    }
    
    public void PlayDefeatSound()
    {
        defeatAudioSource.Play();
    }
    
    public void PlayStartSound()
    {
        startAudioSource.Play();
    }
    
    public void PlayJumpSound()
    {
        jumpAudioSource.Play();
    }
    
    public void PlayWelcomeSound()
    {
        welcomeAudioSource.Play();
    }
    
    public void PlaySword1Sound()
    {
        sword1AudioSource.Play();
    }
    
    public void PlaySword2Sound()
    {
        sword2AudioSource.Play();
    }
    
    public void PlayDragonSound()
    {
        dragonAudioSource.Play();
    }
    
    public void PlayBonesSound()
    {
        bonesAudioSource.Play();
    }
    
}
