using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GameTasks
{
    public abstract class GameTask1 : MonoBehaviour
    {
        public abstract event Action<TaskBase> OnTaskCompletionEvent;

        private abstract Outline _outline;

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
    }
}