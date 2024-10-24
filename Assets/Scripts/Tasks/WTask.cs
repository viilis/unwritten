using System;
using Unity;
using UnityEngine;
using UnityEngine.Events;

public class WTask : MonoBehaviour, ITask
{
    [SerializeField]
    private float sanityHit = 0;

    [SerializeField]
    private string _taskName;
    [SerializeField]
    private string _sceneName;
    public TaskManager _taskManager;
    public SceneSwitcher _sceneswitcher;
    private Action<string> OnTaskCompletion;

    public bool _isCompleted = false;
    public bool isCompleted => _isCompleted;
    public string taskName => _taskName;

    public void Complete()
    {
        _isCompleted = true;
        OnTaskCompletion?.Invoke(name);
        _taskManager.OnCompletion(_taskName, true);
        StartCoroutine(_sceneswitcher.GoToNextScene(_sceneName));
    }

    void Start()
    {
        _sceneswitcher.GetComponent<SceneSwitcher>();
    }
}