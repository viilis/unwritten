using UnityEngine;

public class AudioPerAction
{
    private AudioClip _audioClip;
    private Transform _alternativePosition;
    private float _volume;

    public AudioPerAction(AudioClip clip, Transform position, float v)
    {
        _audioClip = clip;
        _alternativePosition = position;
        _volume = v;
    }

    public void PlayOnce()
    {
        SoundManager.Instance.PlaySoundFX(_audioClip, _alternativePosition, _volume);
    }

}