using System.Collections.Generic;
using Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TaskManager : Singleton<TaskManager>
{

    private void Start()
    {
        Debug.Log("Started task manager");
    }

    private void OnEnable()
    {
        GameTasks.GameTask.OnTaskCompletionEvent += WhenTaskComplitionTriggered;
    }

    private void OnDisable()
    {
        GameTasks.GameTask.OnTaskCompletionEvent -= WhenTaskComplitionTriggered;
    }

    private void WhenTaskComplitionTriggered(TaskBase tb)
    {
        Debug.Log("Completed task: " + tb.taskName);

        PlayerSanity.ChangeSanity(tb.sanityHit);

        StartCoroutine(DayManager.Instance.GoToNextScene());
    }
}