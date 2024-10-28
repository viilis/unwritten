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

    [SerializeField]
    private bool playOnlyFromCollision = true;

    [SerializeField]
    private BoxCollider bc;

    private void Start()
    {
        _audioPlayer = new AudioPerAction(_audioClip, gameObject.transform, _volume);

        if (bc != null)
        {
            bc.isTrigger = true;
        }
        else
        {
            Debug.LogError("MISSING COLLIDER");
        }
    }

    private void OnEnable()
    {
        EventManager.Instance.OnParanormalDoorKnock += OnEventTrigger;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnParanormalDoorKnock -= OnEventTrigger;
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