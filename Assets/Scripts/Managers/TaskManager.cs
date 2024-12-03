using System.Collections.Generic;
using Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TaskManager : Singleton<TaskManager>
{

    public static bool canDoTasks;
    public static float _sanityHit;
    public string _taskName;
    private void Start()
    {
        Debug.Log("Started task manager");
        canDoTasks = false;
    }

    private void OnEnable()
    {
        GameTasks.GameTask.OnTaskCompletionEvent += WhenTaskCompletionTriggered;
    }

    private void OnDisable()
    {
        GameTasks.GameTask.OnTaskCompletionEvent -= WhenTaskCompletionTriggered;
    }

    private void WhenTaskCompletionTriggered(TaskBase tb)
    {
        Debug.Log("Completed task: " + tb.taskName);
        _taskName = tb.taskName;

        _sanityHit = tb.sanityHit;

        StartCoroutine(DayManager.Instance.GoToNextScene(false));
    }
}