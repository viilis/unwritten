using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class InteractableLetter : MonoBehaviour, IInteractable
{
    private Outline _outline;
    private float _outlineWidth;
    [SerializeField]
    private GameObject[] postCard;
    private bool _state = false;
    private AudioPerAction _apa;
    [SerializeField]
    private Image _taskInfo;
    private TMP_Text _taskText;
    private BoxCollider _boxCollider;
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private AudioClip _openLetter;


    public void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outlineWidth = _outline.OutlineWidth;

        _boxCollider = GetComponent<BoxCollider>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if(DayManager.Instance.GetCurrentTimeState() == "evening" && DayManager.Instance.daysLeft != 3)
        {
            _boxCollider.enabled = true;
            _spriteRenderer.enabled = true;
        }
        else
        {
            _boxCollider.enabled = false;
            _spriteRenderer.enabled = false;            
        }

        _taskInfo.enabled = false;
        _taskText = _taskInfo.GetComponentInChildren<TMP_Text>();
        _taskText.text = "";

        //hide until first interaction;
        _outline.OutlineWidth = 0f;

        _apa = new AudioPerAction(_openLetter, this.transform, SoundManager.Instance.globalVolume);
    }

    public void BeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        _outline.OutlineWidth = _outlineWidth;
        _taskInfo.enabled = true;
        _taskText.text = "Read letter";
    }

    public void Interact()
    {
        // bool state to see if we have interacted
        _state = !_state;

        if (!_state)
        {
            EventManager.Instance.sanityTickEnabled = true;
            InputManager.Instance.EnableMouse();
            InputManager.Instance.EnableMovement();
            postCard[DayManager.Instance.daysLeft].SetActive(false);
            _boxCollider.enabled = false;
            _spriteRenderer.enabled = false;       
        }
        else
        {
            EventManager.Instance.sanityTickEnabled = false;
            _apa.PlayOnce();
            _taskInfo.enabled = false;
            _taskText.text = "";

            InputManager.Instance.DisableMouse();
            InputManager.Instance.DisableMovement();
            postCard[DayManager.Instance.daysLeft].SetActive(true);

        }
    }

    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f;
        _taskInfo.enabled = false;
        _taskText.text = "";
    }
}