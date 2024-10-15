using System;
using System.Collections.Generic;
using Unity;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private AudioSource soundFXObject;

    [SerializeField]
    private float globalVolume = 1f;

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
}