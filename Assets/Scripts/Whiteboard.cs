using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public GameObject checkmark1;
    public GameObject checkmark2;
    public GameObject checkmark3;
    public GameObject checkmark4;

    void Update()
    {
        if(TaskManager.Instance._taskName.Equals("Write chapter"))
        {
            checkmark1.SetActive(true);
        } 
        else if(TaskManager.Instance._taskName.Equals("Review text"))
        {
            checkmark2.SetActive(true);
        } 
        else if(TaskManager.Instance._taskName.Equals("Check email"))
        {
            checkmark3.SetActive(true);
        } 
        else if(TaskManager.Instance._taskName.Equals("Do research"))
        {
            checkmark4.SetActive(true);
        }
    }
}
