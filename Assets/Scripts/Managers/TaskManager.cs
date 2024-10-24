using System;
using System.Collections;
using System.Collections.Generic;
using Unity;
using Unity.VisualScripting;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{
    private static int wTasksDone;
    private static int scTasksDone;

    private void OnEnable()
    {
        WTask.OnTaskCompletionEvent += WhenTaskComplitionTriggered;
    }

    private void OnDisable()
    {
        WTask.OnTaskCompletionEvent -= WhenTaskComplitionTriggered;
    }

    public void OnCompletion(string name, bool isWorkTask)
    {
        if (isWorkTask)
        {
            wTasksDone++;
        }
        else
        {
            scTasksDone++;
        }

        Debug.Log("Completed task: " + name + ", is work task?: " + isWorkTask);
        Debug.Log("Work tasks done: " + wTasksDone + " self care tasks done: " + scTasksDone);
    }

    private void WhenTaskComplitionTriggered(string taskName)
    {

    }
}