using UnityEditor.Rendering;
using UnityEngine;

public class AudioInLoop
{
    private Transform _position;
    private AudioClip _audioClip;
    private float _volume;
    private AudioSource _audioSource;

    public bool isPlaying = false;

    public AudioInLoop(AudioClip audioClip, Transform position, float volume)
    {
        _audioClip = audioClip;
        _position = position;
        _volume = volume * SoundManager.Instance.globalVolume;
    }

    public void StartPlaying()
    {
        _audioSource = SoundManager.Instance.PlayInLoop(_audioClip, _position, _volume);
        isPlaying = true;
    }

    public void StopPlaying()
    {
        if (_audioSource != null)
        {
            SoundManager.Instance.StopFromLoop(_audioSource);
            isPlaying = false;
        }
    }
}