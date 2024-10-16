using UnityEngine;

public class BluetoothSpeaker : MonoBehaviour, IEvent
{
    private AudioPerAction _audioPlayer;

    [SerializeField]
    private Transform _position;

    [SerializeField]
    private AudioClip _audioClip;

    [SerializeField]
    [Range(0, 1)]
    private float _volume = 0;

    private void Start()
    {
        _audioPlayer = new AudioPerAction(_audioClip, _position, _volume);
    }

    private void OnEnable()
    {
        EventManager.OnParanormalElectronicsEvent += OnEventTrigger;
    }

    private void OnDisable()
    {
        EventManager.OnParanormalElectronicsEvent -= OnEventTrigger;
    }

    public void OnEventTrigger()
    {
        _audioPlayer.PlayOnce();
    }
}