using System;
using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

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