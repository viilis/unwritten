using System;
using Unity;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private AudioSource soundFXObject;

    public void PlaySoundFX(AudioClip audioClip, Transform positionOfPlay, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, positionOfPlay.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        float clipLength = audioSource.clip.length;

        audioSource.Play();

        Destroy(audioSource.gameObject, clipLength);
    }
}