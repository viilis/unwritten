using System;
using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;

public class TaskManager
{
    public Action<Task> OnTaskAdded;

    public List<Task> Tasks { get; } = new();

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void OnCompletion(string name)
    {
        Debug.Log("Completed" + name);
    }

    private void Update()
    {

    }
}