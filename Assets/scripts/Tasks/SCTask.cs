using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCTask : ITask
{
    private bool _isCompleted;

    public bool IsComplete()
    {
        return _isCompleted;
    }
}