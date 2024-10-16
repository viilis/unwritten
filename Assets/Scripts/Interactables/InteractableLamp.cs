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

    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f;

        _audioPlayer = new AudioPerAction(audioClip, audioPosition, volume);
        _switcher = new LightSwitcher(attachedLight, true);
    }

    public void BeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        _outline.OutlineWidth = 10f;
    }

    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f;
    }

    public void OnEnable()
    {
        EventManager.OnParanormalElectronicsEvent += OnEventTrigger;
    }

    public void OnDisable()
    {
        EventManager.OnParanormalElectronicsEvent += OnEventTrigger;
    }

    public void Interact()
    {
        _switcher.Switch();
        _audioPlayer.PlayOnce();
    }

    public void OnEventTrigger()
    {
        //TODO: Implement
        return;
    }
}