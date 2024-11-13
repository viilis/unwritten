using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class InteractablePhone : MonoBehaviour, IInteractable
{

    //This phone should only ring in the morning scene so I think this script should be added to the phone only in that one scene
    //TODO: a switch case thingy that plays a different manager dialogue depending on which morning it is

    private Outline _outline;
    private float _outlineWidth;
    [SerializeField]
    private Image _taskInfo;
    private TMP_Text _taskText;
    [SerializeField]
    private Image _dialogueBox;
    private TMP_Text _dialogue;
    [SerializeField]
    private DialogBase dialogBase;

    [SerializeField]
    [Range(0f, 1f)]
    private float volume = 0.5f;
    [SerializeField]
    private AudioClip phoneRingAudio;
    [SerializeField]
    private AudioClip managerDialogueAudio;
    [SerializeField]
    private Transform audioPosition;
    private AudioInLoop _phoneRinging;
    private AudioPerAction _managerDialogue;
    [SerializeField]
    private TaskBase taskBase;

    public void Start()
    {
        //TODO: disable doing tasks until player has answered the phone
        _phoneRinging = new AudioInLoop(phoneRingAudio, audioPosition, volume);
        _phoneRinging.StartPlaying();

        _dialogueBox.enabled = false;
        _dialogue = _dialogueBox.GetComponentInChildren<TMP_Text>();

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
        //TODO: don't enable taskmanager until after the voice acting clip has finished playing
        _dialogueBox.enabled = true;
        _managerDialogue = new AudioPerAction(managerDialogueAudio, audioPosition, volume);
        _phoneRinging.StopPlaying();
        _managerDialogue.PlayOnce();
        _dialogue.text = dialogBase.dialogContent;
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