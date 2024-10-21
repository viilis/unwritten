using System;
using System.Collections;
using System.Collections.Generic;
using Unity;
using Unity.VisualScripting;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{
    public Action<Task> OnTaskAdded;
    public List<Task> Tasks { get; } = new();
    private static int wTasksDone;
    private static int scTasksDone;

    public void OnCompletion(string name, bool isWorkTask)
    {
        if(isWorkTask)
        {
            wTasksDone++;
        } 
        else if(!isWorkTask)
        {
            scTasksDone++;
        }

        Debug.Log("Completed task: " + name + ", is work task?: " + isWorkTask);
        Debug.Log("Work tasks done: " + wTasksDone + " self care tasks done: " + scTasksDone);
    }  
}