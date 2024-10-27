using System;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableTv : MonoBehaviour, IInteractable, IEvent
{
    [SerializeField]
    private GameObject lightObj;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private Transform audioPosition;

    [SerializeField]
    [Range(0f, 1f)]
    private float volume = 0.5f;

    [SerializeField]
    private Material material;

    [SerializeField]
    private Color newcolor = Color.white;

    private Outline _outline;
    private Light _light;
    private ColorSwitcher _cSwitcher;
    private LightSwitcher _lSwitcher;
    private AudioInLoop _audioPlayer;
    private Color _restore;

    private float _outlineWidth;

    private void Start()
    {
        if (material == null)
        {
            enabled = false;
            Debug.LogError("Assign material you want to change");
        }

        if (audioClip == null)
        {
            enabled = false;
            Debug.LogError("Audio clip missing");
        }

        _audioPlayer = new AudioInLoop(audioClip, audioPosition, volume);
        _cSwitcher = new ColorSwitcher(newcolor, material);

        // Outline init
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outlineWidth = _outline.OutlineWidth;

        //hide until first interaction;
        _outline.OutlineWidth = 0f;

        // Light init
        _light = lightObj.GetComponent<Light>();
        if (_light != null)
        {
            _lSwitcher = new LightSwitcher(_light, false);
        }

        //material init
        _restore = material.color;
    }

    private void OnEnable()
    {
        EventManager.OnParanormalElectronicsEvent += OnEventTrigger;
    }

    private void OnDisable()
    {
        EventManager.OnParanormalElectronicsEvent -= OnEventTrigger;
    }

    public void Interact()
    {
        try
        {
            _lSwitcher.Switch();
            _cSwitcher.SwitchColor();
            if (!_audioPlayer.isPlaying) { _audioPlayer.StartPlaying(); } else { _audioPlayer.StopPlaying(); }
        }
        catch (Exception err)
        {
            Debug.LogException(err);
        }
    }

    public void BeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        _outline.OutlineWidth = _outlineWidth;
    }


    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f; ;
    }

    public void OnEventTrigger()
    {
        // Turns creepy tv on or off
        Interact();
    }

    private void OnDestroy()
    {
        material.color = _restore;
    }
}