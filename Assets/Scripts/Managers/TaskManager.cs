using System.Collections.Generic;
using Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TaskManager : Singleton<TaskManager>
{
    [SerializeField]
    private string[] sceneNames;

    private SceneSwitcher _sw;

    private void Start()
    {
        Debug.Log("Started task manager");
        _sw = GetComponent<SceneSwitcher>();
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
        //StartCoroutine(_sw.GoToNextScene(sceneNames[0]));
    }
}