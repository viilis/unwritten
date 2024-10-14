
using System;

public interface ITask
{
    public bool isCompleted { get; }
    public string taskName { get; }
    public void Complete();
}