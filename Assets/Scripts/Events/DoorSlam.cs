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

    private string _opened = "paranormal_door_opened";
    private string _closed = "paranormal_door_closed";

    private void Start()
    {
        _audioPlayer = new AudioPerAction(_closeClip, gameObject.transform, _volume);

        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.isTrigger = true;
    }

    public void OnTriggerEnter()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_opened))
        {
            _animator.Play(_closed, 0, 0f);
            _audioPlayer.PlayOnce();
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
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_closed))
        {
            _animator.Play(_opened, 0, 0);
        }
    }
}