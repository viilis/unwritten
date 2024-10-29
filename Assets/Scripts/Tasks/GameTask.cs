using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

        private void Start()
        {
            _outline = GetComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineHidden;
            _outlineWidth = _outline.OutlineWidth;

            //hide until first interaction;
            _outline.OutlineWidth = 0f;
        }

        public void Interact()
        {
            if (taskBase.taskState != TaskStates.Done)
            {
                taskBase.taskState = TaskStates.Done;
                OnTaskCompletionEvent?.Invoke(taskBase);
            }
        }

        public void BeforeInteraction()
        {
            if (taskBase.taskState != TaskStates.Done)
            {
                _outline.OutlineMode = Outline.Mode.OutlineVisible;
                _outline.OutlineWidth = _outlineWidth;
            }
        }

        public void UndoBeforeInteraction()
        {
            _outline.OutlineMode = Outline.Mode.OutlineHidden;
            _outline.OutlineWidth = 0f;
        }
    }
}