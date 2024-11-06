using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace GameTasks
{
    [RequireComponent(typeof(Outline))]
    public class GameTask : MonoBehaviour, IInteractable
    {
        public static event Action<TaskBase> OnTaskCompletionEvent;

        private Outline _outline;
        private float _outlineWidth;

        [SerializeField]
        private TaskBase taskBase;

        [SerializeField]
        private Image _taskInfo;
        private TMP_Text _taskText;
        private void Start()
        {
            _outline = GetComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineHidden;
            _outlineWidth = _outline.OutlineWidth;

            _taskInfo.enabled = false;
            _taskText = _taskInfo.GetComponentInChildren<TMP_Text>();
            _taskText.text = "";

            //hide until first interaction;
            _outline.OutlineWidth = 0f;
        }

        public void Interact()
        {
            //Commented the if statement out because for some reason it seems to have caused a bug 
            //I could only complete the task once during all of the unity runtime, as in even if I end to playtesting, I still can't do it on my next one
            //the only way I could finish the same task again was if I restart unity entirely
            //I don't know what caused it, it might just be my computer idk but this fixed it for me
            
            //if (taskBase.taskState != TaskStates.Done)
            //{
                taskBase.taskState = TaskStates.Done;
                OnTaskCompletionEvent?.Invoke(taskBase);
                _taskText.text = taskBase.dialogBase.dialogContent;
            //}
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
}