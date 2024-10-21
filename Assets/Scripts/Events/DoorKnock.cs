using System;
using UnityEngine;

public class DoorKnock : MonoBehaviour, IEvent
{
    private AudioPerAction _audioPlayer;

    [SerializeField]
    private AudioClip _audioClip;

    [SerializeField]
    [Range(0, 1)]
    private float _volume = 0;

    private bool _canBeTriggered = false;
    private BoxCollider _tg;

    [SerializeField]
    private bool playOnlyFromCollision = true;

    private void Start()
    {
        _audioPlayer = new AudioPerAction(_audioClip, gameObject.transform, _volume);
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

        if (_canBeTriggered && playOnlyFromCollision)
        {
            _canBeTriggered = false;
            _audioPlayer.PlayOnce();
        }
    }

    public void OnEventTrigger()
    {
        if (playOnlyFromCollision)
        {
            _canBeTriggered = true;
        }
        else
        {
            _audioPlayer.PlayOnce();
        }
    }
}