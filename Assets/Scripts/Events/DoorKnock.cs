using System;
using UnityEngine;

public class DoorKnock : MonoBehaviour, IEvent
{
    private AudioInLoop _audioPlayer;

    [SerializeField]
    private AudioClip _audioClip;

    [SerializeField]
    [Range(0, 1)]
    private float _volume = 0;

    private BoxCollider _tg;

    private void Start()
    {
        _audioPlayer = new AudioInLoop(_audioClip, gameObject.transform, _volume);
        _tg = GetComponent<BoxCollider>();
        _tg.isTrigger = true;
    }

    private void OnEnable()
    {
        EventManager.OnParanormalAudioEvent += OnEventTrigger;
    }

    private void OnDisable()
    {
        EventManager.OnParanormalAudioEvent -= OnEventTrigger;
    }

    private void OnTriggerEnter()
    {
        _audioPlayer.StopPlaying();
    }

    public void OnEventTrigger()
    {
        if (!_audioPlayer.isPlaying)
        {
            _audioPlayer.StartPlaying();
        }   
    }
}