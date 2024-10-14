using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SCTask : MonoBehaviour, ITask
{
    [SerializeField]
    private float sanityHit = 0;

    [SerializeField]
    private string _taskName;

    public static Action<string> OnTaskComplition;

    private bool _isCompleted = false;
    public bool isCompleted => _isCompleted;

    public string taskName => _taskName;

    public void Complete()
    {
        _isCompleted = true;
        OnTaskComplition?.Invoke(_taskName);
        PlayerSanity.DecreaseSanity(sanityHit);
    }
}