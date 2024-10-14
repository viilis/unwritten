using System;
using Unity;
using UnityEngine;
using UnityEngine.Events;

public abstract class WTask : MonoBehaviour, ITask
{
    [SerializeField]
    private float sanityHit = 0;

    [SerializeField]
    private string _taskName;

    private Action<string> OnTaskComplition;

    private bool _isCompleted = false;

    public bool isCompleted => _isCompleted;
    public string taskName => _taskName;

    public void Complete()
    {
        _isCompleted = true;
        OnTaskComplition?.Invoke(name);
        PlayerSanity.IncreaseSanity(sanityHit);
    }

    public Action<string> GetAction()
    {
        return OnTaskComplition;
    }
}