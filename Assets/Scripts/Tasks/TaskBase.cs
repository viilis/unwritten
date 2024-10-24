using Unity;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Tasks/Task base")]
public class TaskBase : ScriptableObject
{
    public string taskName;
    public string taskDescription;

    public TaskStates taskState = TaskStates.notStarted;

    public DialogBase dialogBase;

    [Range(-50, 50f)]
    public float sanityHit = 0f;
}