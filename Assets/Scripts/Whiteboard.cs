using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public GameObject checkmark1;
    public GameObject checkmark2;
    public GameObject checkmark3;
    public GameObject checkmark4;

    void Start()
    {
        checkmark1.SetActive(TaskManager.checkmark1);
        checkmark2.SetActive(TaskManager.checkmark2);
        checkmark3.SetActive(TaskManager.checkmark3);
        checkmark4.SetActive(TaskManager.checkmark4);
    }   
}
