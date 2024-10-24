using System;
using Unity;
using UnityEngine;
using UnityEngine.Events;

public class WTask : MonoBehaviour, ITask
{
    public static event Action<string> OnTaskCompletionEvent;

    [SerializeField]
    private float sanityHit = 0;

    [SerializeField]
    private string _taskName;

    [SerializeField]
    private string _sceneName;

    private SceneSwitcher _sceneswitcher;

    public bool _isCompleted = false;
    public bool isCompleted => _isCompleted;
    public string taskName => _taskName;

    public void Complete()
    {
        _isCompleted = true;
        OnTaskCompletionEvent?.Invoke(name);
        TaskManager.Instance.OnCompletion(_taskName, true);

        StartCoroutine(_sceneswitcher.GoToNextScene(_sceneName));
    }

    void Start()
    {
        _sceneswitcher = GetComponent<SceneSwitcher>();
    }
}