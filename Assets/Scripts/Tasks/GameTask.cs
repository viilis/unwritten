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
        public bool blockTask = false;
        public static event Action<TaskBase> OnTaskCompletionEvent;
        private Outline _outline;
        private float _outlineWidth;

        [SerializeField]
        private TaskBase taskBase;

        [SerializeField]
        private Image _taskInfo;
        private TMP_Text _taskText;
        string _taskName;
        private void Start()
        {
            _outline = GetComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineHidden;
            _outlineWidth = _outline.OutlineWidth;

            _taskInfo.enabled = false;
            _taskText = _taskInfo.GetComponentInChildren<TMP_Text>();
            _taskText.text = "";

            _taskName = taskBase.taskName;
            
            //to prevent the player from spamming the same work task the entire day
            if(_taskName.Equals("Write chapter") && TaskManager.checkmark1)
                blockTask = true;

            if(_taskName.Equals("Review text") && TaskManager.checkmark2)
                blockTask = true;

            if(_taskName.Equals("Check emails") && TaskManager.checkmark3)
                blockTask = true;

            if(_taskName.Equals("Do research") && TaskManager.checkmark4)
                blockTask = true;

            //hide until first interaction;
            _outline.OutlineWidth = 0f;
        }

        public void Interact()
        {
            if(TaskManager.canDoTasks && !blockTask)
            {
                taskBase.taskState = TaskStates.Done;
                OnTaskCompletionEvent?.Invoke(taskBase);
                _taskText.text = taskBase.dialogBase.dialogContent;
                //TaskManager.canDoTasks = false;
            }
            else
            {
                _taskText.text = "I should do something else..";
                Debug.Log("Unable to do task");
            }
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