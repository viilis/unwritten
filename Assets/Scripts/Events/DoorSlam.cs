using Unity.VisualScripting;
using UnityEngine;

public class DoorSlam : MonoBehaviour, IEvent
{
    private AudioPerAction _audioPlayer;

    [SerializeField]
    private AudioClip _closeClip;

    [SerializeField]
    [Range(0, 1)]
    private float _volume = 0;

    [SerializeField]
    private Animator _animator;

    private BoxCollider _boxCollider;
    private bool _readyState;

    private void Start()
    {
        _audioPlayer = new AudioPerAction(_closeClip, gameObject.transform, _volume);

        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.isTrigger = true;
        _readyState = false;
    }

    public void OnTriggerEnter()
    {
        if (_readyState)
        {
            _animator.Play("paranormal_door_closed", 0, 0f);
            _audioPlayer.PlayOnce();
            _readyState = !_readyState;
            EventManager.OnParanormalDoorSlamEvent -= OnEventTrigger;
        }
    }

    private void OnEnable()
    {
        EventManager.OnParanormalDoorSlamEvent += OnEventTrigger;
    }

    private void OnDisable()
    {
        EventManager.OnParanormalDoorSlamEvent -= OnEventTrigger;
    }

    public void OnEventTrigger()
    {
        _animator.Play("paranormal_door_opened", 0, 0);
        _readyState = true;
    }
}