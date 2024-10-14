using System;
using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static List<ITask> tasks;

    private void OnEnable()
    {
        tasks.ForEach(_t =>
        {
            Action<string> action = _t.GetAction();
            action += OnCompletion;
        });
    }

    private void OnDisable()
    {
        tasks.ForEach(_t =>
        {
            Action<string> action = _t.GetAction();
            action -= OnCompletion;
        });
    }

    private void OnCompletion(string name)
    {
        Debug.Log("Completed" + name);
    }

    private void Update()
    {

    }
}