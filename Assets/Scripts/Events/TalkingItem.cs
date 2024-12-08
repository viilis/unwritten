using UnityEngine;

public class TalkingItem : MonoBehaviour, IEvent
{
    private AudioInLoop _audioPlayer;
    private BoxCollider _tg;

    [SerializeField]
    private AudioClip _audioClip;

    [SerializeField]
    [Range(0, 1)]
    private float _volume = 1;

    private void Start()
    {
        _audioPlayer = new AudioInLoop(_audioClip, gameObject.transform, _volume);
        _tg = GetComponent<BoxCollider>();
        _tg.isTrigger = true;
    }

    private void OnTriggerEnter()
    {
        if (_audioPlayer.isPlaying)
        {
            _audioPlayer.StopPlaying();
        }
    }

    private void OnEnable()
    {
        EventManager.OnTalkingItemsEvent += OnEventTrigger;
    }

    private void OnDisable()
    {
        EventManager.OnTalkingItemsEvent -= OnEventTrigger;
    }

    public void OnEventTrigger()
    {
        if (!_audioPlayer.isPlaying)
        {
            _audioPlayer.StartPlaying();
        }
    }
}