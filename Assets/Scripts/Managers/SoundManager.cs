using System;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private AudioSource soundFXObject;
    [SerializeField]
    Slider volumeSlider;

    [SerializeField]
    public float globalVolume { get; private set; } = 1f;

    private void Start()
    {
        if (soundFXObject == null)
        {
            enabled = false;
            Debug.LogError("Sound manager missing general audio source.");
        }
    }

    public AudioSource CreateSource(AudioClip audioClip, Transform positionOfPlay, float volume)
    {
        AudioSource aS = Instantiate(soundFXObject, positionOfPlay.position, Quaternion.identity);

        aS.loop = false;
        aS.clip = audioClip;
        aS.volume = volume;

        return aS;
    }

    // Uses stack, works in lifo pattern.
    public AudioSource PlayInLoop(AudioClip audioClip, Transform positionOfPlay, float volume)
    {
        AudioSource aS = Instantiate(soundFXObject, positionOfPlay.position, Quaternion.identity);

        aS.loop = true;
        aS.clip = audioClip;
        aS.volume = volume;

        aS.Play();

        return aS;
    }

    public void StopFromLoop(AudioSource aS)
    {
        Destroy(aS.gameObject);
    }

    // Play once and destroy
    public void PlaySoundFX(AudioClip audioClip, Transform positionOfPlay, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, positionOfPlay.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = volume;

        float clipLength = audioSource.clip.length;

        audioSource.Play();

        Destroy(audioSource.gameObject, clipLength);
    }

    // Play once and destroy
    public void PlaySoundFX(AudioClip audioClip, Transform positionOfPlay)
    {
        AudioSource audioSource = Instantiate(soundFXObject, positionOfPlay.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = globalVolume;

        float clipLength = audioSource.clip.length;

        audioSource.Play();

        Destroy(audioSource.gameObject, clipLength);
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}