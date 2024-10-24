using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCTask : MonoBehaviour, ITask
{
    public static Action<string> OnTaskCompletion;

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
        OnTaskCompletion?.Invoke(name);
        TaskManager.Instance.OnCompletion(_taskName, false);
        StartCoroutine(_sceneswitcher.GoToNextScene(_sceneName));
    }

    void Start()
    {
        _sceneswitcher = GetComponent<SceneSwitcher>();
    }
}