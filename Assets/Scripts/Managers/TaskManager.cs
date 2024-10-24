using Unity;
using Unity.VisualScripting;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{
    [SerializeField]
    private string[] sceneNames;

    private SceneSwitcher _sw;

    private void Start()
    {
        _sw = GetComponent<SceneSwitcher>();
    }

    private void OnEnable()
    {
        Task.OnTaskCompletionEvent += WhenTaskComplitionTriggered;
    }

    private void OnDisable()
    {
        Task.OnTaskCompletionEvent -= WhenTaskComplitionTriggered;
    }

    private void WhenTaskComplitionTriggered(TaskBase tb)
    {
        Debug.Log("Completed task: " + tb.taskName);
        PlayerSanity.ChangeSanity(tb.sanityHit);
        //StartCoroutine(_sw.GoToNextScene(sceneNames[0]));
    }
}