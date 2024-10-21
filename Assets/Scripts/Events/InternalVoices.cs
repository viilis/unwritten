using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class InternalVoices : MonoBehaviour, IEvent
{

    [SerializeField]
    private AudioClip _audioClip;

    private AudioSource _as;

    [SerializeField]
    [Range(0, 1)]
    private float _volume = 0;

    private void Start()
    {
        _as = gameObject.AddComponent<AudioSource>();
        _as.clip = _audioClip;
        _as.volume = _volume;
        _as.loop = false;
    }

    private void OnEnable()
    {
        EventManager.OnInternalVoicesEvent += OnEventTrigger;
    }

    private void OnDisable()
    {
        EventManager.OnInternalVoicesEvent -= OnEventTrigger;
    }

    public void OnEventTrigger()
    {
        _as.Play();
    }
}