using System.Collections.Generic;
using Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TaskManager : Singleton<TaskManager>
{
    private List<TaskBase> _completedTasks;

    private void Start()
    {
        _completedTasks = new List<TaskBase>();
        Debug.Log("Started task manager");
    }

    private void OnEnable()
    {
        GameTasks.GameTask.OnTaskCompletionEvent += WhenTaskComplitionTriggered;
    }

    private void OnDisable()
    {
        GameTasks.GameTask.OnTaskCompletionEvent -= WhenTaskComplitionTriggered;

        foreach (TaskBase task in _completedTasks)
        {
            task.taskState = TaskStates.notStarted;
        }
    }

    private void WhenTaskComplitionTriggered(TaskBase tb)
    {
        _completedTasks.Add(tb);

        Debug.Log("Completed task: " + tb.taskName);

        PlayerSanity.ChangeSanity(tb.sanityHit);

        StartCoroutine(DayManager.Instance.GoToNextScene());
    }
}