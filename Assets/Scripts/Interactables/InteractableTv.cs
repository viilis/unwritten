using UnityEngine;

public class InteractableTv : MonoBehaviour, IInteractable
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
    private Color newcolor;

    private Light _light;
    private ColorSwitcher _cSwitcher;
    private LightSwitcher _lSwitcher;
    private AudioInLoop _audioPlayer;
    private Color restore;

    private void Start()
    {
        _audioPlayer = new AudioInLoop(audioClip, audioPosition, volume);
        _cSwitcher = new ColorSwitcher(newcolor, material);

        _light = lightObj.GetComponent<Light>();
        if (_light != null)
        {
            _lSwitcher = new LightSwitcher(_light, false);
        }

        restore = material.color;
    }

    public void Interact()
    {
        _lSwitcher.Switch();
        _cSwitcher.SwitchColor();
        if (!_audioPlayer.isPlaying) { _audioPlayer.StartPlaying(); } else { _audioPlayer.StopPlaying(); }
    }

    public void BeforeInteraction()
    {
        return;
    }


    public void UndoBeforeInteraction()
    {
        return;
    }

    private void OnDestroy()
    {
        material.color = restore;
    }
}