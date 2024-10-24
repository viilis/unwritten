using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public TaskBase Base { get; private set; }
    public TaskStatus Status { get; private set; }

    public Task(TaskBase _base)
    {
        Base = _base;
    }

    public IEnumerable StartTask()
    {
        Status = TaskStatus.Started;

        yield return "started task";
    }

    public IEnumerable CompleteTask()
    {
        Status = TaskStatus.Completed;

        yield return "completed";
    }
}

public enum TaskStatus
{
    None, Started, Completed
}
