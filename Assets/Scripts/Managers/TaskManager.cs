using System.Collections.Generic;
using Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TaskManager : Singleton<TaskManager>
{
    public static List<TaskBase> _taskList;
    public static bool canDoTasks;
    public static float _sanityHit;
    public string _taskName;
    public static bool checkmark1 = false;
    public static bool checkmark2 = false;
    public static bool checkmark3 = false;
    public static bool checkmark4 = false;
    private void Start()
    {
        _taskList = new List<TaskBase>();
        Debug.Log("Started task manager");

        //REMEMBER TO SET TO FALSE
        canDoTasks = true;
    }

    public void MorningReset()
    {
        checkmark1 = false;
        checkmark2 = false;
        checkmark3 = false;
        checkmark4 = false;

        _taskList.Clear();
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
        _taskList.Add(tb);

        if (_taskName.Equals("Write chapter"))
        {
            checkmark1 = true;
        }
        else if (_taskName.Equals("Review text"))
        {
            checkmark2 = true;
        }
        else if (_taskName.Equals("Check email"))
        {
            checkmark3 = true;
        }
        else if (_taskName.Equals("Do research"))
        {
            checkmark4 = true;
        }

        StartCoroutine(DayManager.Instance.GoToNextScene(false));
    }
}