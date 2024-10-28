using System;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class InteractableLamp : MonoBehaviour, IInteractable, IEvent
{
    [SerializeField]
    private Light attachedLight;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private Transform audioPosition;

    [SerializeField]
    [Range(0f, 1f)]
    private float volume = 0.5f;

    private LightSwitcher _switcher;
    private AudioPerAction _audioPlayer;
    private Outline _outline;
    private float _outlineWidth;

    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outlineWidth = _outline.OutlineWidth;

        //hide until first interaction;
        _outline.OutlineWidth = 0f;

        _audioPlayer = new AudioPerAction(audioClip, audioPosition, volume);
        _switcher = new LightSwitcher(attachedLight, false);
    }

    public void BeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        _outline.OutlineWidth = _outlineWidth;
    }

    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f;
    }

    public void OnEnable()
    {
        EventManager.Instance.OnParanormalElectronics += OnEventTrigger;
    }

    public void OnDisable()
    {
        EventManager.Instance.OnParanormalElectronics += OnEventTrigger;
    }

    public void Interact()
    {
        try
        {
            _switcher.Switch();
            _audioPlayer.PlayOnce();
        }
        catch (Exception err)
        {
            Debug.LogException(err);
        }
    }

    public void OnEventTrigger()
    {
        //TODO: Implement flickering
        return;
    }
}