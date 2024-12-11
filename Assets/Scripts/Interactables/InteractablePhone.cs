using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class InteractablePhone : MonoBehaviour, IInteractable
{
    private Outline _outline;
    [SerializeField]
    private GameObject _subtitles;
    private float _outlineWidth;
    [SerializeField]
    private Image _taskInfo;
    private TMP_Text _taskText;

    [SerializeField]
    [Range(0f, 1f)]
    private float volume = 0.5f;
    [SerializeField]
    private AudioClip phoneRingAudio;

    [SerializeField]
    private AudioClip[] managerDialogue;
    [SerializeField]
    private AudioClip kevDialogue;

    [SerializeField]
    private Transform audioPosition;
    private AudioInLoop _phoneRinging;
    private AudioPerAction _managerDialogue;
    private AudioPerAction _kevDialogue;
    [SerializeField]
    private TaskBase taskBase;

    public void Start()
    {
        _phoneRinging = new AudioInLoop(phoneRingAudio, audioPosition, volume);
        
        if(DayManager.Instance.GetCurrentTimeState() == "morning" || (DayManager.Instance.GetCurrentTimeState() == "evening" && DayManager.Instance.daysLeft == 3))
        {
            _phoneRinging.StartPlaying();
            TaskManager.canDoTasks = false;
        }        

        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outlineWidth = _outline.OutlineWidth;


        //hide until first interaction;
        _outline.OutlineWidth = 0f;

        _taskInfo.enabled = false;
        _taskText = _taskInfo.GetComponentInChildren<TMP_Text>();
        _taskText.text = "";
    }
    public void Interact()
    {
        EventManager.Instance.sanityTickEnabled = false;
        _managerDialogue = new AudioPerAction(managerDialogue[DayManager.Instance.daysLeft], audioPosition, volume);
        _kevDialogue = new AudioPerAction(kevDialogue, audioPosition, volume);

        _phoneRinging.StopPlaying();
        if(DayManager.Instance.GetCurrentTimeState() == "morning")
        {
            _managerDialogue.PlayOnce();
            _subtitles.GetComponent<Subtitles>().StartManagerSubtitles();
        }
        else if(DayManager.Instance.GetCurrentTimeState() == "evening" && DayManager.Instance.daysLeft == 3)
        {
            _kevDialogue.PlayOnce();
            _subtitles.GetComponent<Subtitles>().StartSituationalSubtitles();
        }

        _taskInfo.enabled = false;
        _taskText.text = "";

        //disable box collider after answering phone so the raycaster doesn't do anything to the phone anymore
        GetComponent<BoxCollider>().enabled = false;
    }

    public void BeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        _outline.OutlineWidth = _outlineWidth;
        _taskInfo.enabled = true;
        _taskText.text = taskBase.taskDescription;
    }

    public void UndoBeforeInteraction()
    {
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
        _outline.OutlineWidth = 0f;
        _taskInfo.enabled = false;
        _taskText.text = "";
    }
}
